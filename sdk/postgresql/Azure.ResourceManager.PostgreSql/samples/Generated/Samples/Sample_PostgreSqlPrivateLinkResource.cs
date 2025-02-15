// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.PostgreSql.Samples
{
    public partial class Sample_PostgreSqlPrivateLinkResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetsAPrivateLinkResourceForPostgreSQL()
        {
            // Generated from example definition: specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2018-06-01/examples/PrivateLinkResourcesGet.json
            // this example is just showing the usage of "PrivateLinkResources_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this PostgreSqlPrivateLinkResource created on azure
            // for more information of creating PostgreSqlPrivateLinkResource, please refer to the document of PostgreSqlPrivateLinkResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "Default";
            string serverName = "test-svr";
            string groupName = "plr";
            ResourceIdentifier postgreSqlPrivateLinkResourceId = PostgreSqlPrivateLinkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, groupName);
            PostgreSqlPrivateLinkResource postgreSqlPrivateLinkResource = client.GetPostgreSqlPrivateLinkResource(postgreSqlPrivateLinkResourceId);

            // invoke the operation
            PostgreSqlPrivateLinkResource result = await postgreSqlPrivateLinkResource.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            PostgreSqlPrivateLinkResourceData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
