// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;

namespace Azure.Office.Calendar
{
    /// <summary>
    /// Main type for accessing calendar
    /// </summary>
    public class CalendarClient
    {
        private readonly DefaultAzureCredential _credential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        public CalendarClient(string username) : this(username, new OfficeClientOptions())
        {
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        /// <param name="options">Client options</param>
        public CalendarClient(string username, OfficeClientOptions options)
        {
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(options, nameof(options));

            var credentialOptions = new DefaultAzureCredentialOptions();
            credentialOptions.SharedTokenCacheUsername = username;
            _credential = new DefaultAzureCredential(credentialOptions);
            _pipeline = HttpPipelineBuilder.Build(options);

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Gets list of events.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Pageable<CalendarEvent> GetEvents(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CalendarClient)}.{nameof(GetEvents)}");
            scope.Start();

            try
            {
                using Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                var escaped = Uri.EscapeUriString(@"https://graph.microsoft.com/v1.0/me/events");
                request.Uri.Reset(new Uri(escaped));
                OfficeClient.AddAuthHeader(_credential, request, cancellationToken);

                var response = _pipeline.SendRequest(request, CancellationToken.None);

                var json = JsonDocument.Parse(response.ContentStream);
                var root = json.RootElement;

                throw new NotImplementedException(); // TODO: implement
                //return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal CalendarClient(HttpPipeline pipeline, DefaultAzureCredential credential, ClientDiagnostics clientDiagnostics)
        {
            _credential = credential;
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected CalendarClient() { }

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
