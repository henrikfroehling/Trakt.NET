namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktOAuthTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var client = new TraktClient();

            client.OAuth.Client.Should().Be(client);
        }

        [TestMethod]
        public void TestAuthorizeAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestGetAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestRefreshAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestRevokeAccessTokenAsync()
        {
            // TODO
        }
    }
}
