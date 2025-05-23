// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Models
{
    public partial class QuestionAnswersConfig : IUtf8JsonSerializable, IJsonModel<QuestionAnswersConfig>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<QuestionAnswersConfig>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<QuestionAnswersConfig>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<QuestionAnswersConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(QuestionAnswersConfig)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(QnaId))
            {
                writer.WritePropertyName("qnaId"u8);
                writer.WriteNumberValue(QnaId.Value);
            }
            if (Optional.IsDefined(Question))
            {
                writer.WritePropertyName("question"u8);
                writer.WriteStringValue(Question);
            }
            if (Optional.IsDefined(Top))
            {
                writer.WritePropertyName("top"u8);
                writer.WriteNumberValue(Top.Value);
            }
            if (Optional.IsDefined(UserId))
            {
                writer.WritePropertyName("userId"u8);
                writer.WriteStringValue(UserId);
            }
            if (Optional.IsDefined(ConfidenceThreshold))
            {
                writer.WritePropertyName("confidenceScoreThreshold"u8);
                writer.WriteNumberValue(ConfidenceThreshold.Value);
            }
            if (Optional.IsDefined(AnswerContext))
            {
                writer.WritePropertyName("context"u8);
                writer.WriteObjectValue(AnswerContext, options);
            }
            if (Optional.IsDefined(RankerKind))
            {
                writer.WritePropertyName("rankerType"u8);
                writer.WriteStringValue(RankerKind.Value.ToString());
            }
            if (Optional.IsDefined(Filters))
            {
                writer.WritePropertyName("filters"u8);
                writer.WriteObjectValue(Filters, options);
            }
            if (Optional.IsDefined(ShortAnswerOptions))
            {
                writer.WritePropertyName("answerSpanRequest"u8);
                writer.WriteObjectValue(ShortAnswerOptions, options);
            }
            if (Optional.IsDefined(IncludeUnstructuredSources))
            {
                writer.WritePropertyName("includeUnstructuredSources"u8);
                writer.WriteBooleanValue(IncludeUnstructuredSources.Value);
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

        QuestionAnswersConfig IJsonModel<QuestionAnswersConfig>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<QuestionAnswersConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(QuestionAnswersConfig)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeQuestionAnswersConfig(document.RootElement, options);
        }

        internal static QuestionAnswersConfig DeserializeQuestionAnswersConfig(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? qnaId = default;
            string question = default;
            int? top = default;
            string userId = default;
            double? confidenceScoreThreshold = default;
            KnowledgeBaseAnswerContext context = default;
            RankerKind? rankerType = default;
            QueryFilters filters = default;
            ShortAnswerConfig answerSpanRequest = default;
            bool? includeUnstructuredSources = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("qnaId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    qnaId = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("question"u8))
                {
                    question = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("top"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    top = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("userId"u8))
                {
                    userId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("confidenceScoreThreshold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    confidenceScoreThreshold = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("context"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    context = KnowledgeBaseAnswerContext.DeserializeKnowledgeBaseAnswerContext(property.Value, options);
                    continue;
                }
                if (property.NameEquals("rankerType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rankerType = new RankerKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("filters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filters = QueryFilters.DeserializeQueryFilters(property.Value, options);
                    continue;
                }
                if (property.NameEquals("answerSpanRequest"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    answerSpanRequest = ShortAnswerConfig.DeserializeShortAnswerConfig(property.Value, options);
                    continue;
                }
                if (property.NameEquals("includeUnstructuredSources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    includeUnstructuredSources = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new QuestionAnswersConfig(
                qnaId,
                question,
                top,
                userId,
                confidenceScoreThreshold,
                context,
                rankerType,
                filters,
                answerSpanRequest,
                includeUnstructuredSources,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<QuestionAnswersConfig>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<QuestionAnswersConfig>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureAILanguageConversationsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(QuestionAnswersConfig)} does not support writing '{options.Format}' format.");
            }
        }

        QuestionAnswersConfig IPersistableModel<QuestionAnswersConfig>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<QuestionAnswersConfig>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeQuestionAnswersConfig(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(QuestionAnswersConfig)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<QuestionAnswersConfig>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static QuestionAnswersConfig FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeQuestionAnswersConfig(document.RootElement);
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
