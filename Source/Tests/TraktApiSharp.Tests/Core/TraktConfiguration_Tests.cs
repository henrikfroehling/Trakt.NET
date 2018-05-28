namespace TraktApiSharp.Tests.Core
{
    using FluentAssertions;
    using Traits;
    using Xunit;

    [Category("Core")]
    public class TraktConfiguration_Tests
    {
        [Fact]
        public void Test_TraktConfiguration_Default_Constructor()
        {
            var client = new TraktClient();

            client.Configuration.ApiVersion.Should().Be(2);
            client.Configuration.UseSandboxEnvironment.Should().BeFalse();
            client.Configuration.BaseUrl.Should().Be("https://api.trakt.tv/");
            client.Configuration.ForceAuthorization.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktConfiguration_UseSandboxEnvironment()
        {
            var client = new TraktClient();

            client.Configuration.UseSandboxEnvironment = true;
            client.Configuration.BaseUrl.Should().Be("https://api-staging.trakt.tv/");
        }
    }
}
