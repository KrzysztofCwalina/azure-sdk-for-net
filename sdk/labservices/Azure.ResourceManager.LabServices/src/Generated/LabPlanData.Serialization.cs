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
using Azure.ResourceManager.LabServices.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.LabServices
{
    public partial class LabPlanData : IUtf8JsonSerializable, IJsonModel<LabPlanData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LabPlanData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<LabPlanData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LabPlanData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LabPlanData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                ((IJsonModel<ManagedServiceIdentity>)Identity).Write(writer, options);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(DefaultConnectionProfile))
            {
                writer.WritePropertyName("defaultConnectionProfile"u8);
                writer.WriteObjectValue(DefaultConnectionProfile, options);
            }
            if (Optional.IsDefined(DefaultAutoShutdownProfile))
            {
                writer.WritePropertyName("defaultAutoShutdownProfile"u8);
                writer.WriteObjectValue(DefaultAutoShutdownProfile, options);
            }
            if (Optional.IsDefined(DefaultNetworkProfile))
            {
                writer.WritePropertyName("defaultNetworkProfile"u8);
                writer.WriteObjectValue(DefaultNetworkProfile, options);
            }
            if (Optional.IsCollectionDefined(AllowedRegions))
            {
                writer.WritePropertyName("allowedRegions"u8);
                writer.WriteStartArray();
                foreach (var item in AllowedRegions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(SharedGalleryId))
            {
                writer.WritePropertyName("sharedGalleryId"u8);
                writer.WriteStringValue(SharedGalleryId);
            }
            if (Optional.IsDefined(SupportInfo))
            {
                writer.WritePropertyName("supportInfo"u8);
                writer.WriteObjectValue(SupportInfo, options);
            }
            if (Optional.IsDefined(LinkedLmsInstance))
            {
                writer.WritePropertyName("linkedLmsInstance"u8);
                writer.WriteStringValue(LinkedLmsInstance.AbsoluteUri);
            }
            if (options.Format != "W" && Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        LabPlanData IJsonModel<LabPlanData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LabPlanData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LabPlanData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLabPlanData(document.RootElement, options);
        }

        internal static LabPlanData DeserializeLabPlanData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ManagedServiceIdentity identity = default;
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            LabConnectionProfile defaultConnectionProfile = default;
            LabAutoShutdownProfile defaultAutoShutdownProfile = default;
            LabPlanNetworkProfile defaultNetworkProfile = default;
            IList<AzureLocation> allowedRegions = default;
            ResourceIdentifier sharedGalleryId = default;
            LabPlanSupportInfo supportInfo = default;
            Uri linkedLmsInstance = default;
            LabServicesProvisioningState? provisioningState = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), options, AzureResourceManagerLabServicesContext.Default);
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
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
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerLabServicesContext.Default);
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
                        if (property0.NameEquals("defaultConnectionProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            defaultConnectionProfile = LabConnectionProfile.DeserializeLabConnectionProfile(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("defaultAutoShutdownProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            defaultAutoShutdownProfile = LabAutoShutdownProfile.DeserializeLabAutoShutdownProfile(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("defaultNetworkProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            defaultNetworkProfile = LabPlanNetworkProfile.DeserializeLabPlanNetworkProfile(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("allowedRegions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<AzureLocation> array = new List<AzureLocation>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new AzureLocation(item.GetString()));
                            }
                            allowedRegions = array;
                            continue;
                        }
                        if (property0.NameEquals("sharedGalleryId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            sharedGalleryId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("supportInfo"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            supportInfo = LabPlanSupportInfo.DeserializeLabPlanSupportInfo(property0.Value, options);
                            continue;
                        }
                        if (property0.NameEquals("linkedLmsInstance"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            linkedLmsInstance = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = property0.Value.GetString().ToLabServicesProvisioningState();
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
            return new LabPlanData(
                id,
                name,
                type,
                systemData,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                identity,
                defaultConnectionProfile,
                defaultAutoShutdownProfile,
                defaultNetworkProfile,
                allowedRegions ?? new ChangeTrackingList<AzureLocation>(),
                sharedGalleryId,
                supportInfo,
                linkedLmsInstance,
                provisioningState,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<LabPlanData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LabPlanData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerLabServicesContext.Default);
                default:
                    throw new FormatException($"The model {nameof(LabPlanData)} does not support writing '{options.Format}' format.");
            }
        }

        LabPlanData IPersistableModel<LabPlanData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LabPlanData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeLabPlanData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LabPlanData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<LabPlanData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
