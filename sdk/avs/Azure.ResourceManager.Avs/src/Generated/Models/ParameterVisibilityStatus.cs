// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> Visibility Parameter. </summary>
    public readonly partial struct ParameterVisibilityStatus : IEquatable<ParameterVisibilityStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ParameterVisibilityStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ParameterVisibilityStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string VisibleValue = "Visible";
        private const string HiddenValue = "Hidden";

        /// <summary> is visible. </summary>
        public static ParameterVisibilityStatus Visible { get; } = new ParameterVisibilityStatus(VisibleValue);
        /// <summary> is hidden. </summary>
        public static ParameterVisibilityStatus Hidden { get; } = new ParameterVisibilityStatus(HiddenValue);
        /// <summary> Determines if two <see cref="ParameterVisibilityStatus"/> values are the same. </summary>
        public static bool operator ==(ParameterVisibilityStatus left, ParameterVisibilityStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ParameterVisibilityStatus"/> values are not the same. </summary>
        public static bool operator !=(ParameterVisibilityStatus left, ParameterVisibilityStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ParameterVisibilityStatus"/>. </summary>
        public static implicit operator ParameterVisibilityStatus(string value) => new ParameterVisibilityStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ParameterVisibilityStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ParameterVisibilityStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
