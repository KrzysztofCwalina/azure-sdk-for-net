// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Synapse.Models
{
    /// <summary> The level of compute power that each node in the Big Data pool has. </summary>
    public readonly partial struct BigDataPoolNodeSize : IEquatable<BigDataPoolNodeSize>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="BigDataPoolNodeSize"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BigDataPoolNodeSize(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string SmallValue = "Small";
        private const string MediumValue = "Medium";
        private const string LargeValue = "Large";
        private const string XLargeValue = "XLarge";
        private const string XXLargeValue = "XXLarge";
        private const string XXXLargeValue = "XXXLarge";

        /// <summary> None. </summary>
        public static BigDataPoolNodeSize None { get; } = new BigDataPoolNodeSize(NoneValue);
        /// <summary> Small. </summary>
        public static BigDataPoolNodeSize Small { get; } = new BigDataPoolNodeSize(SmallValue);
        /// <summary> Medium. </summary>
        public static BigDataPoolNodeSize Medium { get; } = new BigDataPoolNodeSize(MediumValue);
        /// <summary> Large. </summary>
        public static BigDataPoolNodeSize Large { get; } = new BigDataPoolNodeSize(LargeValue);
        /// <summary> XLarge. </summary>
        public static BigDataPoolNodeSize XLarge { get; } = new BigDataPoolNodeSize(XLargeValue);
        /// <summary> XXLarge. </summary>
        public static BigDataPoolNodeSize XXLarge { get; } = new BigDataPoolNodeSize(XXLargeValue);
        /// <summary> XXXLarge. </summary>
        public static BigDataPoolNodeSize XXXLarge { get; } = new BigDataPoolNodeSize(XXXLargeValue);
        /// <summary> Determines if two <see cref="BigDataPoolNodeSize"/> values are the same. </summary>
        public static bool operator ==(BigDataPoolNodeSize left, BigDataPoolNodeSize right) => left.Equals(right);
        /// <summary> Determines if two <see cref="BigDataPoolNodeSize"/> values are not the same. </summary>
        public static bool operator !=(BigDataPoolNodeSize left, BigDataPoolNodeSize right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="BigDataPoolNodeSize"/>. </summary>
        public static implicit operator BigDataPoolNodeSize(string value) => new BigDataPoolNodeSize(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BigDataPoolNodeSize other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BigDataPoolNodeSize other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
