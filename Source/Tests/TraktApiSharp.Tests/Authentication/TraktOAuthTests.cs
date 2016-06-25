namespace TraktApiSharp.Tests.Authentication
{
    using Core;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
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
            TestUtility.SetDefaultClientValues();
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

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

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

            clientId = "client id";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUri()
        {
            var clientId = "clientId";
            var redirectUri = "redirectUri";

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUriArgumentExceptions()
        {
            var clientId = "clientId";
            var redirectUri = "redirectUri";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            redirectUri = "redirect uri";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUriAndState()
        {
            var clientId = "clientId";
            var redirectUri = "redirectUri";
            var state = "customState";

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri, state);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, state);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithClientIdAndRedirectUriAndStateArgumentExceptions()
        {
            var clientId = "clientId";
            var redirectUri = "redirectUri";
            var state = "customState";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(null, redirectUri, state);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(string.Empty, redirectUri, state);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, state);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, null, state);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, string.Empty, state);
            act.ShouldThrow<ArgumentException>();

            redirectUri = "redirect uri";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, state);
            act.ShouldThrow<ArgumentException>();

            redirectUri = "redirectUri";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, string.Empty);
            act.ShouldThrow<ArgumentException>();

            state = "custom state";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrl(clientId, redirectUri, state);
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

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

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

            clientId = "client id";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateAndClientIdAndRedirectUri()
        {
            var clientId = "clientId";
            var redirectUri = "redirectUri";
            var state = TestUtility.MOCK_TEST_CLIENT.Authentication.AntiForgeryToken;

            var encodedUrl = BuildEncodedAuthorizeUrl(clientId, redirectUri, state);

            var createdUrl = TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, redirectUri);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [TestMethod]
        public void TestTraktOAuthCreateAuthorizationUrlWithDefaultStateAndClientIdAndRedirectUriArgumentExceptions()
        {
            var clientId = "clientId";
            var redirectUri = "redirectUri";

            Action act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            redirectUri = "redirect uri";

            act = () => TestUtility.MOCK_TEST_CLIENT.OAuth.CreateAuthorizationUrlWithDefaultState(clientId, redirectUri);
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
        public void TestTraktOAuthGetAccessToken()
        {
            var mockAuthCode = "mockAuthCode";
            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = mockAuthCode;

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync().Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenExceptions()
        {
            var mockAuthCode = "mockAuthCode";
            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = mockAuthCode;

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on retrieving oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationOAuthException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenArgumentExceptions()
        {
            var mockAuthCode = "mockAuthCode";

            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = null;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = "mock auth code";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = mockAuthCode;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCode()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeExceptions()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on retrieving oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktAuthenticationOAuthException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeArgumentExceptions()
        {
            var mockAuthCode = "mockAuthCode";

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mock auth code";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mockAuthCode";
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientId()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdExceptions()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on retrieving oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktAuthenticationOAuthException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdArgumentExceptions()
        {
            var mockAuthCode = "mockAuthCode";
            var clientId = "clientId";

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mock auth code";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mockAuthCode";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, string.Empty);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecret()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretExceptions()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on retrieving oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationOAuthException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretArgumentExceptions()
        {
            var mockAuthCode = "mockAuthCode";
            var clientId = "clientId";
            var clientSecret = "clientSecret";

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mock auth code";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mockAuthCode";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, null, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, string.Empty, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            clientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUri()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            var mockAuthCode = "mockAuthCode";

            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.AsString();

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on retrieving oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"code\": \"{mockAuthCode}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationOAuthException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            var mockAuthCode = "mockAuthCode";
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mock auth code";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            mockAuthCode = "mockAuthCode";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, null, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, string.Empty, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            clientSecret = "clientSecret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, string.Empty);
            act.ShouldThrow<ArgumentException>();

            redirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.GetAccessTokenAsync(mockAuthCode, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAccessToken

        [TestMethod]
        public void TestTraktOAuthRefreshAccessToken()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync().Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenExceptions()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithToken()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenExceptions()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientId()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdExceptions()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, "client id");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdAndClientSecret()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken,
                                                                                      clientId, clientSecret).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdAndClientSecretExceptions()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdAndClientSecretArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, null, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, string.Empty, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, "client id", clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, "client secret");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken,
                                                                                      clientId, clientSecret,
                                                                                      redirectUri).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsValid.Should().BeTrue();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.RefreshToken.AsString();

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var error = new TraktError
            {
                Error = "invalid_grant",
                Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
            };

            var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
                               $"description: {error.Description}";

            var errorJson = JsonConvert.SerializeObject(error);
            errorJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            var uri = TraktConstants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, null, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, string.Empty, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, "client id", clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, "client secret", redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAccessToken

        [TestMethod]
        public void TestTraktOAuthRevokeAccessToken()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"access_token\": \"{accessToken.AccessToken}\" }}";

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.SetupMockAuthenticationResponse(uri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithoutContent(uri, postContent, accessToken);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithToken()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"access_token\": \"{accessToken.AccessToken}\" }}";

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.SetupMockAuthenticationResponse(uri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithoutContent(uri, postContent, accessToken);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithTokenExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithTokenArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithTokenAndClientId()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"access_token\": \"{accessToken.AccessToken}\" }}";

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.SetupMockAuthenticationResponse(uri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithoutContent(uri, postContent, accessToken, clientId);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithTokenAndClientIdExceptions()
        {
            var clientId = "clientId";

            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithTokenAndClientIdArgumentExceptions()
        {
            var accessToken = new TraktAccessToken
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.RefreshToken, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.RefreshToken, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.OAuth.RevokeAccessTokenAsync(accessToken.RefreshToken, "client id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
