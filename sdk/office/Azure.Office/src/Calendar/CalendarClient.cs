// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Graph.Internal;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;

namespace Azure.Graph.Calendar
{
    /// <summary>
    /// Main type for accessing calendar
    /// </summary>
    public class CalendarClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="credential">credential</param>
        public CalendarClient(TokenCredential credential) : this(credential, new GraphClientOptions())
        {
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="credential">credential</param>
        /// <param name="options">Client options</param>
        public CalendarClient(TokenCredential credential, GraphClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _pipeline = GraphClient.CreatePipeline(credential, options);
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        internal CalendarClient(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
        {
            Debug.Assert(pipeline != null);
            Debug.Assert(clientDiagnostics != null);

            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected CalendarClient() { }


        /// <summary>
        /// Gets list of events.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0106:Non-public asynchronous method needs 'async' parameter.", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0102:Do not use GetAwaiter().GetResult().", Justification = "<Pending>")]
        public Pageable<CalendarEvent> GetEvents(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CalendarClient)}.{nameof(GetEvents)}");
            scope.Start();

            try
            {
                using HttpMessage message = _pipeline.CreateMessage();
                GraphAuthenticationPolicy.RequestPermissions(message, GraphPermission.CalendarsRead);

                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri(@"https://graph.microsoft.com/v1.0/me/events"));

                _pipeline.Send(message, cancellationToken);

                var response = message.Response;

                switch (response.Status)
                {
                    case 200:
                        var json = JsonDocument.Parse(response.ContentStream);
                        var root = json.RootElement;
                        return null;
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
