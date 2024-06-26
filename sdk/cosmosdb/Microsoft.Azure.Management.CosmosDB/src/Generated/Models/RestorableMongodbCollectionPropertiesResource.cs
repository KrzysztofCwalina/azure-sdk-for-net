// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The resource of an Azure Cosmos DB MongoDB collection event
    /// </summary>
    public partial class RestorableMongodbCollectionPropertiesResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// RestorableMongodbCollectionPropertiesResource class.
        /// </summary>
        public RestorableMongodbCollectionPropertiesResource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// RestorableMongodbCollectionPropertiesResource class.
        /// </summary>
        /// <param name="_rid">A system generated property. A unique
        /// identifier.</param>
        /// <param name="operationType">The operation type of this collection
        /// event. Possible values include: 'Create', 'Replace', 'Delete',
        /// 'Recreate', 'SystemOperation'</param>
        /// <param name="eventTimestamp">The time when this collection event
        /// happened.</param>
        /// <param name="ownerId">The name of this MongoDB collection.</param>
        /// <param name="ownerResourceId">The resource ID of this MongoDB
        /// collection.</param>
        public RestorableMongodbCollectionPropertiesResource(string _rid = default(string), string operationType = default(string), string eventTimestamp = default(string), string ownerId = default(string), string ownerResourceId = default(string))
        {
            this._rid = _rid;
            OperationType = operationType;
            EventTimestamp = eventTimestamp;
            OwnerId = ownerId;
            OwnerResourceId = ownerResourceId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        [JsonProperty(PropertyName = "_rid")]
        public string _rid { get; private set; }

        /// <summary>
        /// Gets the operation type of this collection event. Possible values
        /// include: 'Create', 'Replace', 'Delete', 'Recreate',
        /// 'SystemOperation'
        /// </summary>
        [JsonProperty(PropertyName = "operationType")]
        public string OperationType { get; private set; }

        /// <summary>
        /// Gets the time when this collection event happened.
        /// </summary>
        [JsonProperty(PropertyName = "eventTimestamp")]
        public string EventTimestamp { get; private set; }

        /// <summary>
        /// Gets the name of this MongoDB collection.
        /// </summary>
        [JsonProperty(PropertyName = "ownerId")]
        public string OwnerId { get; private set; }

        /// <summary>
        /// Gets the resource ID of this MongoDB collection.
        /// </summary>
        [JsonProperty(PropertyName = "ownerResourceId")]
        public string OwnerResourceId { get; private set; }

    }
}
