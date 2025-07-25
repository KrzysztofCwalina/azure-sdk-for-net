// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace Client.AlternateApiVersion.Service.Header
{
    public partial class HeaderClient
    {
        protected HeaderClient() => throw null;

        public HeaderClient(string version) : this(new Uri("http://localhost:3000"), version, new HeaderClientOptions()) => throw null;

        public HeaderClient(Uri endpoint, string version, HeaderClientOptions options) => throw null;

        public virtual HttpPipeline Pipeline => throw null;

        public virtual Response HeaderApiVersion(RequestContext context) => throw null;

        public virtual Task<Response> HeaderApiVersionAsync(RequestContext context) => throw null;

        public virtual Response HeaderApiVersion(CancellationToken cancellationToken = default) => throw null;

        public virtual Task<Response> HeaderApiVersionAsync(CancellationToken cancellationToken = default) => throw null;
    }
}
