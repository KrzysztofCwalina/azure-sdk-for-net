// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Users;
using NUnit.Framework;

namespace Azure.Office.Tests
{
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetMe()
        {
            var client = new UserClient("kcwalina@microsoft.com");
            OfficeUser user = client.GetMe();
        }
    }
}
