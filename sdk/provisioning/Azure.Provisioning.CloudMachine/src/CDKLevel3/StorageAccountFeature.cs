// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Primitives;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.CloudMachine;

namespace Azure.CloudMachine;

internal class StorageAccountFeature : CloudMachineFeature
{
    internal StorageAccount? Account { get; private set; }
    public List<RoleAssignment> Roles = new();

    public StorageAccountFeature()
    {
    }

    protected internal override void AddToCludMachine(CloudMachineInfrastructure cm)
    {
        ManagedServiceIdentity storageAccoutIdentity = new()
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
            UserAssignedIdentities = { { BicepFunction.Interpolate($"{cm.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
        };

        Account = new("cm_storage", StorageAccount.ResourceVersions.V2023_01_01)
        {
            Name = cm.Id,
            Kind = StorageKind.StorageV2,
            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
            IsHnsEnabled = true,
            AllowBlobPublicAccess = false,
            Identity = storageAccoutIdentity
        };

        AddRoleAssignment(StorageBuiltInRole.StorageBlobDataContributor, RoleManagementPrincipalType.User, cm.PrincipalIdParameter);
        AddRoleAssignment(StorageBuiltInRole.StorageTableDataContributor, RoleManagementPrincipalType.User, cm.PrincipalIdParameter);
    }

    protected internal override void AddToInfrastructure(CloudMachineInfrastructure cm)
    {
        cm.Infrastructure.Add(Account!);
        foreach (var role in Roles)
        {
            cm.Infrastructure.Add(role);
        }
    }

    public void AddRoleAssignment(StorageBuiltInRole role, RoleManagementPrincipalType principalType, ProvisioningParameter principalIdParameter)
    {
        var assignment = Account!.CreateRoleAssignment(role, principalType, principalIdParameter);
        Roles.Add(assignment);
    }
}
