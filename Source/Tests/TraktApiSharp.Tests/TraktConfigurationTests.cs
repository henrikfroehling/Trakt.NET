namespace TraktApiSharp.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktConfigurationTests
    {
        [TestMethod]
        public void TestTraktConfigurationDefaultConstructor()
        {
            var client = new TraktClient();

            client.Configuration.ApiVersion.Should().Be(2);
            client.Configuration.AuthenticationMode.Should().Be(TraktAuthenticationMode.Device);
            client.Configuration.BaseUrl.Should().Be("https://api-v2launch.trakt.tv/");

            client.Configuration.BaseUri.Should().NotBeNull();
            client.Configuration.BaseUri.OriginalString.Should().Be("https://api-v2launch.trakt.tv/");
        }
    }
}
