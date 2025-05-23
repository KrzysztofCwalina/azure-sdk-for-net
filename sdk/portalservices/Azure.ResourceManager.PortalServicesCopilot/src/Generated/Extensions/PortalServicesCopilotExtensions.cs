// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.PortalServicesCopilot.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PortalServicesCopilot
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.PortalServicesCopilot. </summary>
    public static partial class PortalServicesCopilotExtensions
    {
        private static MockablePortalServicesCopilotArmClient GetMockablePortalServicesCopilotArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockablePortalServicesCopilotArmClient(client0));
        }

        private static MockablePortalServicesCopilotTenantResource GetMockablePortalServicesCopilotTenantResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockablePortalServicesCopilotTenantResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="PortalServicesCopilotSettingResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PortalServicesCopilotSettingResource.CreateResourceIdentifier" /> to create a <see cref="PortalServicesCopilotSettingResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockablePortalServicesCopilotArmClient.GetPortalServicesCopilotSettingResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PortalServicesCopilotSettingResource"/> object. </returns>
        public static PortalServicesCopilotSettingResource GetPortalServicesCopilotSettingResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockablePortalServicesCopilotArmClient(client).GetPortalServicesCopilotSettingResource(id);
        }

        /// <summary>
        /// Gets an object representing a PortalServicesCopilotSettingResource along with the instance operations that can be performed on it in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockablePortalServicesCopilotTenantResource.GetPortalServicesCopilotSetting()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> Returns a <see cref="PortalServicesCopilotSettingResource"/> object. </returns>
        public static PortalServicesCopilotSettingResource GetPortalServicesCopilotSetting(this TenantResource tenantResource)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockablePortalServicesCopilotTenantResource(tenantResource).GetPortalServicesCopilotSetting();
        }
    }
}
