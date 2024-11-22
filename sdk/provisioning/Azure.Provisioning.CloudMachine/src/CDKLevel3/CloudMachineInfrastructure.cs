// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;
using Azure.Provisioning.ServiceBus;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Primitives;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.CloudMachine;

namespace Azure.CloudMachine;

public class CloudMachineInfrastructure
{
    private const string PARAMETER_PRINCIPAL_ID = "principalId";
    private const string PARAMETER_LOCATION = "location";

    private const string OUTPUT_IDENTITY_ID= "cm_managed_identity_id";
    private const string OUTPUT_STORAGE_ACCOUNT = "storage_name";
    private const string OUTPUT_SERVICEBUS_NAMESPACE = "servicebus_name";

    public Infrastructure Infrastructure { get; } = new("cm");
    private readonly List<Provisionable> _provisionables = new();

    internal FeatureCollection Features { get; } = new();
    internal List<Type> Endpoints { get; } = new();

    public UserAssignedIdentity Identity { get; private set; }
    public string Id { get; }

    public ProvisioningParameter PrincipalIdParameter { get; } = new ProvisioningParameter(PARAMETER_PRINCIPAL_ID, typeof(string));
    public ProvisioningParameter LocationParameter { get; } = new ProvisioningParameter(PARAMETER_LOCATION, typeof(string))
    {
        Description = "The location for the resource(s) to be deployed.",
        Value = BicepFunction.GetResourceGroup().Location
    };

    public CloudMachineInfrastructure(string id)
    {
        Id = id;

        // setup CM identity
        Identity = new UserAssignedIdentity("cm_identity")
        {
            Name = Id
        };
    }

    public T AddFeature<T>(T feature) where T:CloudMachineFeature
    {
        feature.AddToCludMachine(this);
        return feature;
    }

    public void AddEndpoints<T>()
    {
        Type endpointsType = typeof(T);
        if (!endpointsType.IsInterface) throw new InvalidOperationException("Endpoints type must be an interface.");
        Endpoints.Add(endpointsType);
    }

