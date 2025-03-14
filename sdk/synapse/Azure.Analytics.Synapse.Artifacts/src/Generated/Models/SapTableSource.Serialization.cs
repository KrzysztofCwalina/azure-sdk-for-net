// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    [JsonConverter(typeof(SapTableSourceConverter))]
    public partial class SapTableSource : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(RowCount))
            {
                writer.WritePropertyName("rowCount"u8);
                writer.WriteObjectValue<object>(RowCount);
            }
            if (Optional.IsDefined(RowSkips))
            {
                writer.WritePropertyName("rowSkips"u8);
                writer.WriteObjectValue<object>(RowSkips);
            }
            if (Optional.IsDefined(RfcTableFields))
            {
                writer.WritePropertyName("rfcTableFields"u8);
                writer.WriteObjectValue<object>(RfcTableFields);
            }
            if (Optional.IsDefined(RfcTableOptions))
            {
                writer.WritePropertyName("rfcTableOptions"u8);
                writer.WriteObjectValue<object>(RfcTableOptions);
            }
            if (Optional.IsDefined(BatchSize))
            {
                writer.WritePropertyName("batchSize"u8);
                writer.WriteObjectValue<object>(BatchSize);
            }
            if (Optional.IsDefined(CustomRfcReadTableFunctionModule))
            {
                writer.WritePropertyName("customRfcReadTableFunctionModule"u8);
                writer.WriteObjectValue<object>(CustomRfcReadTableFunctionModule);
            }
            if (Optional.IsDefined(SapDataColumnDelimiter))
            {
                writer.WritePropertyName("sapDataColumnDelimiter"u8);
                writer.WriteObjectValue<object>(SapDataColumnDelimiter);
            }
            if (Optional.IsDefined(PartitionOption))
            {
                writer.WritePropertyName("partitionOption"u8);
                writer.WriteObjectValue<object>(PartitionOption);
            }
            if (Optional.IsDefined(PartitionSettings))
            {
                writer.WritePropertyName("partitionSettings"u8);
                writer.WriteObjectValue(PartitionSettings);
            }
            if (Optional.IsDefined(QueryTimeout))
            {
                writer.WritePropertyName("queryTimeout"u8);
                writer.WriteObjectValue<object>(QueryTimeout);
            }
            if (Optional.IsDefined(AdditionalColumns))
            {
                writer.WritePropertyName("additionalColumns"u8);
                writer.WriteObjectValue<object>(AdditionalColumns);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            if (Optional.IsDefined(SourceRetryCount))
            {
                writer.WritePropertyName("sourceRetryCount"u8);
                writer.WriteObjectValue<object>(SourceRetryCount);
            }
            if (Optional.IsDefined(SourceRetryWait))
            {
                writer.WritePropertyName("sourceRetryWait"u8);
                writer.WriteObjectValue<object>(SourceRetryWait);
            }
            if (Optional.IsDefined(MaxConcurrentConnections))
            {
                writer.WritePropertyName("maxConcurrentConnections"u8);
                writer.WriteObjectValue<object>(MaxConcurrentConnections);
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue<object>(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static SapTableSource DeserializeSapTableSource(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            object rowCount = default;
            object rowSkips = default;
            object rfcTableFields = default;
            object rfcTableOptions = default;
            object batchSize = default;
            object customRfcReadTableFunctionModule = default;
            object sapDataColumnDelimiter = default;
            object partitionOption = default;
            SapTablePartitionSettings partitionSettings = default;
            object queryTimeout = default;
            object additionalColumns = default;
            string type = default;
            object sourceRetryCount = default;
            object sourceRetryWait = default;
            object maxConcurrentConnections = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rowCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rowCount = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("rowSkips"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rowSkips = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("rfcTableFields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rfcTableFields = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("rfcTableOptions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rfcTableOptions = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("batchSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    batchSize = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("customRfcReadTableFunctionModule"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    customRfcReadTableFunctionModule = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("sapDataColumnDelimiter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sapDataColumnDelimiter = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("partitionOption"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    partitionOption = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("partitionSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    partitionSettings = SapTablePartitionSettings.DeserializeSapTablePartitionSettings(property.Value);
                    continue;
                }
                if (property.NameEquals("queryTimeout"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    queryTimeout = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("additionalColumns"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    additionalColumns = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceRetryCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sourceRetryCount = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("sourceRetryWait"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sourceRetryWait = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("maxConcurrentConnections"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxConcurrentConnections = property.Value.GetObject();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new SapTableSource(
                type,
                sourceRetryCount,
                sourceRetryWait,
                maxConcurrentConnections,
                additionalProperties,
                queryTimeout,
                additionalColumns,
                rowCount,
                rowSkips,
                rfcTableFields,
                rfcTableOptions,
                batchSize,
                customRfcReadTableFunctionModule,
                sapDataColumnDelimiter,
                partitionOption,
                partitionSettings);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new SapTableSource FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeSapTableSource(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal partial class SapTableSourceConverter : JsonConverter<SapTableSource>
        {
            public override void Write(Utf8JsonWriter writer, SapTableSource model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }

            public override SapTableSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeSapTableSource(document.RootElement);
            }
        }
    }
}
