// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Office
{
    /// <summary>
    /// Options for MailClient
    /// </summary>
    public class OfficeClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V1;

        /// <summary>
        /// Options for MailCVlient
        /// </summary>
        /// <param name="version"></param>
        public OfficeClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        internal ServiceVersion Version { get; }

        /// <summary>
        /// Name of the Graph user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// MailClient version #
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// First Version
            /// </summary>
            V1 = 1,
        }
    }
}
