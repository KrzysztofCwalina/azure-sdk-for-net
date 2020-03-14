// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Office.Mail
{
    /// <summary>
    /// E-mail message.
    /// </summary>
    public class MailMessage
    {
        /// <summary>
        /// E-mail message
        /// </summary>
        public MailMessage()
        {

        }

        /// <summary>
        /// E-mail subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// E-mail receipents
        /// </summary>
        public IList<string> To => _to;
        private List<string> _to = new List<string>(0);

        internal static MailMessage Deserialize(Stream content)
        {
            var json = JsonDocument.Parse(content);
            var root = json.RootElement;

            var user = new MailMessage();
            user.Subject = root.GetProperty("subject").GetString();

            return user;
        }

        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteStartObject("message");
            writer.WriteString("subject", Subject);
            writer.WriteStartObject("body");
            writer.WriteString("contentType", "Text");
            writer.WriteString("content", "message");
            writer.WriteEndObject(); // body

            writer.WriteStartArray("toRecipients");
            foreach (string toReceipent in _to) {
                writer.WriteStartObject();
                writer.WriteStartObject("emailAddress");
                writer.WriteString("address", toReceipent);
                writer.WriteEndObject(); // emailAddress
                writer.WriteEndObject(); // toRecipient
            }
            writer.WriteEndArray();

            writer.WriteEndObject(); // message
            writer.WriteEndObject(); // root
            writer.Flush();
        }
    }
}
