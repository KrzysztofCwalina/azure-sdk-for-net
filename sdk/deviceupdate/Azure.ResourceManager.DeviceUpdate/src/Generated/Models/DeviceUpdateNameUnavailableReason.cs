// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DeviceUpdate.Models
{
    /// <summary> The reason why the given name is not available. </summary>
    public readonly partial struct DeviceUpdateNameUnavailableReason : IEquatable<DeviceUpdateNameUnavailableReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DeviceUpdateNameUnavailableReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DeviceUpdateNameUnavailableReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidValue = "Invalid";
        private const string AlreadyExistsValue = "AlreadyExists";

        /// <summary> Invalid. </summary>
        public static DeviceUpdateNameUnavailableReason Invalid { get; } = new DeviceUpdateNameUnavailableReason(InvalidValue);
        /// <summary> AlreadyExists. </summary>
        public static DeviceUpdateNameUnavailableReason AlreadyExists { get; } = new DeviceUpdateNameUnavailableReason(AlreadyExistsValue);
        /// <summary> Determines if two <see cref="DeviceUpdateNameUnavailableReason"/> values are the same. </summary>
        public static bool operator ==(DeviceUpdateNameUnavailableReason left, DeviceUpdateNameUnavailableReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DeviceUpdateNameUnavailableReason"/> values are not the same. </summary>
        public static bool operator !=(DeviceUpdateNameUnavailableReason left, DeviceUpdateNameUnavailableReason right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="DeviceUpdateNameUnavailableReason"/>. </summary>
        public static implicit operator DeviceUpdateNameUnavailableReason(string value) => new DeviceUpdateNameUnavailableReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DeviceUpdateNameUnavailableReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DeviceUpdateNameUnavailableReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
