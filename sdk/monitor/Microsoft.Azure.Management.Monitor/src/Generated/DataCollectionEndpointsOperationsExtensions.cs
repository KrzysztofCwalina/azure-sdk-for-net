// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Monitor
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for DataCollectionEndpointsOperations.
    /// </summary>
    public static partial class DataCollectionEndpointsOperationsExtensions
    {
            /// <summary>
            /// Lists all data collection endpoints in the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            public static IPage<DataCollectionEndpointResource> ListByResourceGroup(this IDataCollectionEndpointsOperations operations, string resourceGroupName)
            {
                return operations.ListByResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataCollectionEndpointResource>> ListByResourceGroupAsync(this IDataCollectionEndpointsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IPage<DataCollectionEndpointResource> ListBySubscription(this IDataCollectionEndpointsOperations operations)
            {
                return operations.ListBySubscriptionAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataCollectionEndpointResource>> ListBySubscriptionAsync(this IDataCollectionEndpointsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the specified data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            public static DataCollectionEndpointResource Get(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName)
            {
                return operations.GetAsync(resourceGroupName, dataCollectionEndpointName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the specified data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataCollectionEndpointResource> GetAsync(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, dataCollectionEndpointName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates a data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            /// <param name='body'>
            /// The payload
            /// </param>
            public static DataCollectionEndpointResource Create(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName, DataCollectionEndpointResource body = default(DataCollectionEndpointResource))
            {
                return operations.CreateAsync(resourceGroupName, dataCollectionEndpointName, body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates a data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            /// <param name='body'>
            /// The payload
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataCollectionEndpointResource> CreateAsync(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName, DataCollectionEndpointResource body = default(DataCollectionEndpointResource), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, dataCollectionEndpointName, body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates part of a data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            /// <param name='tags'>
            /// Resource tags.
            /// </param>
            public static DataCollectionEndpointResource Update(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName, IDictionary<string, string> tags = default(IDictionary<string, string>))
            {
                return operations.UpdateAsync(resourceGroupName, dataCollectionEndpointName, tags).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates part of a data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            /// <param name='tags'>
            /// Resource tags.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DataCollectionEndpointResource> UpdateAsync(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName, IDictionary<string, string> tags = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, dataCollectionEndpointName, tags, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            public static void Delete(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName)
            {
                operations.DeleteAsync(resourceGroupName, dataCollectionEndpointName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a data collection endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='dataCollectionEndpointName'>
            /// The name of the data collection endpoint. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IDataCollectionEndpointsOperations operations, string resourceGroupName, string dataCollectionEndpointName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, dataCollectionEndpointName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<DataCollectionEndpointResource> ListByResourceGroupNext(this IDataCollectionEndpointsOperations operations, string nextPageLink)
            {
                return operations.ListByResourceGroupNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataCollectionEndpointResource>> ListByResourceGroupNextAsync(this IDataCollectionEndpointsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<DataCollectionEndpointResource> ListBySubscriptionNext(this IDataCollectionEndpointsOperations operations, string nextPageLink)
            {
                return operations.ListBySubscriptionNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all data collection endpoints in the specified subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<DataCollectionEndpointResource>> ListBySubscriptionNextAsync(this IDataCollectionEndpointsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
