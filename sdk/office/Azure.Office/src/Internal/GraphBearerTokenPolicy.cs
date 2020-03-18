using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Graph.Internal
{
        internal class GraphBearerTokenPolicy : HttpPipelinePolicy
        {
            private TokenCredential _credential;

            public GraphBearerTokenPolicy(TokenCredential credential)
            {
                Argument.AssertNotNull(credential, nameof(credential));
                _credential = credential;
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

                if (!message.TryGetProperty("GraphBearerTokenPolicy.Scopes", out var scopesObject))
                {
                    throw new InvalidOperationException("HttpMessage does not contain GraphBearerTokenPolicy.Scopes property");
                }

                var scopes = scopesObject as string[];
                if (scopes == null)
                {
                    throw new InvalidOperationException("HttpMessage GraphBearerTokenPolicy.Scopes property is not string[]");
                }

                AccessToken token = async ?
                    await _credential.GetTokenAsync(new TokenRequestContext(scopes, message.Request.ClientRequestId), message.CancellationToken).ConfigureAwait(false) :
                    _credential.GetToken(new TokenRequestContext(scopes, message.Request.ClientRequestId), message.CancellationToken);

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
}
