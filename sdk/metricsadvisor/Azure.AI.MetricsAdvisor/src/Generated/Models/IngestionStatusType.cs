// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> latest ingestion task status for this data slice. </summary>
    public readonly partial struct IngestionStatusType : IEquatable<IngestionStatusType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="IngestionStatusType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public IngestionStatusType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotStartedValue = "NotStarted";
        private const string ScheduledValue = "Scheduled";
        private const string RunningValue = "Running";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string NoDataValue = "NoData";
        private const string ErrorValue = "Error";
        private const string PausedValue = "Paused";
        /// <summary> Determines if two <see cref="IngestionStatusType"/> values are the same. </summary>
        public static bool operator ==(IngestionStatusType left, IngestionStatusType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="IngestionStatusType"/> values are not the same. </summary>
        public static bool operator !=(IngestionStatusType left, IngestionStatusType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="IngestionStatusType"/>. </summary>
        public static implicit operator IngestionStatusType(string value) => new IngestionStatusType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is IngestionStatusType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(IngestionStatusType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
