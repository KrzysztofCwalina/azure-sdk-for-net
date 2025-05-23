// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.AppConfiguration
{
    public partial class AppConfigurationSnapshotResource : IJsonModel<AppConfigurationSnapshotData>
    {
        void IJsonModel<AppConfigurationSnapshotData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<AppConfigurationSnapshotData>)Data).Write(writer, options);

        AppConfigurationSnapshotData IJsonModel<AppConfigurationSnapshotData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<AppConfigurationSnapshotData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<AppConfigurationSnapshotData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<AppConfigurationSnapshotData>(Data, options, AzureResourceManagerAppConfigurationContext.Default);

        AppConfigurationSnapshotData IPersistableModel<AppConfigurationSnapshotData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<AppConfigurationSnapshotData>(data, options, AzureResourceManagerAppConfigurationContext.Default);

        string IPersistableModel<AppConfigurationSnapshotData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<AppConfigurationSnapshotData>)Data).GetFormatFromOptions(options);
    }
}
