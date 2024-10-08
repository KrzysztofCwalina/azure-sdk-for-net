// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary> The parameters required to execute insights operation on the given entity. </summary>
    public partial class EntityGetInsightsContent
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

        /// <summary> Initializes a new instance of <see cref="EntityGetInsightsContent"/>. </summary>
        /// <param name="startOn"> The start timeline date, so the results returned are after this date. </param>
        /// <param name="endOn"> The end timeline date, so the results returned are before this date. </param>
        public EntityGetInsightsContent(DateTimeOffset startOn, DateTimeOffset endOn)
        {
            StartOn = startOn;
            EndOn = endOn;
            InsightQueryIds = new ChangeTrackingList<Guid>();
        }

        /// <summary> Initializes a new instance of <see cref="EntityGetInsightsContent"/>. </summary>
        /// <param name="startOn"> The start timeline date, so the results returned are after this date. </param>
        /// <param name="endOn"> The end timeline date, so the results returned are before this date. </param>
        /// <param name="isDefaultExtendedTimeRangeAdded"> Indicates if query time range should be extended with default time range of the query. Default value is false. </param>
        /// <param name="insightQueryIds"> List of Insights Query Id. If empty, default value is all insights of this entity. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EntityGetInsightsContent(DateTimeOffset startOn, DateTimeOffset endOn, bool? isDefaultExtendedTimeRangeAdded, IList<Guid> insightQueryIds, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StartOn = startOn;
            EndOn = endOn;
            IsDefaultExtendedTimeRangeAdded = isDefaultExtendedTimeRangeAdded;
            InsightQueryIds = insightQueryIds;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="EntityGetInsightsContent"/> for deserialization. </summary>
        internal EntityGetInsightsContent()
        {
        }

        /// <summary> The start timeline date, so the results returned are after this date. </summary>
        [WirePath("startTime")]
        public DateTimeOffset StartOn { get; }
        /// <summary> The end timeline date, so the results returned are before this date. </summary>
        [WirePath("endTime")]
        public DateTimeOffset EndOn { get; }
        /// <summary> Indicates if query time range should be extended with default time range of the query. Default value is false. </summary>
        [WirePath("addDefaultExtendedTimeRange")]
        public bool? IsDefaultExtendedTimeRangeAdded { get; set; }
        /// <summary> List of Insights Query Id. If empty, default value is all insights of this entity. </summary>
        [WirePath("insightQueryIds")]
        public IList<Guid> InsightQueryIds { get; }
    }
}
