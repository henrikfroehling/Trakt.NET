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
            client.Configuration.UseStagingUrl.Should().BeFalse();
            client.Configuration.BaseUrl.Should().Be("https://api.trakt.tv/");
            client.Configuration.ForceAuthorization.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktConfigurationUseStaging()
        {
            var client = new TraktClient();

            client.Configuration.UseStagingUrl = true;
            client.Configuration.BaseUrl.Should().Be("https://api-staging.trakt.tv/");
        }
    }
}
