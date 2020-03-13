// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Mail;
using NUnit.Framework;

namespace Azure.Office.Tests
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
            Response response = _client.Send("test", "Hello World!", "kcwalina@microsoft.com");
        }
    }
}
