// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetworkAnalytics.Models
{
    public partial class DataProductDataType : IUtf8JsonSerializable, IJsonModel<DataProductDataType>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataProductDataType>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DataProductDataType>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataProductDataType>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataProductDataType)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (Optional.IsDefined(State))
            {
                writer.WritePropertyName("state"u8);
                writer.WriteStringValue(State.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(StateReason))
            {
                writer.WritePropertyName("stateReason"u8);
                writer.WriteStringValue(StateReason);
            }
            if (Optional.IsDefined(StorageOutputRetention))
            {
                writer.WritePropertyName("storageOutputRetention"u8);
                writer.WriteNumberValue(StorageOutputRetention.Value);
            }
            if (Optional.IsDefined(DatabaseCacheRetention))
            {
                writer.WritePropertyName("databaseCacheRetention"u8);
                writer.WriteNumberValue(DatabaseCacheRetention.Value);
            }
            if (Optional.IsDefined(DatabaseRetention))
            {
                writer.WritePropertyName("databaseRetention"u8);
                writer.WriteNumberValue(DatabaseRetention.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(VisualizationUri))
            {
                writer.WritePropertyName("visualizationUrl"u8);
                writer.WriteStringValue(VisualizationUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        DataProductDataType IJsonModel<DataProductDataType>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataProductDataType>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataProductDataType)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataProductDataType(document.RootElement, options);
        }

        internal static DataProductDataType DeserializeDataProductDataType(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            NetworkAnalyticsProvisioningState? provisioningState = default;
            DataProductDataTypeState? state = default;
            string stateReason = default;
            int? storageOutputRetention = default;
            int? databaseCacheRetention = default;
            int? databaseRetention = default;
            Uri visualizationUrl = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkAnalyticsContext.Default);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new NetworkAnalyticsProvisioningState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("state"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            state = new DataProductDataTypeState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("stateReason"u8))
                        {
                            stateReason = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("storageOutputRetention"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            storageOutputRetention = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("databaseCacheRetention"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            databaseCacheRetention = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("databaseRetention"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            databaseRetention = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("visualizationUrl"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            visualizationUrl = new Uri(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DataProductDataType(
                id,
                name,
                type,
                systemData,
                provisioningState,
                state,
                stateReason,
                storageOutputRetention,
                databaseCacheRetention,
                databaseRetention,
                visualizationUrl,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DataProductDataType>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataProductDataType>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNetworkAnalyticsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DataProductDataType)} does not support writing '{options.Format}' format.");
            }
        }

        DataProductDataType IPersistableModel<DataProductDataType>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataProductDataType>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDataProductDataType(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DataProductDataType)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DataProductDataType>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
