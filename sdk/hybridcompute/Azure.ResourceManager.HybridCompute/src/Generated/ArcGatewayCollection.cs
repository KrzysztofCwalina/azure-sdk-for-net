// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.HybridCompute
{
    /// <summary>
    /// A class representing a collection of <see cref="ArcGatewayResource"/> and their operations.
    /// Each <see cref="ArcGatewayResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get an <see cref="ArcGatewayCollection"/> instance call the GetArcGateways method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class ArcGatewayCollection : ArmCollection, IEnumerable<ArcGatewayResource>, IAsyncEnumerable<ArcGatewayResource>
    {
        private readonly ClientDiagnostics _arcGatewayGatewaysClientDiagnostics;
        private readonly GatewaysRestOperations _arcGatewayGatewaysRestClient;

        /// <summary> Initializes a new instance of the <see cref="ArcGatewayCollection"/> class for mocking. </summary>
        protected ArcGatewayCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArcGatewayCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ArcGatewayCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _arcGatewayGatewaysClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.HybridCompute", ArcGatewayResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ArcGatewayResource.ResourceType, out string arcGatewayGatewaysApiVersion);
            _arcGatewayGatewaysRestClient = new GatewaysRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, arcGatewayGatewaysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="data"> Parameters supplied to the Create gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ArcGatewayResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string gatewayName, ArcGatewayData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, data, cancellationToken).ConfigureAwait(false);
                var operation = new HybridComputeArmOperation<ArcGatewayResource>(new ArcGatewayOperationSource(Client), _arcGatewayGatewaysClientDiagnostics, Pipeline, _arcGatewayGatewaysRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to create or update a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="data"> Parameters supplied to the Create gateway operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ArcGatewayResource> CreateOrUpdate(WaitUntil waitUntil, string gatewayName, ArcGatewayData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, data, cancellationToken);
                var operation = new HybridComputeArmOperation<ArcGatewayResource>(new ArcGatewayOperationSource(Client), _arcGatewayGatewaysClientDiagnostics, Pipeline, _arcGatewayGatewaysRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the view of a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> is null. </exception>
        public virtual async Task<Response<ArcGatewayResource>> GetAsync(string gatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the view of a gateway.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> is null. </exception>
        public virtual Response<ArcGatewayResource> Get(string gatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get all gateways of a non-Azure machine
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ArcGatewayResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ArcGatewayResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _arcGatewayGatewaysRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _arcGatewayGatewaysRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ArcGatewayResource(Client, ArcGatewayData.DeserializeArcGatewayData(e)), _arcGatewayGatewaysClientDiagnostics, Pipeline, "ArcGatewayCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The operation to get all gateways of a non-Azure machine
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ArcGatewayResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ArcGatewayResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _arcGatewayGatewaysRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _arcGatewayGatewaysRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ArcGatewayResource(Client, ArcGatewayData.DeserializeArcGatewayData(e)), _arcGatewayGatewaysClientDiagnostics, Pipeline, "ArcGatewayCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string gatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> is null. </exception>
        public virtual Response<bool> Exists(string gatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> is null. </exception>
        public virtual async Task<NullableResponse<ArcGatewayResource>> GetIfExistsAsync(string gatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _arcGatewayGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<ArcGatewayResource>(response.GetRawResponse());
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/gateways/{gatewayName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Gateways_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-31-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArcGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayName"> The name of the Gateway. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="gatewayName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayName"/> is null. </exception>
        public virtual NullableResponse<ArcGatewayResource> GetIfExists(string gatewayName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(gatewayName, nameof(gatewayName));

            using var scope = _arcGatewayGatewaysClientDiagnostics.CreateScope("ArcGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _arcGatewayGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, gatewayName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<ArcGatewayResource>(response.GetRawResponse());
                return Response.FromValue(new ArcGatewayResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ArcGatewayResource> IEnumerable<ArcGatewayResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ArcGatewayResource> IAsyncEnumerable<ArcGatewayResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
