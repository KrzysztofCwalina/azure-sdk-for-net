// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkTapRuleAction : IUtf8JsonSerializable, IJsonModel<NetworkTapRuleAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<NetworkTapRuleAction>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<NetworkTapRuleAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkTapRuleAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkTapRuleAction)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(TapRuleActionType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(TapRuleActionType.Value.ToString());
            }
            if (Optional.IsDefined(Truncate))
            {
                writer.WritePropertyName("truncate"u8);
                writer.WriteStringValue(Truncate);
            }
            if (Optional.IsDefined(IsTimestampEnabled))
            {
                writer.WritePropertyName("isTimestampEnabled"u8);
                writer.WriteStringValue(IsTimestampEnabled.Value.ToString());
            }
            if (Optional.IsDefined(DestinationId))
            {
                writer.WritePropertyName("destinationId"u8);
                writer.WriteStringValue(DestinationId);
            }
            if (Optional.IsDefined(MatchConfigurationName))
            {
                writer.WritePropertyName("matchConfigurationName"u8);
                writer.WriteStringValue(MatchConfigurationName);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        NetworkTapRuleAction IJsonModel<NetworkTapRuleAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkTapRuleAction>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkTapRuleAction)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkTapRuleAction(document.RootElement, options);
        }

        internal static NetworkTapRuleAction DeserializeNetworkTapRuleAction(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            TapRuleActionType? type = default;
            string truncate = default;
            NetworkFabricBooleanValue? isTimestampEnabled = default;
            ResourceIdentifier destinationId = default;
            string matchConfigurationName = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new TapRuleActionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("truncate"u8))
                {
                    truncate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isTimestampEnabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isTimestampEnabled = new NetworkFabricBooleanValue(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("destinationId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    destinationId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("matchConfigurationName"u8))
                {
                    matchConfigurationName = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new NetworkTapRuleAction(
                type,
                truncate,
                isTimestampEnabled,
                destinationId,
                matchConfigurationName,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<NetworkTapRuleAction>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkTapRuleAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkTapRuleAction)} does not support writing '{options.Format}' format.");
            }
        }

        NetworkTapRuleAction IPersistableModel<NetworkTapRuleAction>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<NetworkTapRuleAction>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeNetworkTapRuleAction(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkTapRuleAction)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<NetworkTapRuleAction>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
