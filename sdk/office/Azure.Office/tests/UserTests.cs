// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Graph.Mail;
using Azure.Graph.Users;
using NUnit.Framework;

namespace Azure.Graph.Tests
{
    public class UserTests
    {
        private GraphUserClient _client;

        private const string USER = "pmarcu@microsoft.com";

        [SetUp]
        public void Setup()
        {
            _client = new GraphUserClient("kcwalina@microsoft.com");
        }

        [Test]
        public void GetMe()
        {
            GraphUser user = _client.GetMe();

            Assert.AreEqual("Cwalina", user.Surname);
        }

        [Test]
        public void GetUser()
        {
            GraphUser user = _client.GetUser(USER);

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
