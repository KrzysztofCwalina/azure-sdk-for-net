// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Calendar;
using NUnit.Framework;

namespace Azure.Office.Tests
{
    public class CalendarTests
    {
        private CalendarClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new CalendarClient("kcwalina@microsoft.com");
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
