// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Office.Users;
using NUnit.Framework;

namespace Azure.Office.Tests
{
    public class UserTests
    {
        private UserClient _client;

        private const string USER = "pmarcu@microsoft.com";

        [SetUp]
        public void Setup()
        {
            _client = new UserClient("kcwalina@microsoft.com");
        }

        [Test]
        public void GetMe()
        {
            OfficeUser user = _client.GetMe();

            Assert.AreEqual("Cwalina", user.Surname);
        }

        [Test]
        public void GetUser()
        {
            OfficeUser user = _client.GetUser(USER);

            Assert.AreEqual("Marcu", user.Surname);
        }

        [Test]
        public void GetPhotoMe()
        {
            using Response photo = _client.GetPhoto();

            Assert.AreEqual("image/jpeg", photo.Headers.ContentType);
        }

        [Test]
        public void GetPhotoUser()
        {
            using Response photo = _client.GetPhoto(USER);

            Assert.AreEqual("image/jpeg", photo.Headers.ContentType);
        }
    }
}
