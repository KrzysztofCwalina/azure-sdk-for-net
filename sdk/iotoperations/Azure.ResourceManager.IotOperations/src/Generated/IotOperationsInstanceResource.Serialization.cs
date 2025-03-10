// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.IotOperations
{
    public partial class IotOperationsInstanceResource : IJsonModel<IotOperationsInstanceData>
    {
        void IJsonModel<IotOperationsInstanceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<IotOperationsInstanceData>)Data).Write(writer, options);

        IotOperationsInstanceData IJsonModel<IotOperationsInstanceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<IotOperationsInstanceData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<IotOperationsInstanceData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options);

        IotOperationsInstanceData IPersistableModel<IotOperationsInstanceData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<IotOperationsInstanceData>(data, options);

        string IPersistableModel<IotOperationsInstanceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<IotOperationsInstanceData>)Data).GetFormatFromOptions(options);
    }
}
