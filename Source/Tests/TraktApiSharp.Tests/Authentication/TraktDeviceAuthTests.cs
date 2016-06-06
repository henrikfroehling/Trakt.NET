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

        #region GetAccessToken

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDevice()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceAndClientId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceAndClientIdExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceAndClientIdArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceAndClientIdAndClientSecret()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceAndClientIdAndClientSecretExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenWithDeviceAndClientIdAndClientSecretArgumentExceptions()
        {
            Assert.Fail();
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
