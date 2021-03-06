// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearningServices.Models
{
    /// <summary> The reason for the restriction. </summary>
    public readonly partial struct ReasonCode : IEquatable<ReasonCode>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="ReasonCode"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ReasonCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotSpecifiedValue = "NotSpecified";
        private const string NotAvailableForRegionValue = "NotAvailableForRegion";
        private const string NotAvailableForSubscriptionValue = "NotAvailableForSubscription";

        /// <summary> NotSpecified. </summary>
        public static ReasonCode NotSpecified { get; } = new ReasonCode(NotSpecifiedValue);
        /// <summary> NotAvailableForRegion. </summary>
        public static ReasonCode NotAvailableForRegion { get; } = new ReasonCode(NotAvailableForRegionValue);
        /// <summary> NotAvailableForSubscription. </summary>
        public static ReasonCode NotAvailableForSubscription { get; } = new ReasonCode(NotAvailableForSubscriptionValue);
        /// <summary> Determines if two <see cref="ReasonCode"/> values are the same. </summary>
        public static bool operator ==(ReasonCode left, ReasonCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ReasonCode"/> values are not the same. </summary>
        public static bool operator !=(ReasonCode left, ReasonCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ReasonCode"/>. </summary>
        public static implicit operator ReasonCode(string value) => new ReasonCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ReasonCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ReasonCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
