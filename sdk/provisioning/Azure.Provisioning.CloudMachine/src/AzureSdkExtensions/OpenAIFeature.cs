// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;

namespace Azure.CloudMachine.OpenAI;

internal class OpenAIFeature : CloudMachineFeature
{
    private List<OpenAIModel> _models = new();
    public List<RoleAssignment> Roles = new();
    internal CognitiveServicesAccount? Account { get; set; }

    public OpenAIFeature() {}

    protected internal override void AddToCludMachine(CloudMachineInfrastructure cm)
    {
        Account = new("openai")
        {
            Name = cm.Id,
            Kind = "OpenAI",
            Sku = new CognitiveServicesSku { Name = "S0" },
            Properties = new CognitiveServicesAccountProperties()
            {
                PublicNetworkAccess = ServiceAccountPublicNetworkAccess.Enabled,
                CustomSubDomainName = cm.Id
            },
        };

        AddRoleAssignment(
            CognitiveServicesBuiltInRole.CognitiveServicesOpenAIContributor,
            RoleManagementPrincipalType.User,
            cm.PrincipalIdParameter
        );
    }

    protected internal override void AddToInfrastructure(CloudMachineInfrastructure cm)
    {
        cm.Infrastructure.Add(Account!);
        foreach (var role in Roles)
        {
            cm.Infrastructure.Add(role);
        }
        OpenAIModel? previous = null;
        foreach (OpenAIModel model in _models)
        {
            if (previous != null) {
                model.DependsOn(previous);
            }
            previous = model;
            model.AddToInfrastructure(cm);
        }
    }

    internal void AddModel(OpenAIModel model)
    {
        if (model.OpenAIFeature!= null)
        {
            throw new InvalidOperationException("Model already added to an account");
        }
        model.OpenAIFeature = this;
        _models.Add(model);
    }

    public void AddRoleAssignment(CognitiveServicesBuiltInRole role, RoleManagementPrincipalType principalType, ProvisioningParameter principalIdParameter)
    {
        var assignment = Account!.CreateRoleAssignment(role, principalType, principalIdParameter);
        Roles.Add(assignment);
    }
}
