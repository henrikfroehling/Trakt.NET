namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktDeviceAuthTests
    {
        [TestMethod]
        public void TestTraktDeviceAuthDefaultConstructor()
        {
            var client = new TraktClient();

            client.DeviceAuth.Client.Should().Be(client);
        }

        [TestMethod]
        public void TestTraktDeviceAuthGenerateDeviceAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktDeviceAuthGetAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktDeviceAuthRefreshAccessTokenAsync()
        {
            // TODO
        }

        [TestMethod]
        public void TestTraktDeviceAuthRevokeAccessTokenAsync()
        {
            // TODO
        }
    }
}
