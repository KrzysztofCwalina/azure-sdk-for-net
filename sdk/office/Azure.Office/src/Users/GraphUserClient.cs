// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Graph.Internal;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

// TODO: support OData queries: https://docs.microsoft.com/en-us/graph/api/user-get?view=graph-rest-1.0&tabs=http#optional-query-parameters

namespace Azure.Graph.Users
{
    /// <summary>
    /// Main type for sending and receiving e-mail.
    /// </summary>
    public class GraphUserClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates UserClient.
        /// </summary>
        /// <param name="credential">credential</param>
        public GraphUserClient(TokenCredential credential) : this(credential, new GraphClientOptions())
        {
        }

        /// <summary>
        /// Creates UserClient.
        /// </summary>
        /// <param name="credential">credential</param>
        /// <param name="options">Client options</param>
        public GraphUserClient(TokenCredential credential, GraphClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _pipeline = GraphClient.CreatePipeline(credential, options);
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        internal GraphUserClient(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            Debug.Assert(pipeline != null);
            Debug.Assert(clientDiagnostics != null);

            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected GraphUserClient()
        { }

        /// <summary>
        /// Gets information about current graph user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response<GraphUser> GetMe(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(GraphUserClient)}.{nameof(GetMe)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                GraphAuthenticationPolicy.RequestPermissions(message, GraphPermissions.UserRead);

                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri(@"https://graph.microsoft.com/v1.0/me/"));

                _pipeline.Send(message, cancellationToken);

                var response = message.Response;
                switch (response.Status)
                {
                    case 200:
                        GraphUser user = GraphUser.Deserialize(response.ContentStream);
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
        public Response<GraphUser> GetUser(string principalOrId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(GraphUserClient)}.{nameof(GetUser)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                GraphAuthenticationPolicy.RequestPermissions(message, GraphPermissions.UserReadAll);

                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri(@"https://graph.microsoft.com/v1.0/users/"));
                request.Uri.AppendPath(principalOrId, escape: true);

                _pipeline.Send(message, cancellationToken);

                var response = message.Response;

                switch (response.Status)
                {
                    case 200:
                        GraphUser user = GraphUser.Deserialize(response.ContentStream);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(GraphUserClient)}.{nameof(GetPhoto)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                GraphAuthenticationPolicy.RequestPermissions(message, GraphPermissions.UserRead);

                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri(@"https://graph.microsoft.com/v1.0/me/photo/$value"));

                _pipeline.Send(message, cancellationToken);

                var response = message.Response;

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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(GraphUserClient)}.{nameof(GetPhoto)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                GraphAuthenticationPolicy.RequestPermissions(message, GraphPermissions.UserReadAll);

                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri(@"https://graph.microsoft.com/v1.0/users/"));
                request.Uri.AppendPath(principalOrId, escape: true);
                request.Uri.AppendPath("/photo/$value");

                _pipeline.Send(message, cancellationToken);

                var response = message.Response;

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
