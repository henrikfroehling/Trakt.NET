namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktDeviceAuthTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var client = new TraktClient();

            client.DeviceAuth.Client.Should().Be(client);
        }

        [TestMethod]
        public void TestGenerateDeviceAsync()
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
