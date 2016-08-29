namespace TraktApiSharp.Tests.Authentication
{
    using Core;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktDeviceAuthTests
    {
        [TestMethod]
        public void TestTraktDeviceAuthDefaultConstructor()
        {
            var client = new TraktClient();

            client.DeviceAuth.Client.Should().Be(client);
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

        #region GenerateDevice

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDevice()
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
            response.DeviceCode.Should().Be(device.DeviceCode);
            response.UserCode.Should().Be(device.UserCode);
            response.VerificationUrl.Should().Be(device.VerificationUrl);
            response.ExpiresInSeconds.Should().Be(device.ExpiresInSeconds);
            response.IntervalInSeconds.Should().Be(device.IntervalInSeconds);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpiredUnused.Should().BeFalse();
            response.IsValid.Should().BeTrue();

            var clientDevice = TestUtility.MOCK_TEST_CLIENT.Authentication.Device;

            clientDevice.Should().NotBeNull();
            clientDevice.DeviceCode.Should().Be(response.DeviceCode);
            clientDevice.UserCode.Should().Be(response.UserCode);
            clientDevice.VerificationUrl.Should().Be(response.VerificationUrl);
            clientDevice.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientDevice.IntervalInSeconds.Should().Be(response.IntervalInSeconds);
            clientDevice.Created.Should().Be(response.Created);
            clientDevice.IsExpiredUnused.Should().BeFalse();
            clientDevice.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceExceptions()
        {
            var uri = TraktConstants.OAuthDeviceCodeUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktRateLimitException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceArgumentExceptions()
        {
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceWithClientId()
        {
            var clientId = "clientId";

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

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId).Result;

            response.Should().NotBeNull();
            response.DeviceCode.Should().Be(device.DeviceCode);
            response.UserCode.Should().Be(device.UserCode);
            response.VerificationUrl.Should().Be(device.VerificationUrl);
            response.ExpiresInSeconds.Should().Be(device.ExpiresInSeconds);
            response.IntervalInSeconds.Should().Be(device.IntervalInSeconds);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpiredUnused.Should().BeFalse();
            response.IsValid.Should().BeTrue();

            var clientDevice = TestUtility.MOCK_TEST_CLIENT.Authentication.Device;

            clientDevice.Should().NotBeNull();
            clientDevice.DeviceCode.Should().Be(response.DeviceCode);
            clientDevice.UserCode.Should().Be(response.UserCode);
            clientDevice.VerificationUrl.Should().Be(response.VerificationUrl);
            clientDevice.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
            clientDevice.IntervalInSeconds.Should().Be(response.IntervalInSeconds);
            clientDevice.Created.Should().Be(response.Created);
            clientDevice.IsExpiredUnused.Should().BeFalse();
            clientDevice.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceWithClientIdExceptions()
        {
            var clientId = "clientId";

            var uri = TraktConstants.OAuthDeviceCodeUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktRateLimitException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceWithClientIdArgumentExceptions()
        {
            Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            var clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PollForAuthorization

        private static readonly int DEVICE_EXPIRES_IN_SECONDS = 60;
        private static readonly int DEVICE_INTERVAL_IN_SECONDS = 6;
        private static readonly int POLLING_DELAY_IN_MILLISECONDS = 9 * 1000;

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorization()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync().Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        // Run this test only individually
        //[TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationPolling()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync().Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

            var uri = TraktConstants.OAuthDeviceTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationDeviceException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationArgumentExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = null };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice
            {
                DeviceCode = string.Empty,
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice
            {
                DeviceCode = "mock device code",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = "mockDeviceCode" };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDevice()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        // Run this test only individually
        //[TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDevicePolling()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var uri = TraktConstants.OAuthDeviceTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<TraktAuthenticationDeviceException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceArgumentExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = string.Empty,
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = "mock device code",
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                });
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice { DeviceCode = "mockDeviceCode" });
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientId()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        // Run this test only individually
        //[TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientIdPolling()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientIdExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var clientId = "clientId";

            var uri = TraktConstants.OAuthDeviceTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<TraktAuthenticationDeviceException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationithDeviceAndClientIdArgumentExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var clientId = "clientId";

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(null, clientId);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = string.Empty,
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                }, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = "mock device code",
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                }, clientId);
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice { DeviceCode = "mockDeviceCode" }, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, string.Empty);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientIdAndClientSecret()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        // Run this test only individually
        //[TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientIdAndClientSecretPolling()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";

            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientIdAndClientSecretExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";

            var uri = TraktConstants.OAuthDeviceTokenUri;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationDeviceException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationDeviceException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAuthorizationWithDeviceAndClientIdAndClientSecretArgumentExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = string.Empty,
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                },
                clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = "mock device code",
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                },
                clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
                new TraktDevice { DeviceCode = "mockDeviceCode" },
                clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, null, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, string.Empty, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            clientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAuthorization

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorization()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync().Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationExceptions()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
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
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithToken()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenExceptions()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
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
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientId()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdExceptions()
        {
            var clientId = "clientId";
            var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
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
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdAndClientSecret()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken,
                                                                                           clientId, clientSecret).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdAndClientSecretExceptions()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
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
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdAndClientSecretArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, null, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id", clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "client secret");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var accessTokenJson = JsonConvert.SerializeObject(accessToken);
            accessTokenJson.Should().NotBeNullOrEmpty();

            var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
                              $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
                              $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken,
                                                                                           clientId, clientSecret,
                                                                                           redirectUri).Result;

            response.Should().NotBeNull();
            response.AccessToken.Should().Be(accessToken.AccessToken);
            response.TokenType.Should().Be(accessToken.TokenType);
            response.ExpiresIn.Should().Be(accessToken.ExpiresIn);
            response.RefreshToken.Should().Be(accessToken.RefreshToken);
            response.AccessScope.Should().Be(accessToken.AccessScope);
            response.Created.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            response.IsExpired.Should().BeFalse();

            var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(response.AccessToken);
            clientAccessToken.TokenType.Should().Be(response.TokenType);
            clientAccessToken.ExpiresIn.Should().Be(response.ExpiresIn);
            clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
            clientAccessToken.AccessScope.Should().Be(response.AccessScope);
            clientAccessToken.Created.Should().Be(response.Created);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";
            var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
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
            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthenticationException>().WithMessage(errorMessage);

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";
            var clientSecret = "clientSecret";
            var redirectUri = "redirectUri";

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, null, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty, clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id", clientSecret, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, null, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty, redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "client secret", redirectUri);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAuthorization

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorization()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var postContent = $"token={accessToken.AccessToken}";

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;
            TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockAuthenticationTokenRevokeResponseWithToken(uri, postContent, accessToken);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationWithToken()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var postContent = $"token={accessToken.AccessToken}";

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;
            TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockAuthenticationTokenRevokeResponseWithToken(uri, postContent, accessToken);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationWithTokenExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationWithTokenArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationWithTokenAndClientId()
        {
            var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var postContent = $"token={accessToken.AccessToken}";

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;
            TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldNotThrow();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockAuthenticationTokenRevokeResponseWithToken(uri, postContent, accessToken, clientId);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationWithTokenAndClientIdExceptions()
        {
            var clientId = "clientId";

            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var uri = TraktConstants.OAuthRevokeUri;

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktAuthenticationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAuthorizationWithTokenAndClientIdArgumentExceptions()
        {
            var accessToken = new TraktAuthorization
            {
                AccessToken = "mockAccessToken",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresIn = 7200,
                RefreshToken = "mockRefreshToken",
                AccessScope = TraktAccessScope.Public
            };

            var clientId = "clientId";

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = null;

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 7200 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresIn = 0 };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Authorization = accessToken;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken, "client id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
