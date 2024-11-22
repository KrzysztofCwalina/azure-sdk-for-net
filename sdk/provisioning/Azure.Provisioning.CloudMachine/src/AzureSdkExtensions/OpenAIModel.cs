// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CognitiveServices;

namespace Azure.CloudMachine.OpenAI;

public class OpenAIModel : CloudMachineFeature
{
    private List<OpenAIModel> dependsOn = new();
    public OpenAIModel(string model, string modelVersion, AIModelKind kind = AIModelKind.Chat) {
        Kind = kind;
        Model = model;
        ModelVersion = modelVersion;
    }

    public string Model { get; }
    public string ModelVersion { get; }
    private AIModelKind Kind { get; }

    internal OpenAIFeature? OpenAIFeature { get; set; }

    // TODO: this should be generalized
    public void DependsOn(OpenAIModel other)
        => dependsOn.Add(other);

    private OpenAIFeature GetOrCreateOpenAI(CloudMachineInfrastructure cm)
    {
        foreach (OpenAIFeature feature in cm.FindFeatures<OpenAIFeature>())
        {
            return feature;
        }
        var openAI = new OpenAIFeature();
        cm.AddFeature(openAI);
        return openAI;
    }

    protected internal override void AddToCludMachine(CloudMachineInfrastructure cm)
    {
        OpenAIFeature openAI = GetOrCreateOpenAI(cm);
        openAI.AddModel(this);
    }

    protected internal override void AddToInfrastructure(CloudMachineInfrastructure cm)
    {
        if (OpenAIFeature == null)
        {
            throw new InvalidOperationException("Cannot add model to infrastructure without adding to CloudMachine first");
        }

        string name = Kind switch
        {
            AIModelKind.Chat => $"{cm.Id}_chat",
            AIModelKind.Embedding => $"{cm.Id}_embedding",
            _ => throw new NotImplementedException()
        };

        CognitiveServicesAccount parent = OpenAIFeature.Account!;

        CognitiveServicesAccountDeployment deployment = new($"openai_{name}", "2024-06-01-preview")
        {
            Parent = parent,
            Name = name,
            Properties = new CognitiveServicesAccountDeploymentProperties()
            {
                Model = new CognitiveServicesAccountDeploymentModel()
                {
                    Name = Model,
                    Format = "OpenAI",
                    Version = ModelVersion
                },
                VersionUpgradeOption = DeploymentModelVersionUpgradeOption.OnceNewDefaultVersionAvailable,
                RaiPolicyName = "Microsoft.DefaultV2",
            },
            Sku = new CognitiveServicesSku
            {
                Capacity = 120,
                Name = "Standard"
            }
        };

        cm.Infrastructure.Add(deployment);
    }
}

public enum AIModelKind
{
    Chat,
    Embedding,
}
