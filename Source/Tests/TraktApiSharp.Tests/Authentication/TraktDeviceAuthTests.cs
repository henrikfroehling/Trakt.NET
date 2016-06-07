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
            TestUtility.SetupMockGetAccessTokenErrorResponse(TraktConstants.OAuthDeviceCodeUri, HttpStatusCode.NotFound);

            var errorMessage = "error on generating authentication device";

            Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
            act.ShouldThrow<TraktAuthenticationDeviceException>().WithMessage(errorMessage);
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

            TestUtility.SetupMockGetAccessTokenErrorResponse(TraktConstants.OAuthDeviceCodeUri, HttpStatusCode.NotFound);

            var errorMessage = "error on generating authentication device";

            Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
            act.ShouldThrow<TraktAuthenticationDeviceException>().WithMessage(errorMessage);
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

        #region PollAccessToken

        private static readonly int DEVICE_EXPIRES_IN_SECONDS = 10;
        private static readonly int DEVICE_INTERVAL_IN_SECONDS = 6;
        private static readonly int POLLING_DELAY_IN_MILLISECONDS = 9 * 1000;

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessToken()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);
            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync().Result;

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

        //[TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenPolling()
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

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync().Result;

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
        public void TestTraktDeviceAuthPollForAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = null };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = string.Empty };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = "mock device code" };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = "mockDeviceCode" };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;
            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDevice()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device).Result;

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

        //[TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDevicePolling()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device).Result;

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
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceArgumentExceptions()
        {
            var device = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "5055CC52",
                VerificationUrl = "https://trakt.tv/activate",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
                IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
            };

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = string.Empty });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = "mock device code" });
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = "mockDeviceCode" });
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientId()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId).Result;

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

        //[TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientIdPolling()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId).Result;

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
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientIdExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenithDeviceAndClientIdArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = string.Empty }, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = "mock device code" }, clientId);
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = "mockDeviceCode" }, clientId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, string.Empty);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";
            TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();

            TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientIdAndClientSecret()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId, clientSecret).Result;

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

        //[TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientIdAndClientSecretPolling()
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

            TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

            var timer = new Timer(x =>
            {
                //Debug.WriteLine("Delayed Http Status Code Change");
                TestUtility.ClearMockHttpClient();
                TestUtility.SetupMockAuthenticationResponse(TraktConstants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
            }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

            var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId, clientSecret).Result;

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
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientIdAndClientSecretExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthPollForAccessTokenWithDeviceAndClientIdAndClientSecretArgumentExceptions()
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

            Func<Task<TraktAccessToken>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync();
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(null, clientId);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = string.Empty },
                                                                                                 clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = "mock device code" },
                                                                                                 clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(new TraktDevice { DeviceCode = "mockDeviceCode" },
                                                                                                 clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, null, clientSecret);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, string.Empty, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientId = "client id";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();

            clientId = "clientId";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            clientSecret = "client secret";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAccessTokenAsync(device, clientId, clientSecret);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RefreshAccessToken

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RevokeAccessToken

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAccessTokenWithAccessTokenAndClientId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAccessTokenWithAccessTokenAndClientIdExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAccessTokenWithAccessTokenAndClientIdArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AuthenticationFlow

        [TestMethod]
        public void TestTraktDeviceAuthCompleteAuthenticationFlow()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthCompleteAuthenticationFlowExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
