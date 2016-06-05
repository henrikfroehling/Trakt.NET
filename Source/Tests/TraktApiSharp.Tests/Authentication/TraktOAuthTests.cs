namespace TraktApiSharp.Tests.Authentication
{
    using Core;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Utils;

    [TestClass]
    public class TraktOAuthTests
    {
        [TestMethod]
        public void TestTraktOAuthDefaultConstructor()
        {
            var client = new TraktClient();

            client.OAuth.Client.Should().Be(client);
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
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region CreateAuthorizationUrl

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlDefault()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlDefaultArgumentExceptions()
        {
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientId()
        {
            var clientId = "clientId";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdArgumentExceptions()
        {
            var clientId = "clientId";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(string.Empty);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUri()
        {
            var clientId = "clientId";
            var redirectUri = "redirect uri";

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUriArgumentExceptions()
        {
            var clientId = "clientId";
            var redirectUri = "redirect uri";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUriAndState()
        {
            var clientId = "clientId";
            var redirectUri = "redirect uri";
            var state = "custom state";

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri, state);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, state);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUriAndStateArgumentExceptions()
        {
            var clientId = "clientId";
            var redirectUri = "redirect uri";
            var state = "custom state";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(null, redirectUri, state);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(string.Empty, redirectUri, state);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, null, state);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, string.Empty, state);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateDefault()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var state = TestUtility.MOCK_TEST_CLIENT.Authentication.AntiForgeryToken;

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri, state);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateDefaultArgumentExceptions()
        {
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateAndClientId()
        {
            var clientId = "clientId";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var state = TestUtility.MOCK_TEST_CLIENT.Authentication.AntiForgeryToken;

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri, state);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateAndClientIdArgumentExceptions()
        {
            var clientId = "clientId";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(string.Empty);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateAndClientIdAndRedirectUri()
        {
            var clientId = "clientId";
            var redirectUri = "redirect uri";
            var state = TestUtility.MOCK_TEST_CLIENT.Authentication.AntiForgeryToken;

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri, state);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, redirectUri);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateAndClientIdAndRedirectUriArgumentExceptions()
        {
            var clientId = "clientId";
            var redirectUri = "redirect uri";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        private string BuildEncodedAuthorizeUrl(string clientId, string redirectUri, string state = null)
        {
            var baseUrl = TraktConstants.OAuthBaseAuthorizeUrl;
            var oauthAuthorizeUri = TraktConstants.OAuthAuthorizeUri;

            var uriParams = new Dictionary<string, string>();

            uriParams["response_type"] = "code";
            uriParams["client_id"] = clientId;
            uriParams["redirect_uri"] = redirectUri;

            if (!string.IsNullOrEmpty(state))
                uriParams["state"] = state;

            var encodedUriContent = new FormUrlEncodedContent(uriParams);
            var encodedUri = encodedUriContent.ReadAsStringAsync().Result;

            return $"{baseUrl}/{oauthAuthorizeUri}?{encodedUri}";
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetAccessToken

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAccessToken

        [TestMethod]
        public void TestTraktOAuthRefreshAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAccessToken

        [TestMethod]
        public void TestTraktOAuthRevokeAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithAccessTokenAndClientId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithAccessTokenAndClientIdExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithAccessTokenAndClientIdArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AuthenticationFlow

        [TestMethod]
        public void TestTraktOAuthCompleteAuthenticationFlow()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthCompleteAuthenticationFlowExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
