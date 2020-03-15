// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;

namespace Azure.Graph.Mail
{
    /// <summary>
    /// Main type for e-mail.
    /// </summary>
    public class MailClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        public MailClient(string username) : this(username, new GraphClientOptions())
        {
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        /// <param name="options">Client options</param>
        public MailClient(string username, GraphClientOptions options)
        {
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(options, nameof(options));

            _pipeline = GraphClient.CreatePipeline(username, options);
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        internal MailClient(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            Debug.Assert(pipeline != null);
            Debug.Assert(clientDiagnostics != null);

            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected MailClient() { }

        /// <summary>
        /// Sends e-mail
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response Send(MailMessage message, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MailClient)}.{nameof(Send)}");
            scope.Start();

            try
            {
                using Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/me/sendMail");
                request.Uri.Reset(new Uri(escaped));
                request.Headers.Add(HttpHeader.Common.JsonContentType);

                var writer = new Core.ArrayBufferWriter<byte>();
                var jsonWriter = new Utf8JsonWriter(writer);
                message.Serialize(jsonWriter);
                var jsonBytes = writer.WrittenMemory;

                request.Content = RequestContent.Create(jsonBytes);

                var response = _pipeline.SendRequest(request, cancellationToken);

                var json = JsonDocument.Parse(response.ContentStream);
                var root = json.RootElement;

                return response;
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
