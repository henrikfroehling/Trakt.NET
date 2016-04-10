namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAuthenticationTests
    {
        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";

        [TestMethod]
        public void TestTraktAuthenticationConstructor()
        {
            var client = new TraktClient();

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AuthenticationMode.Should().Be(TraktAuthenticationMode.Device);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be("urn:ietf:wg:oauth:2.0:oob");

            client.Authentication.ClientId.Should().BeNull();
            client.Authentication.ClientSecret.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidClient()
        {
            var client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AuthenticationMode.Should().Be(TraktAuthenticationMode.Device);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be("urn:ietf:wg:oauth:2.0:oob");

            client.IsValid.Should().BeTrue();
            client.Authentication.ClientId.Should().Be(CLIENT_ID);
            client.Authentication.ClientSecret.Should().Be(CLIENT_SECRET);
        }

        [TestMethod]
        public void TestTraktAuthenticationGetAccessToken()
        {
            var client = new TraktClient();

            client.Authentication.AccessToken.Should().NotBeNull();
            client.Authentication.AccessToken.IsValid.Should().BeFalse();
            client.Authentication.IsAuthenticated.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationGetDevice()
        {
            var client = new TraktClient();

            client.Authentication.Device.Should().NotBeNull();
            client.Authentication.Device.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationGetAuthorizationCode()
        {
            var client = new TraktClient();

            client.Authentication.AuthorizationCode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationGetAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenAsync()
        {
            // TODO
        }
    }
}
