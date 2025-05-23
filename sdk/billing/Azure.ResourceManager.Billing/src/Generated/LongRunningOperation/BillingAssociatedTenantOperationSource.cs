// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    internal class BillingAssociatedTenantOperationSource : IOperationSource<BillingAssociatedTenantResource>
    {
        private readonly ArmClient _client;

        internal BillingAssociatedTenantOperationSource(ArmClient client)
        {
            _client = client;
        }

        BillingAssociatedTenantResource IOperationSource<BillingAssociatedTenantResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<BillingAssociatedTenantData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerBillingContext.Default);
            return new BillingAssociatedTenantResource(_client, data);
        }

        async ValueTask<BillingAssociatedTenantResource> IOperationSource<BillingAssociatedTenantResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<BillingAssociatedTenantData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerBillingContext.Default);
            return await Task.FromResult(new BillingAssociatedTenantResource(_client, data)).ConfigureAwait(false);
        }
    }
}
