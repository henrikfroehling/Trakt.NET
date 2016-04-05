namespace TraktApiSharp.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktClientTests
    {
        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";

        [TestMethod]
        public void TestDefaultConstructor()
        {
            var client = new TraktClient();

            client.ClientId.Should().BeNull();
            client.ClientSecret.Should().BeNull();

            client.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestParameterConstructor()
        {
            var client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client.ClientId.Should().Be(CLIENT_ID);
            client.ClientSecret.Should().Be(CLIENT_SECRET);

            client.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestGetConfiguration()
        {
            var client = new TraktClient();

            client.Configuration.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetAuthentication()
        {
            var client = new TraktClient();

            client.Authentication.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetOAuth()
        {
            var client = new TraktClient();

            client.OAuth.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetDeviceAuth()
        {
            var client = new TraktClient();

            client.DeviceAuth.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetShowsModule()
        {
            var client = new TraktClient();

            client.Shows.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetSeasonsModule()
        {
            var client = new TraktClient();

            client.Seasons.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetEpisodesModule()
        {
            var client = new TraktClient();

            client.Episodes.Should().NotBeNull();
        }

        [TestMethod]
        public void TestGetMoviesModule()
        {
            var client = new TraktClient();

            client.Movies.Should().NotBeNull();
        }
    }
}
