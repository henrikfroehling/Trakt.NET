namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceArgumentExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceWithClientId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceWithClientIdExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceWithClientIdArgumentExceptions()
        {
            Assert.Fail();
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
