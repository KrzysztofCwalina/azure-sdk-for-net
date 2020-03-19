// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Graph.Calendar;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Graph.Tests
{
    public class CalendarTests : GraphTestsBase
    {
        private CalendarClient _client;

        [SetUp]
        public void Setup()
        {
            var credential = CreateCredential();
            _client = new CalendarClient(credential);
        }

        [Test]
        public void GetEvents()
        {
            foreach (var calendarEvent in _client.GetEvents())
            {

            }
        }
    }
}
