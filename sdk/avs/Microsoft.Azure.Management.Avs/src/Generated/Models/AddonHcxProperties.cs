// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Avs.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The properties of an HCX addon
    /// </summary>
    [Newtonsoft.Json.JsonObject("HCX")]
    public partial class AddonHcxProperties : AddonProperties
    {
        /// <summary>
        /// Initializes a new instance of the AddonHcxProperties class.
        /// </summary>
        public AddonHcxProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AddonHcxProperties class.
        /// </summary>
        /// <param name="offer">The HCX offer, example VMware MaaS Cloud
        /// Provider (Enterprise)</param>
        /// <param name="provisioningState">The state of the addon
        /// provisioning. Possible values include: 'Succeeded', 'Failed',
        /// 'Cancelled', 'Building', 'Deleting', 'Updating'</param>
        public AddonHcxProperties(string offer, string provisioningState = default(string))
            : base(provisioningState)
        {
            Offer = offer;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the HCX offer, example VMware MaaS Cloud Provider
        /// (Enterprise)
        /// </summary>
        [JsonProperty(PropertyName = "offer")]
        public string Offer { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Offer == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Offer");
            }
        }
    }
}
