// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using System;
using System.Text.Json;
using System.Threading;

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
                var request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/me/");
                request.Uri.Reset(new Uri(escaped));
                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var response = _pipeline.SendRequest(request, cancellationToken);

                var json = JsonDocument.Parse(response.ContentStream);
                var root = json.RootElement;

                var user = new OfficeUser();
                user.Office = root.GetProperty("officeLocation").GetString();
                user.DisplayName = root.GetProperty("displayName").GetString();
                user.Title = root.GetProperty("jobTitle").GetString();

                return Response.FromValue(user, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
