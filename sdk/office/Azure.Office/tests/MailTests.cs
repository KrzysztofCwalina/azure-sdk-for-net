// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Graph.Mail;
using NUnit.Framework;

namespace Azure.Graph.Tests
{
    public class MailTests
    {
        private MailClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new MailClient("kcwalina@microsoft.com");
        }

        [Test]
        public void SendEmail()
        {
            var message = new MailMessage();
            message.Subject = "Hello my friends!";
            message.To.Add("kcwalina@microsoft.com");

            Response response = _client.Send(message);
        }
    }
}
