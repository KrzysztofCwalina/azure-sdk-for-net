// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;

namespace Azure.CloudMachine.KeyVault;

public class KeyVaultFeature : CloudMachineFeature
{
    public List<RoleAssignment> RoleAssignments = new();
    public KeyVaultSku Sku { get; set; }

    private KeyVaultService? _kvService;

    public KeyVaultFeature(KeyVaultSku? sku = default)
    {
        if (sku == null)
        {
            sku = new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, };
        }
        Sku = sku;
    }

    protected internal override void AddToCludMachine(CloudMachineInfrastructure cm)
    {
        // Add a KeyVault to the CloudMachine infrastructure.
        _kvService = new("cm_kv")
        {
            Name = cm.Id,
            Properties = new KeyVaultProperties {
                    Sku = this.Sku,
                    TenantId = BicepFunction.GetSubscription().TenantId,
                    EnabledForDeployment = true,
                    AccessPolicies = [
                        new KeyVaultAccessPolicy() {
                            ObjectId = cm.PrincipalIdParameter,
                            Permissions = new IdentityAccessPermissions() {
                                Secrets =  [IdentityAccessSecretPermission.Get, IdentityAccessSecretPermission.Set]
                            },
                            TenantId = cm.Identity.TenantId
                        }
                    ]
            },
        };
        cm.Features.Add(this);

        RoleAssignment ra = _kvService.CreateRoleAssignment(KeyVaultBuiltInRole.KeyVaultAdministrator, RoleManagementPrincipalType.User, cm.PrincipalIdParameter);
        RoleAssignments.Add(ra);

        // necessary until ResourceName is settable via AssignRole.
        RoleAssignment kvMiRoleAssignment = new RoleAssignment(_kvService.BicepIdentifier + "_" + cm.Identity.BicepIdentifier + "_" + KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator));
        kvMiRoleAssignment.Name = BicepFunction.CreateGuid(_kvService.Id, cm.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString()));
        kvMiRoleAssignment.Scope = new IdentifierExpression(_kvService.BicepIdentifier);
        kvMiRoleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        kvMiRoleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString());
        kvMiRoleAssignment.PrincipalId = cm.Identity.PrincipalId;
        RoleAssignments.Add(kvMiRoleAssignment);
    }

    protected internal override void AddToInfrastructure(CloudMachineInfrastructure infrastructure)
    {
        Debug.Assert(_kvService != null);
        infrastructure.Infrastructure.Add(_kvService!);
        foreach (RoleAssignment ra in RoleAssignments)
        {
            infrastructure.Infrastructure.Add(ra);
        }
    }
}
