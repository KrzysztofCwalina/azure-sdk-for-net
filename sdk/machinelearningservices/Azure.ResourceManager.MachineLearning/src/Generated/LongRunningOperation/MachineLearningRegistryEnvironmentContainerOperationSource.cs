// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    internal class MachineLearningRegistryEnvironmentContainerOperationSource : IOperationSource<MachineLearningRegistryEnvironmentContainerResource>
    {
        private readonly ArmClient _client;

        internal MachineLearningRegistryEnvironmentContainerOperationSource(ArmClient client)
        {
            _client = client;
        }

        MachineLearningRegistryEnvironmentContainerResource IOperationSource<MachineLearningRegistryEnvironmentContainerResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MachineLearningEnvironmentContainerData>(response.Content);
            return new MachineLearningRegistryEnvironmentContainerResource(_client, data);
        }

        async ValueTask<MachineLearningRegistryEnvironmentContainerResource> IOperationSource<MachineLearningRegistryEnvironmentContainerResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MachineLearningEnvironmentContainerData>(response.Content);
            return await Task.FromResult(new MachineLearningRegistryEnvironmentContainerResource(_client, data)).ConfigureAwait(false);
        }
    }
}
