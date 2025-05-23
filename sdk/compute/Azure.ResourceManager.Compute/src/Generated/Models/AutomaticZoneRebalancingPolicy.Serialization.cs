// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class AutomaticZoneRebalancingPolicy : IUtf8JsonSerializable, IJsonModel<AutomaticZoneRebalancingPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AutomaticZoneRebalancingPolicy>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<AutomaticZoneRebalancingPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticZoneRebalancingPolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AutomaticZoneRebalancingPolicy)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (Optional.IsDefined(RebalanceStrategy))
            {
                writer.WritePropertyName("rebalanceStrategy"u8);
                writer.WriteStringValue(RebalanceStrategy.Value.ToString());
            }
            if (Optional.IsDefined(RebalanceBehavior))
            {
                writer.WritePropertyName("rebalanceBehavior"u8);
                writer.WriteStringValue(RebalanceBehavior.Value.ToString());
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

        AutomaticZoneRebalancingPolicy IJsonModel<AutomaticZoneRebalancingPolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticZoneRebalancingPolicy>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AutomaticZoneRebalancingPolicy)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAutomaticZoneRebalancingPolicy(document.RootElement, options);
        }

        internal static AutomaticZoneRebalancingPolicy DeserializeAutomaticZoneRebalancingPolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? enabled = default;
            VmssRebalanceStrategy? rebalanceStrategy = default;
            VmssRebalanceBehavior? rebalanceBehavior = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("rebalanceStrategy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebalanceStrategy = new VmssRebalanceStrategy(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("rebalanceBehavior"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebalanceBehavior = new VmssRebalanceBehavior(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AutomaticZoneRebalancingPolicy(enabled, rebalanceStrategy, rebalanceBehavior, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AutomaticZoneRebalancingPolicy>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticZoneRebalancingPolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerComputeContext.Default);
                default:
                    throw new FormatException($"The model {nameof(AutomaticZoneRebalancingPolicy)} does not support writing '{options.Format}' format.");
            }
        }

        AutomaticZoneRebalancingPolicy IPersistableModel<AutomaticZoneRebalancingPolicy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AutomaticZoneRebalancingPolicy>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeAutomaticZoneRebalancingPolicy(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AutomaticZoneRebalancingPolicy)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AutomaticZoneRebalancingPolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
