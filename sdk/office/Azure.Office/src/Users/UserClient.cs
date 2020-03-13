// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

// TODO: support OData queries: https://docs.microsoft.com/en-us/graph/api/user-get?view=graph-rest-1.0&tabs=http#optional-query-parameters

namespace Azure.Office.Users
{
    /// <summary>
    /// Main type for sending and receiving e-mail.
    /// </summary>
    public class UserClient
    {
        private readonly DefaultAzureCredential _credential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates UserClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        public UserClient(string username) : this(username, new OfficeClientOptions())
        {
        }

        /// <summary>
        /// Creates UserClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        /// <param name="options">Client options</param>
        public UserClient(string username, OfficeClientOptions options)
        {
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(options, nameof(options));

            var credentialOptions = new DefaultAzureCredentialOptions();
            credentialOptions.SharedTokenCacheUsername = username;
            _credential = new DefaultAzureCredential(credentialOptions);
            _pipeline = HttpPipelineBuilder.Build(options);

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        internal UserClient(HttpPipeline pipeline, DefaultAzureCredential credential, ClientDiagnostics clientDiagnostics)
        {
            _credential = credential;
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected UserClient()
        { }

        /// <summary>
        /// Gets information about current graph user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response<OfficeUser> GetMe(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(UserClient)}.{nameof(GetMe)}");
            scope.Start();

            try
            {
                using Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/me/");
                request.Uri.Reset(new Uri(escaped));
                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        OfficeUser user = OfficeUser.Deserialize(response.ContentStream);
                        return Response.FromValue(user, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about current graph user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="principalOrId">User principal name or use ID</param>
        /// <returns></returns>
        public Response<OfficeUser> GetUser(string principalOrId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(UserClient)}.{nameof(GetUser)}");
            scope.Start();

            try
            {
                using Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/users/");
                request.Uri.Reset(new Uri(escaped));
                request.Uri.AppendPath(principalOrId, escape: true);
                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        OfficeUser user = OfficeUser.Deserialize(response.ContentStream);
                        return Response.FromValue(user, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }

            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about current graph user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response GetPhoto(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(UserClient)}.{nameof(GetPhoto)}");
            scope.Start();

            try
            {
                using Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/me/photo/$value");
                request.Uri.Reset(new Uri(escaped));
                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return response;
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets photo of a user.
        /// </summary>
        /// <param name="principalOrId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response GetPhoto(string principalOrId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(UserClient)}.{nameof(GetPhoto)}");
            scope.Start();

            try
            {
                using Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;

                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/users/");
                request.Uri.Reset(new Uri(escaped));
                request.Uri.AppendPath(principalOrId, escape: true);
                request.Uri.AppendPath("/photo/$value");

                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return response;
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #region nobody wants to see these
        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Creates a Key Value string in reference to the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
