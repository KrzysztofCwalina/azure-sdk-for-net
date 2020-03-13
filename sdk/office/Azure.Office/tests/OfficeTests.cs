// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Mail;
using Azure.Office.Users;
using NUnit.Framework;

namespace Azure.Office.Tests
{
    public class OfficeTests
    {
        private OfficeClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new OfficeClient("kcwalina@microsoft.com");
        }

        [Test]
        public void GetClients()
        {
            MailClient mail = _client.GetMailClient();
            Assert.IsNotNull(mail);

            UserClient user = _client.GetUserClient();
            Assert.IsNotNull(user);
        }
    }
}
