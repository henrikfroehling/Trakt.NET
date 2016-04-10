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
        public void TestTraktOAuthAuthorizeAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktOAuthGetAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktOAuthRefreshAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktOAuthRevokeAccessTokenAsync()
        {
            // TODO
        }
    }
}
