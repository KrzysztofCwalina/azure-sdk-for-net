// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary> The status of the test input or output request. </summary>
    public readonly partial struct StreamAnalyticsTestDatasourceResultStatus : IEquatable<StreamAnalyticsTestDatasourceResultStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StreamAnalyticsTestDatasourceResultStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StreamAnalyticsTestDatasourceResultStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TestSucceededValue = "TestSucceeded";
        private const string TestFailedValue = "TestFailed";

        /// <summary> The test datasource operation succeeded. </summary>
        public static StreamAnalyticsTestDatasourceResultStatus TestSucceeded { get; } = new StreamAnalyticsTestDatasourceResultStatus(TestSucceededValue);
        /// <summary> The test datasource operation failed. </summary>
        public static StreamAnalyticsTestDatasourceResultStatus TestFailed { get; } = new StreamAnalyticsTestDatasourceResultStatus(TestFailedValue);
        /// <summary> Determines if two <see cref="StreamAnalyticsTestDatasourceResultStatus"/> values are the same. </summary>
        public static bool operator ==(StreamAnalyticsTestDatasourceResultStatus left, StreamAnalyticsTestDatasourceResultStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StreamAnalyticsTestDatasourceResultStatus"/> values are not the same. </summary>
        public static bool operator !=(StreamAnalyticsTestDatasourceResultStatus left, StreamAnalyticsTestDatasourceResultStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="StreamAnalyticsTestDatasourceResultStatus"/>. </summary>
        public static implicit operator StreamAnalyticsTestDatasourceResultStatus(string value) => new StreamAnalyticsTestDatasourceResultStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StreamAnalyticsTestDatasourceResultStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StreamAnalyticsTestDatasourceResultStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
