// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Users;
using NUnit.Framework;

namespace Azure.Office.Tests
{
    public class UserTests
    {
        private UserClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new UserClient("kcwalina@microsoft.com");
        }

        [Test]
        public void GetMe()
        {
            OfficeUser user = _client.GetMe();
        }

        [Test]
        public void GetUser()
        {
            OfficeUser user = _client.GetUser("pmarcu@microsoft.com");
        }
    }
}