    public ProvisioningPlan Build(ProvisioningBuildOptions? context = null)
    {
        StorageAccountFeature sa = new StorageAccountFeature();
        sa.AddToCludMachine(this);

        BlobService blobsService = new("cm_storage_blobs")
        {
            Parent = sa.Account,
        };
        BlobContainer blobsContainer = new BlobContainer("cm_storage_blobs_container", "2023-01-01")
        {
            Parent = blobsService,
            Name = "default"
        };
        ServiceBusNamespace serviceBusNamespace = new("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = ServiceBusSkuName.Standard,
                Tier = ServiceBusSkuTier.Standard
            },
            Name = Id,
        };
        ServiceBusNamespaceAuthorizationRule serviceBusNamespaceAuthorizationRule = new("cm_servicebus_auth_rule", "2021-11-01")
        {
            Parent = serviceBusNamespace,
            Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
        };
        ServiceBusTopic serviceBusTopic_private = new("cm_servicebus_topic_private", "2021-11-01")
        {
            Name = "cm_servicebus_topic_private",
            Parent = serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        ServiceBusSubscription serviceBusSubscription_private = new("cm_servicebus_subscription_private", "2021-11-01")
        {
            Name = "cm_servicebus_subscription_private",
            Parent = serviceBusTopic_private,
            IsClientAffine = false,
            LockDuration = TimeSpan.FromSeconds(30),
            RequiresSession = false,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        ServiceBusTopic serviceBusTopic_default = new("cm_servicebus_topic_default", "2021-11-01")
        {
            Name = "cm_servicebus_default_topic",
            Parent = serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        ServiceBusSubscription serviceBusSubscription_default = new("cm_servicebus_subscription_default", "2021-11-01")
        {
            Name = "cm_servicebus_subscription_default",
            Parent = serviceBusTopic_default,
            IsClientAffine = false,
            LockDuration = TimeSpan.FromSeconds(30),
            RequiresSession = false,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };
        SystemTopic eventGridTopic_blobs = new("cm_eventgrid_topic_blob", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = sa.Account!.Id,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            Name = Id
        };
        SystemTopicEventSubscription eventGridSubscription_blobs = new("cm_eventgrid_subscription_blob", "2022-06-15")
        {
            Name = "cm-eventgrid-subscription-blob",
            Parent = eventGridTopic_blobs,
            DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity
            {
                Identity = new EventSubscriptionIdentity
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = Identity.Id
                },
                Destination = new ServiceBusTopicEventSubscriptionDestination
                {
                    ResourceId = serviceBusTopic_private.Id
                }
            },
            Filter = new EventSubscriptionFilter
            {
                IncludedEventTypes =
                [
                    "Microsoft.Storage.BlobCreated",
                    "Microsoft.Storage.BlobDeleted",
                    "Microsoft.Storage.BlobRenamed"
                ],
                IsAdvancedFilteringOnArraysEnabled = true
            },
            EventDeliverySchema = EventDeliverySchema.EventGridSchema,
            RetryPolicy = new EventSubscriptionRetryPolicy
            {
                MaxDeliveryAttempts = 30,
                EventTimeToLiveInMinutes = 1440
            }
        };
        // This is necessary until SystemTopic adds an AssignRole method.
        var role = ServiceBusBuiltInRole.AzureServiceBusDataSender;
        RoleAssignment roleAssignment = new RoleAssignment("cm_servicebus_role")
        {
            Name = BicepFunction.CreateGuid(serviceBusNamespace.Id, Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(serviceBusNamespace.BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = Identity.PrincipalId
        };

        Infrastructure.Add(Identity);

        sa.AddToInfrastructure(this);

        Infrastructure.Add(blobsContainer);
        Infrastructure.Add(blobsService);
        Infrastructure.Add(serviceBusNamespace);
        Infrastructure.Add(serviceBusNamespace.CreateRoleAssignment(ServiceBusBuiltInRole.AzureServiceBusDataOwner, RoleManagementPrincipalType.User, PrincipalIdParameter));
        Infrastructure.Add(serviceBusNamespaceAuthorizationRule);
        Infrastructure.Add(serviceBusTopic_private);
        Infrastructure.Add(serviceBusTopic_default);
        Infrastructure.Add(serviceBusSubscription_private);
        Infrastructure.Add(serviceBusSubscription_default);
        Infrastructure.Add(roleAssignment);
        // the role assignment must exist before the system topic event subscription is created.
        eventGridSubscription_blobs.DependsOn.Add(roleAssignment);
        Infrastructure.Add(eventGridSubscription_blobs);
        Infrastructure.Add(eventGridTopic_blobs);

        // Always add a default location parameter.
        // azd assumes there will be a location parameter for every module.
        // The Infrastructure location resolver will resolve unset Location properties to this parameter.
        Infrastructure.Add(LocationParameter);
        Infrastructure.Add(PrincipalIdParameter);

        Infrastructure.Add(new ProvisioningOutput(OUTPUT_IDENTITY_ID, typeof(string)) { Value = Identity.Id });
        Infrastructure.Add(new ProvisioningOutput(OUTPUT_STORAGE_ACCOUNT, typeof(string)) { Value = sa.Account.Name });
        Infrastructure.Add(new ProvisioningOutput(OUTPUT_SERVICEBUS_NAMESPACE, typeof(string)) { Value = serviceBusNamespace.Name });

        Features.AddToInfrastructure(this);
        // Add any add-on resources to the infrastructure.
        foreach (Provisionable provisionable in _provisionables)
        {
            Infrastructure.Add(provisionable);
        }

        return Infrastructure.Build(context);
    }

    public IEnumerable<T> FindFeatures<T>() where T : CloudMachineFeature
        => Features.FindAll<T>();
}
