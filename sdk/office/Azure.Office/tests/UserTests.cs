// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Graph.Mail;
using Azure.Graph.Users;
using NUnit.Framework;

namespace Azure.Graph.Tests
{
    public class UserTests : GraphTestsBase
    {
        private GraphUserClient _client;

        private const string USER = "MiriamG@M365x955187.OnMicrosoft.com";

        [SetUp]
        public void Setup()
        {
            var credential = CreateCredential();
            _client = new GraphUserClient(credential);
        }

        [Test]
        public void GetMe()
        {
            GraphUser user = _client.GetMe();
            Assert.NotNull(user.Surname);
        }

        [Test]
        public void GetUser()
        {
            GraphUser user = _client.GetUser(USER);

            Assert.AreEqual("Graham", user.Surname);
        }

        [Test]
        public void GetUsers()
        {
            GraphUser[] user = _client.GetUsers();
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
