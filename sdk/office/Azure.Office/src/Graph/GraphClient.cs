// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Graph.Calendar;
using Azure.Graph.Mail;
using Azure.Graph.Users;
using System;
using System.ComponentModel;
using Azure.Graph.Internal;

namespace Azure.Graph
{
    /// <summary>
    /// Microsoft Graph Client
    /// </summary>
    public class GraphClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="credential"></param>
        public GraphClient(TokenCredential credential) : this(credential, new GraphClientOptions())
        {
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="credential">credential</param>
        /// <param name="options">Client options</param>
        public GraphClient(TokenCredential credential, GraphClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _pipeline = CreatePipeline(credential, options);
            _clientDiagnostics = new ClientDiagnostics(options);
        }

        internal static HttpPipeline CreatePipeline(TokenCredential credential, GraphClientOptions options)
        {
            var policy = new GraphAuthenticationPolicy(credential);
            var pipeline = HttpPipelineBuilder.Build(options, policy);

            return pipeline;
        }

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected GraphClient() { }

        /// <summary>
        /// Creates UserClient.
        /// </summary>
        /// <returns></returns>
        public GraphUserClient GetUserClient()
        {
            return new GraphUserClient(_pipeline, _clientDiagnostics);
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <returns></returns>
        public MailClient GetMailClient()
        {
            return new MailClient(_pipeline, _clientDiagnostics);
        }

        /// <summary>
        /// Creates CalendarClient.
        /// </summary>
        /// <returns></returns>
        public CalendarClient GetCalendarClient()
        {
            return new CalendarClient(_pipeline, _clientDiagnostics);
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
