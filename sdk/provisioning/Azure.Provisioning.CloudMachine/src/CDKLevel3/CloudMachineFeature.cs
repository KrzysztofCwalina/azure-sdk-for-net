// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.CloudMachine;

namespace Azure.Provisioning.CloudMachine;

public abstract class CloudMachineFeature
{
    protected internal virtual void AddToCludMachine(CloudMachineInfrastructure cm) => cm.Features.Add(this);

    protected internal abstract void AddToInfrastructure(CloudMachineInfrastructure infrastructure);
}
