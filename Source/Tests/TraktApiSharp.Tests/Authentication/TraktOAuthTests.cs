namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
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

        #region Authorize

        [TestMethod]
        public void TestTraktOAuthAuthorize()
        {
            var clientID = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.OK);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync().Result;
            response.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeExceptions()
        {
            var clientID = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync();
            act.ShouldThrow<TraktAuthorizationException>();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeArgumentExceptions()
        {
            var client = new TraktClient();

            Func<Task<bool>> act = async () => await client.OAuth.AuthorizeAsync();
            act.ShouldThrow<ArgumentException>();

            client.ClientId = "client id";
            client.Authentication.RedirectUri = string.Empty;

            act = async () => await client.OAuth.AuthorizeAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithClientIdAndRedirectUri()
        {
            var clientID = "client id";
            var redirectUri = "redirect uri";

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.OK);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync(clientID, redirectUri).Result;
            response.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithClientIdAndRedirectUriExceptions()
        {
            var clientID = "client id";
            var redirectUri = "redirect uri";

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync(clientID, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithClientIdAndRedirectUriArgumentExceptions()
        {
            var clientId = "client id";
            var redirectUri = "redirect uri";

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync(null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync(string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync(clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeAsync(clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AuthorizeWithState

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithState()
        {
            var clientID = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var state = TestUtility.MOCK_TEST_CLIENT.Authentication.AntiForgeryToken;

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}&state={state}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.OK);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync().Result;
            response.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithStateExceptions()
        {
            var clientID = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var state = TestUtility.MOCK_TEST_CLIENT.Authentication.AntiForgeryToken;

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}&state={state}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync();
            act.ShouldThrow<TraktAuthorizationException>();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithStateArgumentExceptions()
        {
            var client = new TraktClient();

            Func<Task<bool>> act = async () => await client.OAuth.AuthorizeWithStateAsync();
            act.ShouldThrow<ArgumentException>();

            client.ClientId = "client id";
            client.Authentication.RedirectUri = string.Empty;

            act = async () => await client.OAuth.AuthorizeWithStateAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithStateAndClientIdAndRedirectUri()
        {
            var clientID = "client id";
            var redirectUri = "redirect uri";
            var state = "custom state";

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}&state={state}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.OK);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(clientID, redirectUri, state).Result;
            response.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithStateAndClientIdAndRedirectUriExceptions()
        {
            var clientID = "client id";
            var redirectUri = "redirect uri";
            var state = "custom state";

            var uri = $"oauth/authorize?response_type=code&client_id={clientID}&redirect_uri={redirectUri}&state={state}";

            TestUtility.SetupMockOAuthAuthorizeResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(clientID, redirectUri, state);
            act.ShouldThrow<TraktAuthorizationException>();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithStateAndClientIdAndRedirectUriArgumentExceptions()
        {
            var clientId = "client id";
            var redirectUri = "redirect uri";

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.AuthorizeWithStateAsync(clientId, redirectUri, string.Empty);
            act.ShouldThrow<ArgumentException>();
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
