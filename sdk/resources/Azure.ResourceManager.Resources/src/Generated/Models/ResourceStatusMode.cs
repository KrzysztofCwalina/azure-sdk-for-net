// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Current management state of the resource in the deployment stack. </summary>
    public readonly partial struct ResourceStatusMode : IEquatable<ResourceStatusMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ResourceStatusMode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ResourceStatusMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ManagedValue = "managed";
        private const string RemoveDenyFailedValue = "removeDenyFailed";
        private const string DeleteFailedValue = "deleteFailed";

        /// <summary> This resource is managed by the deployment stack. </summary>
        public static ResourceStatusMode Managed { get; } = new ResourceStatusMode(ManagedValue);
        /// <summary> Unable to remove the deny assignment on resource. </summary>
        public static ResourceStatusMode RemoveDenyFailed { get; } = new ResourceStatusMode(RemoveDenyFailedValue);
        /// <summary> Unable to delete the resource from Azure. The delete will be retried on the next stack deployment, or can be deleted manually. </summary>
        public static ResourceStatusMode DeleteFailed { get; } = new ResourceStatusMode(DeleteFailedValue);
        /// <summary> Determines if two <see cref="ResourceStatusMode"/> values are the same. </summary>
        public static bool operator ==(ResourceStatusMode left, ResourceStatusMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ResourceStatusMode"/> values are not the same. </summary>
        public static bool operator !=(ResourceStatusMode left, ResourceStatusMode right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ResourceStatusMode"/>. </summary>
        public static implicit operator ResourceStatusMode(string value) => new ResourceStatusMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ResourceStatusMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ResourceStatusMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
