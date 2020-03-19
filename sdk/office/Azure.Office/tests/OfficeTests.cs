// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Graph.Calendar;
using Azure.Graph.Mail;
using Azure.Graph.Users;
using NUnit.Framework;

namespace Azure.Graph.Tests
{
    public class OfficeTests : GraphTestsBase
    {
        private GraphClient _client;

        [SetUp]
        public void Setup()
        {
            var credential = CreateCredential();
            _client = new GraphClient(credential);
        }

        [Test]
        public void GetClients()
        {
            MailClient mail = _client.GetMailClient();
            Assert.IsNotNull(mail);

            GraphUserClient user = _client.GetUserClient();
            Assert.IsNotNull(user);

            CalendarClient calendar = _client.GetCalendarClient();
            Assert.IsNotNull(calendar);
        }
    }
}
