// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> The entity resolution object kind. </summary>
    internal readonly partial struct ResolutionKind : IEquatable<ResolutionKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ResolutionKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ResolutionKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BooleanResolutionValue = "BooleanResolution";
        private const string DateTimeResolutionValue = "DateTimeResolution";
        private const string NumberResolutionValue = "NumberResolution";
        private const string OrdinalResolutionValue = "OrdinalResolution";
        private const string SpeedResolutionValue = "SpeedResolution";
        private const string WeightResolutionValue = "WeightResolution";
        private const string LengthResolutionValue = "LengthResolution";
        private const string VolumeResolutionValue = "VolumeResolution";
        private const string AreaResolutionValue = "AreaResolution";
        private const string AgeResolutionValue = "AgeResolution";
        private const string InformationResolutionValue = "InformationResolution";
        private const string TemperatureResolutionValue = "TemperatureResolution";
        private const string CurrencyResolutionValue = "CurrencyResolution";
        private const string NumericRangeResolutionValue = "NumericRangeResolution";
        private const string TemporalSpanResolutionValue = "TemporalSpanResolution";

        /// <summary> Resolution of a boolean entity. </summary>
        public static ResolutionKind BooleanResolution { get; } = new ResolutionKind(BooleanResolutionValue);
        /// <summary> Resolution of a date/time entity. </summary>
        public static ResolutionKind DateTimeResolution { get; } = new ResolutionKind(DateTimeResolutionValue);
        /// <summary> Resolution of a number entity. </summary>
        public static ResolutionKind NumberResolution { get; } = new ResolutionKind(NumberResolutionValue);
        /// <summary> Resolution of an ordinal entity. </summary>
        public static ResolutionKind OrdinalResolution { get; } = new ResolutionKind(OrdinalResolutionValue);
        /// <summary> Resolution of a speed entity. </summary>
        public static ResolutionKind SpeedResolution { get; } = new ResolutionKind(SpeedResolutionValue);
        /// <summary> Resolution of a weight entity. </summary>
        public static ResolutionKind WeightResolution { get; } = new ResolutionKind(WeightResolutionValue);
        /// <summary> Resolution of a length entity. </summary>
        public static ResolutionKind LengthResolution { get; } = new ResolutionKind(LengthResolutionValue);
        /// <summary> Resolution of a volume entity. </summary>
        public static ResolutionKind VolumeResolution { get; } = new ResolutionKind(VolumeResolutionValue);
        /// <summary> Resolution of an area entity. </summary>
        public static ResolutionKind AreaResolution { get; } = new ResolutionKind(AreaResolutionValue);
        /// <summary> Resolution of an age entity. </summary>
        public static ResolutionKind AgeResolution { get; } = new ResolutionKind(AgeResolutionValue);
        /// <summary> Resolution of an information entity. </summary>
        public static ResolutionKind InformationResolution { get; } = new ResolutionKind(InformationResolutionValue);
        /// <summary> Resolution of a temperature entity. </summary>
        public static ResolutionKind TemperatureResolution { get; } = new ResolutionKind(TemperatureResolutionValue);
        /// <summary> Resolution of a currency entity. </summary>
        public static ResolutionKind CurrencyResolution { get; } = new ResolutionKind(CurrencyResolutionValue);
        /// <summary> Resolution of a numeric range entity. </summary>
        public static ResolutionKind NumericRangeResolution { get; } = new ResolutionKind(NumericRangeResolutionValue);
        /// <summary> Resolution of a temporal span entity. </summary>
        public static ResolutionKind TemporalSpanResolution { get; } = new ResolutionKind(TemporalSpanResolutionValue);
        /// <summary> Determines if two <see cref="ResolutionKind"/> values are the same. </summary>
        public static bool operator ==(ResolutionKind left, ResolutionKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ResolutionKind"/> values are not the same. </summary>
        public static bool operator !=(ResolutionKind left, ResolutionKind right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="ResolutionKind"/>. </summary>
        public static implicit operator ResolutionKind(string value) => new ResolutionKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ResolutionKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ResolutionKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
