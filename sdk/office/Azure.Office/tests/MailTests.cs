// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Mail;
using NUnit.Framework;

namespace Azure.Office.Tests
{
    public class MailTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SendEmail()
        {
            var client = new MailClient("kcwalina@microsoft.com");
            Response response = client.Send("test", "Hello World!", "kcwalina@microsoft.com");
        }
    }
}
