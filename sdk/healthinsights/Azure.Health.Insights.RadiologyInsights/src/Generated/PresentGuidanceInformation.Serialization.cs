// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Health.Insights.RadiologyInsights
{
    public partial class PresentGuidanceInformation : IUtf8JsonSerializable, IJsonModel<PresentGuidanceInformation>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PresentGuidanceInformation>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<PresentGuidanceInformation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PresentGuidanceInformation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PresentGuidanceInformation)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("presentGuidanceItem"u8);
            writer.WriteStringValue(PresentGuidanceItem);
            if (Optional.IsCollectionDefined(Sizes))
            {
                writer.WritePropertyName("sizes"u8);
                writer.WriteStartArray();
                foreach (var item in Sizes)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(MaximumDiameterAsInText))
            {
                writer.WritePropertyName("maximumDiameterAsInText"u8);
                writer.WriteObjectValue(MaximumDiameterAsInText, options);
            }
            if (Optional.IsCollectionDefined(PresentGuidanceValues))
            {
                writer.WritePropertyName("presentGuidanceValues"u8);
                writer.WriteStartArray();
                foreach (var item in PresentGuidanceValues)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Extension))
            {
                writer.WritePropertyName("extension"u8);
                writer.WriteStartArray();
                foreach (var item in Extension)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        PresentGuidanceInformation IJsonModel<PresentGuidanceInformation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PresentGuidanceInformation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PresentGuidanceInformation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePresentGuidanceInformation(document.RootElement, options);
        }

        internal static PresentGuidanceInformation DeserializePresentGuidanceInformation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string presentGuidanceItem = default;
            IReadOnlyList<FhirR4Observation> sizes = default;
            FhirR4Quantity maximumDiameterAsInText = default;
            IReadOnlyList<string> presentGuidanceValues = default;
            IReadOnlyList<FhirR4Extension> extension = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("presentGuidanceItem"u8))
                {
                    presentGuidanceItem = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sizes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FhirR4Observation> array = new List<FhirR4Observation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FhirR4Observation.DeserializeFhirR4Observation(item, options));
                    }
                    sizes = array;
                    continue;
                }
                if (property.NameEquals("maximumDiameterAsInText"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maximumDiameterAsInText = FhirR4Quantity.DeserializeFhirR4Quantity(property.Value, options);
                    continue;
                }
                if (property.NameEquals("presentGuidanceValues"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    presentGuidanceValues = array;
                    continue;
                }
                if (property.NameEquals("extension"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FhirR4Extension> array = new List<FhirR4Extension>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FhirR4Extension.DeserializeFhirR4Extension(item, options));
                    }
                    extension = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new PresentGuidanceInformation(
                presentGuidanceItem,
                sizes ?? new ChangeTrackingList<FhirR4Observation>(),
                maximumDiameterAsInText,
                presentGuidanceValues ?? new ChangeTrackingList<string>(),
                extension ?? new ChangeTrackingList<FhirR4Extension>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<PresentGuidanceInformation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PresentGuidanceInformation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureHealthInsightsRadiologyInsightsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PresentGuidanceInformation)} does not support writing '{options.Format}' format.");
            }
        }

        PresentGuidanceInformation IPersistableModel<PresentGuidanceInformation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PresentGuidanceInformation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializePresentGuidanceInformation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PresentGuidanceInformation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PresentGuidanceInformation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static PresentGuidanceInformation FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePresentGuidanceInformation(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
