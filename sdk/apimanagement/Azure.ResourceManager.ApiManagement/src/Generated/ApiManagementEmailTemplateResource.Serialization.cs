// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementEmailTemplateResource : IJsonModel<ApiManagementEmailTemplateData>
    {
        void IJsonModel<ApiManagementEmailTemplateData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<ApiManagementEmailTemplateData>)Data).Write(writer, options);

        ApiManagementEmailTemplateData IJsonModel<ApiManagementEmailTemplateData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<ApiManagementEmailTemplateData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<ApiManagementEmailTemplateData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<ApiManagementEmailTemplateData>(Data, options, AzureResourceManagerApiManagementContext.Default);

        ApiManagementEmailTemplateData IPersistableModel<ApiManagementEmailTemplateData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<ApiManagementEmailTemplateData>(data, options, AzureResourceManagerApiManagementContext.Default);

        string IPersistableModel<ApiManagementEmailTemplateData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<ApiManagementEmailTemplateData>)Data).GetFormatFromOptions(options);
    }
}
