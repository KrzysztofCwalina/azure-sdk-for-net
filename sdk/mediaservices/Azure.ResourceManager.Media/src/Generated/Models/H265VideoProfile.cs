// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Media.Models
{
    /// <summary> We currently support Main. Default is Auto. </summary>
    public readonly partial struct H265VideoProfile : IEquatable<H265VideoProfile>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="H265VideoProfile"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public H265VideoProfile(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AutoValue = "Auto";
        private const string MainValue = "Main";
        private const string Main10Value = "Main10";

        /// <summary> Tells the encoder to automatically determine the appropriate H.265 profile. </summary>
        public static H265VideoProfile Auto { get; } = new H265VideoProfile(AutoValue);
        /// <summary> Main profile (https://x265.readthedocs.io/en/default/cli.html?highlight=profile#profile-level-tier). </summary>
        public static H265VideoProfile Main { get; } = new H265VideoProfile(MainValue);
        /// <summary> Main 10 profile (https://en.wikipedia.org/wiki/High_Efficiency_Video_Coding#Main_10). </summary>
        public static H265VideoProfile Main10 { get; } = new H265VideoProfile(Main10Value);
        /// <summary> Determines if two <see cref="H265VideoProfile"/> values are the same. </summary>
        public static bool operator ==(H265VideoProfile left, H265VideoProfile right) => left.Equals(right);
        /// <summary> Determines if two <see cref="H265VideoProfile"/> values are not the same. </summary>
        public static bool operator !=(H265VideoProfile left, H265VideoProfile right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="H265VideoProfile"/>. </summary>
        public static implicit operator H265VideoProfile(string value) => new H265VideoProfile(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is H265VideoProfile other && Equals(other);
        /// <inheritdoc />
        public bool Equals(H265VideoProfile other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
