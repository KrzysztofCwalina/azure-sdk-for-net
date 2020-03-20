// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Graph.Users
{
    /// <summary>
    /// User
    /// </summary>
    public class GraphUser : IEquatable<GraphUser>
    {
        /// <summary>
        /// Office
        /// </summary>
        public string Office { get; internal set; }

        /// <summary>
        /// Name
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// Given name.
        /// </summary>
        public string GivenName { get; internal set; }

        /// <summary>
        /// Surname.
        /// </summary>
        public string Surname { get; internal set; }

        /// <summary>
        /// Mail.
        /// </summary>
        public string Mail { get; internal set; }

        /// <summary>
        /// Mobile phone number
        /// </summary>
        public string MobilePhone { get; internal set; } // TODO: why is it just one number and not a collection?

        /// <summary>
        /// Business phone numbers.
        /// </summary>
        public IReadOnlyList<string> BusinessPhones => _phones;
        internal List<string> _phones = new List<string>(0);

        /// <summary>
        /// Preffered language.
        /// </summary>
        public string PreferredLanguage { get; internal set; }

        /// <summary>
        /// Directory principal name.
        /// </summary>
        public string Principal { get; internal set; }

        /// <summary>
        /// ID.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Returns DisplayName.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => DisplayName;

        /// <summary>
        /// Returns true if IDs are the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(GraphUser other) => this.Id.Equals(other.Id, StringComparison.Ordinal);

        /// <summary>
        /// Returns true if IDs are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is GraphUser) Equals((GraphUser)obj);
            return false;
        }

        /// <summary>
        /// Returns hashcode
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => Id.GetHashCode();

        internal static GraphUser Deserialize(Stream content)
        {
            var json = JsonDocument.Parse(content);
            var root = json.RootElement;
            return Deserialize(root);
        }

        internal static GraphUser Deserialize(JsonElement element)
        {
            var user = new GraphUser();
            user.Office = element.GetProperty("officeLocation").GetString();
            user.DisplayName = element.GetProperty("displayName").GetString();
            user.Title = element.GetProperty("jobTitle").GetString();
            user.GivenName = element.GetProperty("givenName").GetString();
            user.Surname = element.GetProperty("surname").GetString();
            user.Mail = element.GetProperty("mail").GetString();

            user.MobilePhone = element.GetProperty("mobilePhone").GetString();
            user.PreferredLanguage = element.GetProperty("preferredLanguage").GetString();
            user.Principal = element.GetProperty("userPrincipalName").GetString();
            user.Id = element.GetProperty("id").GetString();

            var businessPhones = element.GetProperty("businessPhones");
            foreach (var phone in businessPhones.EnumerateArray())
            {
                var bp = phone.GetString();
                user._phones.Add(bp);
            }

            return user;
        }
    }
}
