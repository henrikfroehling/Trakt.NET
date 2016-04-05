namespace TraktApiSharp.Tests
{
    using Enums;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktConfigurationTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
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
