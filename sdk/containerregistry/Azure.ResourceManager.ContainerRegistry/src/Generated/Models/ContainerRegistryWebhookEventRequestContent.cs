// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The request that generated the event. </summary>
    public partial class ContainerRegistryWebhookEventRequestContent
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryWebhookEventRequestContent"/>. </summary>
        internal ContainerRegistryWebhookEventRequestContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerRegistryWebhookEventRequestContent"/>. </summary>
        /// <param name="id"> The ID of the request that initiated the event. </param>
        /// <param name="addr"> The IP or hostname and possibly port of the client connection that initiated the event. This is the RemoteAddr from the standard http request. </param>
        /// <param name="host"> The externally accessible hostname of the registry instance, as specified by the http host header on incoming requests. </param>
        /// <param name="method"> The request method that generated the event. </param>
        /// <param name="userAgent"> The user agent header of the request. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ContainerRegistryWebhookEventRequestContent(Guid? id, string addr, string host, string method, string userAgent, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Addr = addr;
            Host = host;
            Method = method;
            UserAgent = userAgent;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The ID of the request that initiated the event. </summary>
        [WirePath("id")]
        public Guid? Id { get; }
        /// <summary> The IP or hostname and possibly port of the client connection that initiated the event. This is the RemoteAddr from the standard http request. </summary>
        [WirePath("addr")]
        public string Addr { get; }
        /// <summary> The externally accessible hostname of the registry instance, as specified by the http host header on incoming requests. </summary>
        [WirePath("host")]
        public string Host { get; }
        /// <summary> The request method that generated the event. </summary>
        [WirePath("method")]
        public string Method { get; }
        /// <summary> The user agent header of the request. </summary>
        [WirePath("useragent")]
        public string UserAgent { get; }
    }
}
