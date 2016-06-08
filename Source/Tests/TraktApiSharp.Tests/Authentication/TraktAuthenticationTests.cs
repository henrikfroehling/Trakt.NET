namespace TraktApiSharp.Tests.Authentication
{
    using Core;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
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

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken.Should().NotBeNull();
            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken.IsValid.Should().BeTrue();
            TestUtility.MOCK_TEST_CLIENT.Authentication.IsAuthenticated.Should().BeTrue();
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
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = 600,
                IntervalInSeconds = 5
            };

            var deviceJson = JsonConvert.SerializeObject(device);
            deviceJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"client_id\": \"{clientId}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceCodeUri, postContent, deviceJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync().Result;

            response.Should().NotBeNull();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device.Should().NotBeNull();
            TestUtility.MOCK_TEST_CLIENT.Authentication.Device.IsValid.Should().BeTrue();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAccessToken

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessToken()
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

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync().Result;

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
        public void TestTraktAuthenticationRefreshAccessTokenExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithToken()
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

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken).Result;

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
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientId()
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

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId).Result;

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
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, "client id");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecret()
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

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken,
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
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, null, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, string.Empty, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, "client id", clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, "client secret");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUri()
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

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken,
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
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAccessTokenWithTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, null, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, string.Empty, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, "client id", clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, "client secret", redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, clientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAccessTokenAsync(accessToken.RefreshToken, clientId, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAccessToken

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessToken()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithoutContent(uri, postContent, accessToken);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenExceptions()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenArgumentExceptions()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithToken()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithoutContent(uri, postContent, accessToken);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenExceptions()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenArgumentExceptions()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenAndClientId()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithoutContent(uri, postContent, accessToken, clientId);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenAndClientIdExceptions()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAccessTokenWithTokenAndClientIdArgumentExceptions()
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

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = new TraktAccessToken { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.AccessToken = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync("mock refresh token", clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.RefreshToken, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.RefreshToken, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAccessTokenAsync(accessToken.RefreshToken, "client id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
