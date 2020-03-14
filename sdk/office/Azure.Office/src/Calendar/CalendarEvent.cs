// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Office.Calendar
{
    /// <summary>
    /// User
    /// </summary>
    public class CalendarEvent : IEquatable<CalendarEvent>
    {
        /// <summary>
        /// Subject.
        /// </summary>
        public string Subject { get; internal set; }

        /// <summary>
        /// ID.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Returns DisplayName.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Subject;

        /// <summary>
        /// Returns true if IDs are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CalendarEvent other) => this.Id.Equals(other.Id, StringComparison.Ordinal);

        /// <summary>
        /// Returns true if IDs are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is CalendarEvent) Equals((CalendarEvent)obj);
            return false;
        }

        /// <summary>
        /// Returns hashcode
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => Id.GetHashCode();

        internal static CalendarEvent Deserialize(Stream content)
        {
            var json = JsonDocument.Parse(content);
            var root = json.RootElement;

            var user = new CalendarEvent();

            throw new NotImplementedException(); // TODO: implement
        }
    }
}
