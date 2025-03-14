// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Communication.Rooms
{
    /// <summary> The role of a room participant. The default value is Attendee. </summary>
    public readonly partial struct ParticipantRole : IEquatable<ParticipantRole>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ParticipantRole"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ParticipantRole(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PresenterValue = "Presenter";
        private const string AttendeeValue = "Attendee";
        private const string ConsumerValue = "Consumer";
        private const string CollaboratorValue = "Collaborator";

        /// <summary> Presenter. </summary>
        public static ParticipantRole Presenter { get; } = new ParticipantRole(PresenterValue);
        /// <summary> Attendee. </summary>
        public static ParticipantRole Attendee { get; } = new ParticipantRole(AttendeeValue);
        /// <summary> Consumer. </summary>
        public static ParticipantRole Consumer { get; } = new ParticipantRole(ConsumerValue);
        /// <summary> Collaborator. </summary>
        public static ParticipantRole Collaborator { get; } = new ParticipantRole(CollaboratorValue);
        /// <summary> Determines if two <see cref="ParticipantRole"/> values are the same. </summary>
        public static bool operator ==(ParticipantRole left, ParticipantRole right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ParticipantRole"/> values are not the same. </summary>
        public static bool operator !=(ParticipantRole left, ParticipantRole right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ParticipantRole"/>. </summary>
        public static implicit operator ParticipantRole(string value) => new ParticipantRole(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ParticipantRole other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ParticipantRole other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
