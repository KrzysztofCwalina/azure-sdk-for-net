// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Office.Mail;
using Azure.Office.Users;
using System;
using System.ComponentModel;
using System.Threading;

namespace Azure.Office
{
    /// <summary>
    /// Microsoft Graph Client
    /// </summary>
    public class OfficeClient
    {
        private readonly DefaultAzureCredential _credential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        public OfficeClient(string username) : this(username, new OfficeClientOptions())
        {
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <param name="username">Graph user</param>
        /// <param name="options">Client options</param>
        public OfficeClient(string username, OfficeClientOptions options)
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
        /// Constructor for mocking
        /// </summary>
        protected OfficeClient() { }

        /// <summary>
        /// Creates UserClient.
        /// </summary>
        /// <returns></returns>
        public UserClient GetUserClient()
        {
            return new UserClient(_pipeline, _credential, _clientDiagnostics);
        }

        /// <summary>
        /// Creates MailClient.
        /// </summary>
        /// <returns></returns>
        public MailClient GetMailClient()
        {
            return new MailClient(_pipeline, _credential, _clientDiagnostics);
        }

        internal static void AddAuthHeader(DefaultAzureCredential credential, Request request, CancellationToken cancellationToken)
        {
            TokenRequestContext ctx = new TokenRequestContext(new string[] { "https://graph.microsoft.com/.default" });
            AccessToken t = credential.GetToken(ctx, cancellationToken);
            request.Headers.Add(HttpHeader.Names.Authorization, "Bearer " + t.Token);
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
