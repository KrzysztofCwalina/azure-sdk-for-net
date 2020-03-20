// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Azure.Graph.Tests
{
    public class GraphTestsBase
    {
        public enum Mode
        {
            Dcc,
            Dac,
            Ibc,
        }

        public static Mode Authentication = Mode.Ibc;

        public TokenCredential CreateCredential()
        {
            string tenantId = "4f22bdd2-a5d3-4de9-80dd-0572fc5b1975";
            string clientId = "d26c9a14-df21-40d9-9bd8-9554c8d66393";
            string username = "meganb@M365x955187.onmicrosoft.com";

            switch (Authentication)
            {
                case Mode.Ibc:
                    var credential = new InteractiveBrowserCredential(tenantId, clientId);
                    return credential;

                case Mode.Dcc:
                    var tco = new TokenCredentialOptions();

                    Func<DeviceCodeInfo, CancellationToken, Task> func = (dci, ct) =>
                    {
                        return Task.CompletedTask;
                    };

                    var dcc = new DeviceCodeCredential(func, tenantId, clientId, tco);
                    return dcc;

                case Mode.Dac:
                    var daco = new DefaultAzureCredentialOptions();
                    daco.SharedTokenCacheUsername = username;
                    daco.SharedTokenCacheTenantId = tenantId;
                    daco.ManagedIdentityClientId = clientId;
                    daco.ExcludeInteractiveBrowserCredential = true;
                    daco.ExcludeEnvironmentCredential = true;

                    var dac = new DefaultAzureCredential(daco);
                    return dac;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
