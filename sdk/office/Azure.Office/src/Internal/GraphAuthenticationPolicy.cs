// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Graph.Internal
{
    internal enum GraphPermission : int
    {
        CalendarsRead,
        MailSend,
        UserRead,
        UserReadAll,
    }

    internal class GraphAuthenticationPolicy : HttpPipelinePolicy
    {
        private static readonly string[] s_permissionStrings = new string[]
        {
            "Calendars.Read",
            "Mail.Send",
            "User.Read",
            "User.Read.All"
        };

        // TODO: this is a bit of a hack
        private static ConcurrentDictionary<string, AccessToken> s_cache = new ConcurrentDictionary<string, AccessToken>();

        private const string ScopesProperty = "GraphAuthenticationPolicy.Scopes";

        private TokenCredential _credential;

        public GraphAuthenticationPolicy(TokenCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        public static void RequestPermissions(HttpMessage message, GraphPermission permission)
        {
            message.SetProperty(ScopesProperty, s_permissionStrings[(int)permission]);
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc />
        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            if (!message.TryGetProperty(ScopesProperty, out var scopeObject))
            {
                throw new InvalidOperationException("HttpMessage does not contain GraphBearerTokenPolicy.Scopes property");
            }

            var scope = scopeObject as string;
            if (scope == null)
            {
                throw new InvalidOperationException("HttpMessage GraphBearerTokenPolicy.Scopes property is not a string");
            }

            AccessToken token;
            while (true)
            {
                if (!s_cache.TryGetValue(scope, out token))
                {
                    var scopes = new string[] { "https://graph.microsoft.com/" + scope };
                    token = async ?
                        await _credential.GetTokenAsync(new TokenRequestContext(scopes, message.Request.ClientRequestId), message.CancellationToken).ConfigureAwait(false) :
                        _credential.GetToken(new TokenRequestContext(scopes, message.Request.ClientRequestId), message.CancellationToken);

                    s_cache.TryAdd(scope, token);
                }
                if (token.ExpiresOn > DateTimeOffset.UtcNow)
                {
                    break;
                }
            }

            message.Request.Headers.Add(HttpHeader.Names.Authorization, "Bearer " + token.Token);

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }
    }
}
