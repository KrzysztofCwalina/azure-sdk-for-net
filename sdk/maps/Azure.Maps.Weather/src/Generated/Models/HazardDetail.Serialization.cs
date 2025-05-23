// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Maps.Common;

namespace Azure.Maps.Weather.Models
{
    public partial class HazardDetail
    {
        internal static HazardDetail DeserializeHazardDetail(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HazardIndex? hazardIndex = default;
            string hazardCode = default;
            string shortPhrase = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hazardIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hazardIndex = new HazardIndex(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("hazardCode"u8))
                {
                    hazardCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("shortPhrase"u8))
                {
                    shortPhrase = property.Value.GetString();
                    continue;
                }
            }
            return new HazardDetail(hazardIndex, hazardCode, shortPhrase);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static HazardDetail FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeHazardDetail(document.RootElement);
        }
    }
}
