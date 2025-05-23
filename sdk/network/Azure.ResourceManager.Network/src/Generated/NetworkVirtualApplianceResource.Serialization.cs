// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceResource : IJsonModel<NetworkVirtualApplianceData>
    {
        void IJsonModel<NetworkVirtualApplianceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<NetworkVirtualApplianceData>)Data).Write(writer, options);

        NetworkVirtualApplianceData IJsonModel<NetworkVirtualApplianceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<NetworkVirtualApplianceData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<NetworkVirtualApplianceData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<NetworkVirtualApplianceData>(Data, options, AzureResourceManagerNetworkContext.Default);

        NetworkVirtualApplianceData IPersistableModel<NetworkVirtualApplianceData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<NetworkVirtualApplianceData>(data, options, AzureResourceManagerNetworkContext.Default);

        string IPersistableModel<NetworkVirtualApplianceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<NetworkVirtualApplianceData>)Data).GetFormatFromOptions(options);
    }
}
