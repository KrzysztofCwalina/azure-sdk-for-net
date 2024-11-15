// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using System.IO;
using Azure.CloudMachine.KeyVault;
using Azure.CloudMachine.OpenAI;
using Azure.Provisioning;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Test]
    public void GenerateBicep()
    {
        CloudMachineCommands.Execute(["-bicep"], (CloudMachineInfrastructure infrastructure) =>
        {
            infrastructure.AddFeature(new KeyVaultFeature());
            infrastructure.AddFeature(new OpenAIModel("gpt-35-turbo", "0125"));
            infrastructure.AddFeature(new OpenAIModel("text-embedding-ada-002", "2", AIModelKind.Embedding));
        }, exitProcessIfHandled:false);
    }

    [Test]
    public void CMBicep()
    {
        string cmid = "cm000000000000000";
        CloudMachineInfrastructure cmi = new(cmid);
        ProvisioningPlan plan = cmi.Build();
        IDictionary<string, string> files = plan.Compile();
        Assert.AreEqual(1, files.Count);
        Assert.True(files.ContainsKey($"cm.bicep"));
        string bicep = files["cm.bicep"];
        string baseline = File.ReadAllText(Path.Combine("TestFiles", "cm.bicep"));
        Assert.AreEqual(baseline, bicep);
    }

    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        CloudMachineCommands.Execute(["-ai", "chat"], exitProcessIfHandled: false);
    }
}
