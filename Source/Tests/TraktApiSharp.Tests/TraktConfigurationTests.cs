namespace TraktApiSharp.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktConfigurationTests
    {
        [TestMethod]
        public void TestTraktConfigurationDefaultConstructor()
        {
            var client = new TraktClient();

            client.Configuration.ApiVersion.Should().Be(2);
            client.Configuration.UseStagingApi.Should().BeFalse();
            client.Configuration.BaseUrl.Should().Be("https://api-v2launch.trakt.tv/");

            client.Configuration.UseStagingApi = true;
            client.Configuration.BaseUrl.Should().Be("https://api-staging.trakt.tv/");
        }
    }
}
