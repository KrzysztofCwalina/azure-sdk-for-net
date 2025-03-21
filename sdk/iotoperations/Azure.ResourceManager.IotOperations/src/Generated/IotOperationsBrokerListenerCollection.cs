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

namespace Azure.ResourceManager.IotOperations
{
    /// <summary>
    /// A class representing a collection of <see cref="IotOperationsBrokerListenerResource"/> and their operations.
    /// Each <see cref="IotOperationsBrokerListenerResource"/> in the collection will belong to the same instance of <see cref="IotOperationsBrokerResource"/>.
    /// To get an <see cref="IotOperationsBrokerListenerCollection"/> instance call the GetIotOperationsBrokerListeners method from an instance of <see cref="IotOperationsBrokerResource"/>.
    /// </summary>
    public partial class IotOperationsBrokerListenerCollection : ArmCollection, IEnumerable<IotOperationsBrokerListenerResource>, IAsyncEnumerable<IotOperationsBrokerListenerResource>
    {
        private readonly ClientDiagnostics _iotOperationsBrokerListenerBrokerListenerClientDiagnostics;
        private readonly BrokerListenerRestOperations _iotOperationsBrokerListenerBrokerListenerRestClient;

        /// <summary> Initializes a new instance of the <see cref="IotOperationsBrokerListenerCollection"/> class for mocking. </summary>
        protected IotOperationsBrokerListenerCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="IotOperationsBrokerListenerCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal IotOperationsBrokerListenerCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _iotOperationsBrokerListenerBrokerListenerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.IotOperations", IotOperationsBrokerListenerResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(IotOperationsBrokerListenerResource.ResourceType, out string iotOperationsBrokerListenerBrokerListenerApiVersion);
            _iotOperationsBrokerListenerBrokerListenerRestClient = new BrokerListenerRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, iotOperationsBrokerListenerBrokerListenerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != IotOperationsBrokerResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, IotOperationsBrokerResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create a BrokerListenerResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<IotOperationsBrokerListenerResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string listenerName, IotOperationsBrokerListenerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _iotOperationsBrokerListenerBrokerListenerRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, data, cancellationToken).ConfigureAwait(false);
                var operation = new IotOperationsArmOperation<IotOperationsBrokerListenerResource>(new IotOperationsBrokerListenerOperationSource(Client), _iotOperationsBrokerListenerBrokerListenerClientDiagnostics, Pipeline, _iotOperationsBrokerListenerBrokerListenerRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create a BrokerListenerResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<IotOperationsBrokerListenerResource> CreateOrUpdate(WaitUntil waitUntil, string listenerName, IotOperationsBrokerListenerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _iotOperationsBrokerListenerBrokerListenerRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, data, cancellationToken);
                var operation = new IotOperationsArmOperation<IotOperationsBrokerListenerResource>(new IotOperationsBrokerListenerOperationSource(Client), _iotOperationsBrokerListenerBrokerListenerClientDiagnostics, Pipeline, _iotOperationsBrokerListenerBrokerListenerRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Get a BrokerListenerResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> is null. </exception>
        public virtual async Task<Response<IotOperationsBrokerListenerResource>> GetAsync(string listenerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.Get");
            scope.Start();
            try
            {
                var response = await _iotOperationsBrokerListenerBrokerListenerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IotOperationsBrokerListenerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a BrokerListenerResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> is null. </exception>
        public virtual Response<IotOperationsBrokerListenerResource> Get(string listenerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.Get");
            scope.Start();
            try
            {
                var response = _iotOperationsBrokerListenerBrokerListenerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IotOperationsBrokerListenerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List BrokerListenerResource resources by BrokerResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="IotOperationsBrokerListenerResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<IotOperationsBrokerListenerResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _iotOperationsBrokerListenerBrokerListenerRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _iotOperationsBrokerListenerBrokerListenerRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new IotOperationsBrokerListenerResource(Client, IotOperationsBrokerListenerData.DeserializeIotOperationsBrokerListenerData(e)), _iotOperationsBrokerListenerBrokerListenerClientDiagnostics, Pipeline, "IotOperationsBrokerListenerCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List BrokerListenerResource resources by BrokerResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_ListByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="IotOperationsBrokerListenerResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<IotOperationsBrokerListenerResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _iotOperationsBrokerListenerBrokerListenerRestClient.CreateListByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _iotOperationsBrokerListenerBrokerListenerRestClient.CreateListByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new IotOperationsBrokerListenerResource(Client, IotOperationsBrokerListenerData.DeserializeIotOperationsBrokerListenerData(e)), _iotOperationsBrokerListenerBrokerListenerClientDiagnostics, Pipeline, "IotOperationsBrokerListenerCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string listenerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.Exists");
            scope.Start();
            try
            {
                var response = await _iotOperationsBrokerListenerBrokerListenerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> is null. </exception>
        public virtual Response<bool> Exists(string listenerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.Exists");
            scope.Start();
            try
            {
                var response = _iotOperationsBrokerListenerBrokerListenerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> is null. </exception>
        public virtual async Task<NullableResponse<IotOperationsBrokerListenerResource>> GetIfExistsAsync(string listenerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _iotOperationsBrokerListenerBrokerListenerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<IotOperationsBrokerListenerResource>(response.GetRawResponse());
                return Response.FromValue(new IotOperationsBrokerListenerResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.IoTOperations/instances/{instanceName}/brokers/{brokerName}/listeners/{listenerName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BrokerListenerResource_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IotOperationsBrokerListenerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="listenerName"> Name of Instance broker listener resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="listenerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="listenerName"/> is null. </exception>
        public virtual NullableResponse<IotOperationsBrokerListenerResource> GetIfExists(string listenerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(listenerName, nameof(listenerName));

            using var scope = _iotOperationsBrokerListenerBrokerListenerClientDiagnostics.CreateScope("IotOperationsBrokerListenerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _iotOperationsBrokerListenerBrokerListenerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, listenerName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<IotOperationsBrokerListenerResource>(response.GetRawResponse());
                return Response.FromValue(new IotOperationsBrokerListenerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<IotOperationsBrokerListenerResource> IEnumerable<IotOperationsBrokerListenerResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<IotOperationsBrokerListenerResource> IAsyncEnumerable<IotOperationsBrokerListenerResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
