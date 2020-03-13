// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using System;
using System.Text.Json;
using System.Threading;
using id = Azure.Identity;

namespace Azure.Office.Mail
{
    /// <summary>
    /// Main type for accessing users
    /// </summary>
    public class MailClient
    {
        private readonly DefaultAzureCredential _credential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        public MailClient(string username) : this(username, new OfficeClientOptions())
        {
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        /// <param name="options">Client options</param>
        public MailClient(string username, OfficeClientOptions options)
        {
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(options, nameof(options));

            var credentialOptions = new DefaultAzureCredentialOptions();
            credentialOptions.SharedTokenCacheUsername = username;
            _credential = new DefaultAzureCredential(credentialOptions);
            _pipeline = HttpPipelineBuilder.Build(options);

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        internal MailClient(HttpPipeline pipeline, DefaultAzureCredential credential, ClientDiagnostics clientDiagnostics)
        {
            _credential = credential;
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
        /// <param name="subject">Subject</param>
        /// <param name="message">Message</param>
        /// <param name="to"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Response Send(string subject, string message, string to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MailClient)}.{nameof(Send)}");
            scope.Start();

            try
            {
                var request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/me/sendMail");
                request.Uri.Reset(new Uri(escaped));
                request.Headers.Add(HttpHeader.Common.JsonContentType);
                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var writer = new Core.ArrayBufferWriter<byte>();
                var jsonWriter = new Utf8JsonWriter(writer);
                jsonWriter.WriteStartObject();
                jsonWriter.WriteStartObject("message");
                jsonWriter.WriteString("subject", subject);
                jsonWriter.WriteStartObject("body");
                jsonWriter.WriteString("contentType", "Text");
                jsonWriter.WriteString("content", message);
                jsonWriter.WriteEndObject(); // body

                jsonWriter.WriteStartArray("toRecipients");
                jsonWriter.WriteStartObject();
                jsonWriter.WriteStartObject("emailAddress");
                jsonWriter.WriteString("address", to);
                jsonWriter.WriteEndObject(); // emailAddress
                jsonWriter.WriteEndObject(); // toRecipient
                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject(); // message
                jsonWriter.WriteEndObject(); // root
                jsonWriter.Flush();
                var jsonBytes = writer.WrittenMemory;

                request.Content = RequestContent.Create(jsonBytes);

                var response = _pipeline.SendRequest(request, CancellationToken.None);

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
    }
}
