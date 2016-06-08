namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utils;

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
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be("urn:ietf:wg:oauth:2.0:oob");
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValid.Should().BeFalse();
            client.Authentication.ClientId.Should().BeNull();
            client.Authentication.ClientSecret.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidClient()
        {
            var client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be("urn:ietf:wg:oauth:2.0:oob");
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValid.Should().BeTrue();
            client.Authentication.ClientId.Should().Be(CLIENT_ID);
            client.Authentication.ClientSecret.Should().Be(CLIENT_SECRET);
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockAuthenticationHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
            TestUtility.SetDefaultClientValues();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetAccessToken

        [TestMethod]
        public void TestTraktAuthenticationGetAccessToken()
        {
            var client = new TraktClient();

            client.Authentication.AccessToken.Should().NotBeNull();
            client.Authentication.AccessToken.IsValid.Should().BeFalse();
            client.Authentication.IsAuthenticated.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationGetAccessTokenWithValidClient()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetDevice

        [TestMethod]
        public void TestTraktAuthenticationGetDevice()
        {
            var client = new TraktClient();

            client.Authentication.Device.Should().NotBeNull();
            client.Authentication.Device.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationGetDeviceWithValidClient()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAccessToken

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecret()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAccessToken

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
