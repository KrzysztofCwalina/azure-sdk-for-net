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
using Azure.ResourceManager.AppComplianceAutomation.Models;

namespace Azure.ResourceManager.AppComplianceAutomation
{
    /// <summary>
    /// A class representing a collection of <see cref="AppComplianceReportEvidenceResource"/> and their operations.
    /// Each <see cref="AppComplianceReportEvidenceResource"/> in the collection will belong to the same instance of <see cref="AppComplianceReportResource"/>.
    /// To get an <see cref="AppComplianceReportEvidenceCollection"/> instance call the GetAppComplianceReportEvidences method from an instance of <see cref="AppComplianceReportResource"/>.
    /// </summary>
    public partial class AppComplianceReportEvidenceCollection : ArmCollection, IEnumerable<AppComplianceReportEvidenceResource>, IAsyncEnumerable<AppComplianceReportEvidenceResource>
    {
        private readonly ClientDiagnostics _appComplianceReportEvidenceEvidenceClientDiagnostics;
        private readonly EvidenceRestOperations _appComplianceReportEvidenceEvidenceRestClient;

        /// <summary> Initializes a new instance of the <see cref="AppComplianceReportEvidenceCollection"/> class for mocking. </summary>
        protected AppComplianceReportEvidenceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AppComplianceReportEvidenceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AppComplianceReportEvidenceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _appComplianceReportEvidenceEvidenceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppComplianceAutomation", AppComplianceReportEvidenceResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AppComplianceReportEvidenceResource.ResourceType, out string appComplianceReportEvidenceEvidenceApiVersion);
            _appComplianceReportEvidenceEvidenceRestClient = new EvidenceRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, appComplianceReportEvidenceEvidenceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AppComplianceReportResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AppComplianceReportResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or Update an evidence a specified report
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="data"> Parameters for the create or update operation. </param>
        /// <param name="offerGuid"> The offerGuid which mapping to the reports. </param>
        /// <param name="reportCreatorTenantId"> The tenant id of the report creator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AppComplianceReportEvidenceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string evidenceName, AppComplianceReportEvidenceData data, string offerGuid = null, string reportCreatorTenantId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _appComplianceReportEvidenceEvidenceRestClient.CreateOrUpdateAsync(Id.Name, evidenceName, data, offerGuid, reportCreatorTenantId, cancellationToken).ConfigureAwait(false);
                var uri = _appComplianceReportEvidenceEvidenceRestClient.CreateCreateOrUpdateRequestUri(Id.Name, evidenceName, data, offerGuid, reportCreatorTenantId);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new AppComplianceAutomationArmOperation<AppComplianceReportEvidenceResource>(Response.FromValue(new AppComplianceReportEvidenceResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Create or Update an evidence a specified report
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="data"> Parameters for the create or update operation. </param>
        /// <param name="offerGuid"> The offerGuid which mapping to the reports. </param>
        /// <param name="reportCreatorTenantId"> The tenant id of the report creator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AppComplianceReportEvidenceResource> CreateOrUpdate(WaitUntil waitUntil, string evidenceName, AppComplianceReportEvidenceData data, string offerGuid = null, string reportCreatorTenantId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _appComplianceReportEvidenceEvidenceRestClient.CreateOrUpdate(Id.Name, evidenceName, data, offerGuid, reportCreatorTenantId, cancellationToken);
                var uri = _appComplianceReportEvidenceEvidenceRestClient.CreateCreateOrUpdateRequestUri(Id.Name, evidenceName, data, offerGuid, reportCreatorTenantId);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new AppComplianceAutomationArmOperation<AppComplianceReportEvidenceResource>(Response.FromValue(new AppComplianceReportEvidenceResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Get the evidence metadata
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> is null. </exception>
        public virtual async Task<Response<AppComplianceReportEvidenceResource>> GetAsync(string evidenceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.Get");
            scope.Start();
            try
            {
                var response = await _appComplianceReportEvidenceEvidenceRestClient.GetAsync(Id.Name, evidenceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AppComplianceReportEvidenceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the evidence metadata
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> is null. </exception>
        public virtual Response<AppComplianceReportEvidenceResource> Get(string evidenceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.Get");
            scope.Start();
            try
            {
                var response = _appComplianceReportEvidenceEvidenceRestClient.Get(Id.Name, evidenceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AppComplianceReportEvidenceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a paginated list of evidences for a specified report.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_ListByReport</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppComplianceReportEvidenceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AppComplianceReportEvidenceResource> GetAllAsync(AppComplianceReportEvidenceCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new AppComplianceReportEvidenceCollectionGetAllOptions();

            HttpMessage FirstPageRequest(int? pageSizeHint) => _appComplianceReportEvidenceEvidenceRestClient.CreateListByReportRequest(Id.Name, options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _appComplianceReportEvidenceEvidenceRestClient.CreateListByReportNextPageRequest(nextLink, Id.Name, options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AppComplianceReportEvidenceResource(Client, AppComplianceReportEvidenceData.DeserializeAppComplianceReportEvidenceData(e)), _appComplianceReportEvidenceEvidenceClientDiagnostics, Pipeline, "AppComplianceReportEvidenceCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Returns a paginated list of evidences for a specified report.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_ListByReport</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppComplianceReportEvidenceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AppComplianceReportEvidenceResource> GetAll(AppComplianceReportEvidenceCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new AppComplianceReportEvidenceCollectionGetAllOptions();

            HttpMessage FirstPageRequest(int? pageSizeHint) => _appComplianceReportEvidenceEvidenceRestClient.CreateListByReportRequest(Id.Name, options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _appComplianceReportEvidenceEvidenceRestClient.CreateListByReportNextPageRequest(nextLink, Id.Name, options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AppComplianceReportEvidenceResource(Client, AppComplianceReportEvidenceData.DeserializeAppComplianceReportEvidenceData(e)), _appComplianceReportEvidenceEvidenceClientDiagnostics, Pipeline, "AppComplianceReportEvidenceCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string evidenceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _appComplianceReportEvidenceEvidenceRestClient.GetAsync(Id.Name, evidenceName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> is null. </exception>
        public virtual Response<bool> Exists(string evidenceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.Exists");
            scope.Start();
            try
            {
                var response = _appComplianceReportEvidenceEvidenceRestClient.Get(Id.Name, evidenceName, cancellationToken: cancellationToken);
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
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> is null. </exception>
        public virtual async Task<NullableResponse<AppComplianceReportEvidenceResource>> GetIfExistsAsync(string evidenceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _appComplianceReportEvidenceEvidenceRestClient.GetAsync(Id.Name, evidenceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<AppComplianceReportEvidenceResource>(response.GetRawResponse());
                return Response.FromValue(new AppComplianceReportEvidenceResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences/{evidenceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-06-27</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="evidenceName"> The evidence name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="evidenceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="evidenceName"/> is null. </exception>
        public virtual NullableResponse<AppComplianceReportEvidenceResource> GetIfExists(string evidenceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(evidenceName, nameof(evidenceName));

            using var scope = _appComplianceReportEvidenceEvidenceClientDiagnostics.CreateScope("AppComplianceReportEvidenceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _appComplianceReportEvidenceEvidenceRestClient.Get(Id.Name, evidenceName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<AppComplianceReportEvidenceResource>(response.GetRawResponse());
                return Response.FromValue(new AppComplianceReportEvidenceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AppComplianceReportEvidenceResource> IEnumerable<AppComplianceReportEvidenceResource>.GetEnumerator()
        {
            return GetAll(options: null).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll(options: null).GetEnumerator();
        }

        IAsyncEnumerator<AppComplianceReportEvidenceResource> IAsyncEnumerable<AppComplianceReportEvidenceResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(options: null, cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
