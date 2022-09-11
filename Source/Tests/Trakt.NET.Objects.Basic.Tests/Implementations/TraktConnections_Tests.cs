namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktConnections_Tests
    {
        [Fact]
        public void Test_TraktConnections_Default_Constructor()
        {
            var traktConnections = new TraktConnections();

            traktConnections.Twitter.Should().BeNull();
            traktConnections.Google.Should().BeNull();
            traktConnections.Tumblr.Should().BeNull();
            traktConnections.Medium.Should().BeNull();
            traktConnections.Slack.Should().BeNull();
            traktConnections.Facebook.Should().BeNull();
            traktConnections.Apple.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktConnections_From_Json()
        {
            var jsonReader = new ConnectionsObjectJsonReader();
            var traktConnections = await jsonReader.ReadObjectAsync(JSON) as TraktConnections;

            traktConnections.Should().NotBeNull();
            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";
    }
}
