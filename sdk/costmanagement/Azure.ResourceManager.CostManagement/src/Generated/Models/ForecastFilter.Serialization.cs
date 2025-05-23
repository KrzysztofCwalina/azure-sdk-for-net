// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CostManagement.Models
{
    public partial class ForecastFilter : IUtf8JsonSerializable, IJsonModel<ForecastFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ForecastFilter>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ForecastFilter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ForecastFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ForecastFilter)} does not support writing '{format}' format.");
            }

            if (Optional.IsCollectionDefined(And))
            {
                writer.WritePropertyName("and"u8);
                writer.WriteStartArray();
                foreach (var item in And)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Or))
            {
                writer.WritePropertyName("or"u8);
                writer.WriteStartArray();
                foreach (var item in Or)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Dimensions))
            {
                writer.WritePropertyName("dimensions"u8);
                writer.WriteObjectValue(Dimensions, options);
            }
            if (Optional.IsDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteObjectValue(Tags, options);
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

        ForecastFilter IJsonModel<ForecastFilter>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ForecastFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ForecastFilter)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeForecastFilter(document.RootElement, options);
        }

        internal static ForecastFilter DeserializeForecastFilter(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ForecastFilter> and = default;
            IList<ForecastFilter> or = default;
            ForecastComparisonExpression dimensions = default;
            ForecastComparisonExpression tags = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("and"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ForecastFilter> array = new List<ForecastFilter>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeForecastFilter(item, options));
                    }
                    and = array;
                    continue;
                }
                if (property.NameEquals("or"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ForecastFilter> array = new List<ForecastFilter>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeForecastFilter(item, options));
                    }
                    or = array;
                    continue;
                }
                if (property.NameEquals("dimensions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dimensions = ForecastComparisonExpression.DeserializeForecastComparisonExpression(property.Value, options);
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tags = ForecastComparisonExpression.DeserializeForecastComparisonExpression(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ForecastFilter(and ?? new ChangeTrackingList<ForecastFilter>(), or ?? new ChangeTrackingList<ForecastFilter>(), dimensions, tags, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ForecastFilter>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ForecastFilter>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerCostManagementContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ForecastFilter)} does not support writing '{options.Format}' format.");
            }
        }

        ForecastFilter IPersistableModel<ForecastFilter>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ForecastFilter>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeForecastFilter(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ForecastFilter)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ForecastFilter>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
