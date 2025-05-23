// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    internal class ArmDeploymentValidateResultOperationSource : IOperationSource<ArmDeploymentValidateResult>
    {
        ArmDeploymentValidateResult IOperationSource<ArmDeploymentValidateResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
            return ArmDeploymentValidateResult.DeserializeArmDeploymentValidateResult(document.RootElement);
        }

        async ValueTask<ArmDeploymentValidateResult> IOperationSource<ArmDeploymentValidateResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
            return ArmDeploymentValidateResult.DeserializeArmDeploymentValidateResult(document.RootElement);
        }
    }
}
