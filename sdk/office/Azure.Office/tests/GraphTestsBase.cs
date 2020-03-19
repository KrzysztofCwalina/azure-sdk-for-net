// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;

namespace Azure.Graph.Tests
{
    public class GraphTestsBase
    {
        public TokenCredential CreateCredential()
        {
            string tenantId = "4f22bdd2-a5d3-4de9-80dd-0572fc5b1975";
            string applicationId = "d26c9a14-df21-40d9-9bd8-9554c8d66393";
            var credential = new InteractiveBrowserCredential(tenantId, applicationId);
            return credential;
        }
    }
}
