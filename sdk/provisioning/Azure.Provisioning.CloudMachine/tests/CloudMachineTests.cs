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
    private const string test_cmid = "cm000000000000000";
    private const string cmbicepFilename = "cm.bicep";

    [Test]
    public void CloudMachineBicep()
    {
        CloudMachineInfrastructure cmi = new(test_cmid);
        VerifySameBicep(cmi, "cm.bicep");
    }

    [Test]
    public void OpenAIBicep()
    {
        CloudMachineInfrastructure cmi = new(test_cmid);
        cmi.AddFeature(new OpenAIModel("gpt-35-turbo", "0125"));
        cmi.AddFeature(new OpenAIModel("text-embedding-ada-002", "2", AIModelKind.Embedding));
        VerifySameBicep(cmi, "openai.bicep");
    }

    [Test]
    public void KeyVaultBicep()
    {
        CloudMachineInfrastructure cmi = new(test_cmid);
        cmi.AddFeature(new KeyVaultFeature());
        VerifySameBicep(cmi, "kv.bicep");
    }

    private static void VerifySameBicep(CloudMachineInfrastructure cmi, string testFile)
    {
        ProvisioningPlan plan = cmi.Build();
        IDictionary<string, string> files = plan.Compile();
        Assert.AreEqual(1, files.Count);
        Assert.True(files.ContainsKey(cmbicepFilename));
        string bicep = files[cmbicepFilename];
        string baseline = File.ReadAllText(Path.Combine("TestFiles", testFile));
        Assert.AreEqual(baseline, bicep);
    }
}
