// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Maps.Common;

namespace Azure.Maps.Weather.Models
{
    /// <summary> The DailyForecast. </summary>
    public partial class DailyForecast
    {
        /// <summary> Initializes a new instance of <see cref="DailyForecast"/>. </summary>
        internal DailyForecast()
        {
            AirQuality = new ChangeTrackingList<AirAndPollen>();
            Sources = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="DailyForecast"/>. </summary>
        /// <param name="dateTime"> Date and time of the current observation displayed in ISO 8601 format, for example, 2019-10-27T19:39:57-08:00. </param>
        /// <param name="temperature"> Temperature values for the day. </param>
        /// <param name="realFeelTemperature"> RealFeel™ Temperature being returned. </param>
        /// <param name="realFeelTemperatureShade"> RealFeel™ Temperature being returned. Describes what the temperature really feels like in the shade. </param>
        /// <param name="hoursOfSun"> Hours of sun. </param>
        /// <param name="meanTemperatureDeviation"> Summary for mean temperature of Heating Degree Day or Cooling Degree Day information. </param>
        /// <param name="airQuality"> Air quality. </param>
        /// <param name="daytimeForecast"> Day forecast detail. </param>
        /// <param name="nighttimeForecast"> Night forecast detail. </param>
        /// <param name="sources"> Source(s) of the forecast data. </param>
        internal DailyForecast(DateTimeOffset? dateTime, WeatherValueRange temperature, WeatherValueRange realFeelTemperature, WeatherValueRange realFeelTemperatureShade, float? hoursOfSun, DegreeDaySummary meanTemperatureDeviation, IReadOnlyList<AirAndPollen> airQuality, DailyForecastDetail daytimeForecast, DailyForecastDetail nighttimeForecast, IReadOnlyList<string> sources)
        {
            DateTime = dateTime;
            Temperature = temperature;
            RealFeelTemperature = realFeelTemperature;
            RealFeelTemperatureShade = realFeelTemperatureShade;
            HoursOfSun = hoursOfSun;
            MeanTemperatureDeviation = meanTemperatureDeviation;
            AirQuality = airQuality;
            DaytimeForecast = daytimeForecast;
            NighttimeForecast = nighttimeForecast;
            Sources = sources;
        }

        /// <summary> Date and time of the current observation displayed in ISO 8601 format, for example, 2019-10-27T19:39:57-08:00. </summary>
        public DateTimeOffset? DateTime { get; }
        /// <summary> Temperature values for the day. </summary>
        public WeatherValueRange Temperature { get; }
        /// <summary> RealFeel™ Temperature being returned. </summary>
        public WeatherValueRange RealFeelTemperature { get; }
        /// <summary> RealFeel™ Temperature being returned. Describes what the temperature really feels like in the shade. </summary>
        public WeatherValueRange RealFeelTemperatureShade { get; }
        /// <summary> Hours of sun. </summary>
        public float? HoursOfSun { get; }
        /// <summary> Summary for mean temperature of Heating Degree Day or Cooling Degree Day information. </summary>
        public DegreeDaySummary MeanTemperatureDeviation { get; }
        /// <summary> Air quality. </summary>
        public IReadOnlyList<AirAndPollen> AirQuality { get; }
        /// <summary> Day forecast detail. </summary>
        public DailyForecastDetail DaytimeForecast { get; }
        /// <summary> Night forecast detail. </summary>
        public DailyForecastDetail NighttimeForecast { get; }
        /// <summary> Source(s) of the forecast data. </summary>
        public IReadOnlyList<string> Sources { get; }
    }
}
