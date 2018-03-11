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
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Utils;
    using Utils;

    [TestClass]
    public class TraktAuthenticationTests
    {
        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";
        private const string ACCESS_TOKEN = "ACCESS_TOKEN";
        private const string REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        [TestMethod]
        public void TestTraktAuthenticationConstructor()
        {
            var client = new TraktClient();

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeFalse();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().BeNull();
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidAccessToken()
        {
            var client = new TraktClient() { Authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN) };

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeFalse();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().BeNull();
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            client.Authentication.Authorization.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidClientId()
        {
            var client = new TraktClient(CLIENT_ID);

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().Be(CLIENT_ID);
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidClientIdAndAccessToken()
        {
            var client = new TraktClient(CLIENT_ID) { Authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN) };

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeTrue();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().Be(CLIENT_ID);
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            client.Authentication.Authorization.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidClientIdAndClientSecret()
        {
            var client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeTrue();

            client.Authentication.ClientId.Should().Be(CLIENT_ID);
            client.Authentication.ClientSecret.Should().Be(CLIENT_SECRET);
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktAuthenticationConstructorWithValidClientIdAndClientSecretAndAccessToken()
        {
            var client = new TraktClient(CLIENT_ID, CLIENT_SECRET) { Authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN) };

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeTrue();
            client.IsValidForAuthenticationProcess.Should().BeTrue();

            client.Authentication.ClientId.Should().Be(CLIENT_ID);
            client.Authentication.ClientSecret.Should().Be(CLIENT_SECRET);
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            client.Authentication.Authorization.IsExpired.Should().BeFalse();
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
        public void TestTraktAuthenticationGetAuthorization()
        {
            var client = new TraktClient();

            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
            client.Authentication.IsAuthorized.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationGetAuthorizationWithValidClient()
        {
            var mockAuthCode = "mockAuthCode";
            TestUtility.MOCK_TEST_CLIENT.Authentication.OAuthAuthorizationCode = mockAuthCode;

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.AuthorizationCode.ObjectName;

            var accessToken = new TraktAuthorization
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.OAuth.GetAuthorizationAsync().Result;

            response.Should().NotBeNull();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization.Should().NotBeNull();
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization.IsExpired.Should().BeFalse();
            TestUtility.MOCK_TEST_CLIENT.Authentication.IsAuthorized.Should().BeTrue();
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceCodeUri, postContent, deviceJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync().Result;

            response.Should().NotBeNull();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device.Should().NotBeNull();
            TestUtility.MOCK_TEST_CLIENT.Authentication.Device.IsValid.Should().BeTrue();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedSuccess()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            // "Fake-Request" is sync/last_activities
            var lastActivities = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Activities\SyncLastActivities.json");
            lastActivities.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/last_activities", lastActivities, authorization);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync().Result;

            response.Should().NotBeNull();
            response.First.Should().BeFalse();
            response.Second.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedWithAuthorizationSuccess()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            // "Fake-Request" is sync/last_activities
            var lastActivities = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Activities\SyncLastActivities.json");
            lastActivities.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/last_activities", lastActivities, authorization);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization).Result;

            response.Should().NotBeNull();
            response.First.Should().BeFalse();
            response.Second.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedFailedExpired()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authorization = authorization;

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync().Result;

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedWithAuthorizationFailedExpired()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization).Result;

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedFailedRevoked()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.SetupMockResponseWithOAuth("sync/last_activities", HttpStatusCode.Unauthorized, authorization);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync().Result;

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedWithAuthorizationFailedRevoked()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.SetupMockResponseWithOAuth("sync/last_activities", HttpStatusCode.Unauthorized, authorization);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization).Result;

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedFailedRevokedAutoRefresh()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var authorizationJson = JsonConvert.SerializeObject(authorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{authorization.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            // First response, if authorization was revoked
            TestUtility.AddMockExpectationResponse("sync/last_activities", HttpStatusCode.Unauthorized, authorization);

            // Second response for autoRefresh == true
            TestUtility.AddMockExpectationResponse(Constants.OAuthTokenUri, postContent, authorizationJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(true).Result;

            TestUtility.VerifyNoOutstandingExceptations();

            response.Should().NotBeNull();
            response.First.Should().BeTrue();

            var responseAuthoriation = response.Second;

            responseAuthoriation.Should().NotBeNull();
            responseAuthoriation.AccessToken.Should().Be(authorization.AccessToken);
            responseAuthoriation.TokenType.Should().Be(authorization.TokenType);
            responseAuthoriation.ExpiresInSeconds.Should().Be(authorization.ExpiresInSeconds);
            responseAuthoriation.RefreshToken.Should().Be(authorization.RefreshToken);
            responseAuthoriation.AccessScope.Should().Be(authorization.AccessScope);
            responseAuthoriation.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            responseAuthoriation.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(responseAuthoriation.AccessToken);
            clientAccessToken.TokenType.Should().Be(responseAuthoriation.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(responseAuthoriation.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(responseAuthoriation.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(responseAuthoriation.AccessScope);
            clientAccessToken.Created.Should().Be(responseAuthoriation.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedWithAuthorizationFailedRevokedAutoRefresh()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var authorizationJson = JsonConvert.SerializeObject(authorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{authorization.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            // First response, if authorization was revoked
            TestUtility.AddMockExpectationResponse("sync/last_activities", HttpStatusCode.Unauthorized, authorization);

            // Second response for autoRefresh == true
            TestUtility.AddMockExpectationResponse(Constants.OAuthTokenUri, postContent, authorizationJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization, true).Result;

            TestUtility.VerifyNoOutstandingExceptations();

            response.Should().NotBeNull();
            response.First.Should().BeTrue();

            var responseAuthoriation = response.Second;

            responseAuthoriation.Should().NotBeNull();
            responseAuthoriation.AccessToken.Should().Be(authorization.AccessToken);
            responseAuthoriation.TokenType.Should().Be(authorization.TokenType);
            responseAuthoriation.ExpiresInSeconds.Should().Be(authorization.ExpiresInSeconds);
            responseAuthoriation.RefreshToken.Should().Be(authorization.RefreshToken);
            responseAuthoriation.AccessScope.Should().Be(authorization.AccessScope);
            responseAuthoriation.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            responseAuthoriation.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(responseAuthoriation.AccessToken);
            clientAccessToken.TokenType.Should().Be(responseAuthoriation.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(responseAuthoriation.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(responseAuthoriation.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(responseAuthoriation.AccessScope);
            clientAccessToken.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedExceptions()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = "sync/last_activities";

            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound, authorization);

            Func<Task<Pair<bool, TraktAuthorization>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest, authorization);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden, authorization);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed, authorization);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict, authorization);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError, authorization);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway, authorization);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412, authorization);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422, authorization);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429, authorization);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522, authorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedWithAuthorizationExceptions()
        {
            var authorization = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = "sync/last_activities";

            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound, authorization);

            Func<Task<Pair<bool, TraktAuthorization>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest, authorization);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden, authorization);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed, authorization);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict, authorization);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError, authorization);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway, authorization);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412, authorization);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422, authorization);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429, authorization);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521, authorization);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522, authorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAuthorizationIsExpiredOrWasRevokedWithAuthorizationArgumentExceptions()
        {
            Func<Task<Pair<bool, TraktAuthorization>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(null);
            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAccessTokenWasRevokedOrIsNotValidSuccess()
        {
            var accessToken = "mockAccessToken";

            // "Fake-Request" is sync/last_activities
            var lastActivities = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Activities\SyncLastActivities.json");
            lastActivities.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuthWithToken("sync/last_activities", lastActivities, accessToken);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(accessToken).Result;
            response.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAccessTokenWasRevokedOrIsNotValidFailed()
        {
            var accessToken = "mockAccessToken";

            TestUtility.SetupMockResponseWithOAuthWithToken("sync/last_activities", HttpStatusCode.Unauthorized, accessToken);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(accessToken).Result;
            response.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAccessTokenWasRevokedOrIsNotValidExceptions()
        {
            var accessToken = "mockAccessToken";
            var uri = "sync/last_activities";

            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.NotFound, accessToken);

            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(accessToken);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.BadRequest, accessToken);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.Forbidden, accessToken);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.MethodNotAllowed, accessToken);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.Conflict, accessToken);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.InternalServerError, accessToken);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, HttpStatusCode.BadGateway, accessToken);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)412, accessToken);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)422, accessToken);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)429, accessToken);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)503, accessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)504, accessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)520, accessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)521, accessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuthWithToken(uri, (HttpStatusCode)522, accessToken);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationCheckIfAccessTokenWasRevokedOrIsNotValidArgumentExceptions()
        {
            Func<Task<bool>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync("access token");
            act.Should().Throw<ArgumentException>();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAuthorization

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorization()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync().Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationExceptions()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            var uri = Constants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithToken()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenExceptions()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            var uri = Constants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientId()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdExceptions()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            var uri = Constants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id");
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdAndClientSecret()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken,
                                                                                               clientId, clientSecret).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdAndClientSecretExceptions()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            var uri = Constants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdAndClientSecretArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, null, clientSecret);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty, clientSecret);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id", clientSecret);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "client secret");
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken,
                                                                                               clientId, clientSecret,
                                                                                               redirectUri).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
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

            var uri = Constants.OAuthTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
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

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, null, clientSecret, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty, clientSecret, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id", clientSecret, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, null, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty, redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "client secret", redirectUri);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "redirect uri");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAuthorization

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorization()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var postContent = $"token={accessToken.AccessToken}";

            var uri = Constants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
            TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().NotThrow();

            var authorization = TestUtility.MOCK_TEST_CLIENT.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.Created.Should().BeCloseTo(DateTime.UtcNow, 1000);
            authorization.ExpiresInSeconds.Should().Be(0);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = Constants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationWithToken()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var postContent = $"token={accessToken.AccessToken}";

            var uri = Constants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
            TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().NotThrow();

            var authorization = TestUtility.MOCK_TEST_CLIENT.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.Created.Should().BeCloseTo(DateTime.UtcNow, 1000);
            authorization.ExpiresInSeconds.Should().Be(0);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationWithTokenExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = Constants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationWithTokenArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.RefreshToken);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationWithTokenAndClientId()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var postContent = $"token={accessToken.AccessToken}";

            var uri = Constants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
            TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().NotThrow();

            var authorization = TestUtility.MOCK_TEST_CLIENT.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.Created.Should().BeCloseTo(DateTime.UtcNow, 1000);
            authorization.ExpiresInSeconds.Should().Be(0);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationWithTokenAndClientIdExceptions()
        {
            var clientId = "clientId";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = Constants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktAuthenticationRevokeAuthorizationWithTokenAndClientIdArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";

            TestUtility.MOCK_TEST_CLIENT.Authorization = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(null, clientId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(string.Empty, clientId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.RefreshToken, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.RefreshToken, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Authentication.RevokeAuthorizationAsync(accessToken.RefreshToken, "client id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
