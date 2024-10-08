// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.ComputeSchedule.Models
{
    /// <summary> This is the response from a get operations errors request. </summary>
    public partial class GetOperationErrorsResult
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

        /// <summary> Initializes a new instance of <see cref="GetOperationErrorsResult"/>. </summary>
        /// <param name="results"> An array of operationids and their corresponding errors if any. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        internal GetOperationErrorsResult(IEnumerable<OperationErrorsResult> results)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="GetOperationErrorsResult"/>. </summary>
        /// <param name="results"> An array of operationids and their corresponding errors if any. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal GetOperationErrorsResult(IReadOnlyList<OperationErrorsResult> results, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Results = results;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="GetOperationErrorsResult"/> for deserialization. </summary>
        internal GetOperationErrorsResult()
        {
        }

        /// <summary> An array of operationids and their corresponding errors if any. </summary>
        public IReadOnlyList<OperationErrorsResult> Results { get; }
    }
}
