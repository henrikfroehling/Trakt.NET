namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktOAuthTests
    {
        [TestMethod]
        public void TestTraktOAuthDefaultConstructor()
        {
            var client = new TraktClient();

            client.OAuth.Client.Should().Be(client);
        }

        [TestMethod]
        public void TestTraktOAuthAuthorize()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithClientIdAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithState()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthAuthorizeWithStateAndClientIdAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenWithCodeAndClientIdAndClientSecretAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenWithRefreshTokenAndClientIdAndClientSecretAndRedirectUri()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessToken()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenWithAccessTokenAndClientId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktOAuthCompleteAuthenticationFlow()
        {
            Assert.Fail();
        }
    }
}
