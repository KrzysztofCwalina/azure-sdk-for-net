// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Graph.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;


namespace Azure.Graph.Users
{
    /// <summary>
    /// Main type for sending and receiving e-mail.
    /// </summary>
    public static class GraphUsersExtensions
    {
        private class O : ClientOptions {}

        // TODO: can we not use statics?
        private static readonly ClientDiagnostics s_clientDiagnostics = new ClientDiagnostics(new O());

        /// <summary>
        /// Creates request to get users
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="principalOrId"></param>
        /// <returns></returns>
        public static PipelineRequest CreateGetUserRequest(this HttpPipeline pipeline, string principalOrId)
        {
            HttpMessage message = pipeline.CreateMessage();
            GraphAuthenticationPolicy.RequestPermissions(message, GraphPermission.UserReadAll);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(@"https://graph.microsoft.com/v1.0/users/"));
            request.Uri.AppendPath(principalOrId, escape: true);

            return new PipelineRequest(pipeline, message);
        }

        /// <summary>
        /// Deserializes user
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static GraphUser ToGraphUser(this Response response)
        {
            switch (response.Status)
            {
                case 200:
                    GraphUser user = GraphUser.Deserialize(response.ContentStream);
                    return Response.FromValue(user, response);
                default:
                    throw s_clientDiagnostics.CreateRequestFailedException(response);
            }
        }
    }

    /// <summary>
    /// Pipleine Message
    /// </summary>
    public readonly struct PipelineRequest
    {
        private readonly HttpMessage _message;
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Creates PipelineMessage
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="message"></param>
        public PipelineRequest(HttpPipeline pipeline, HttpMessage message)
        {
            _pipeline = pipeline;
            _message = message;
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response Send(CancellationToken cancellationToken = default)
        {
            _pipeline.Send(_message, cancellationToken);
            return _message.Response;
        }

        /// <summary>
        /// Request
        /// </summary>
        public Request Request => _message.Request;
    }
}
