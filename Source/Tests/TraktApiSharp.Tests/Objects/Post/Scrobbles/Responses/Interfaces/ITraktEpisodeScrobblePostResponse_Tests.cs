namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.Interfaces")]
    public class ITraktEpisodeScrobblePostResponse_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeScrobblePostResponse_Is_Interface()
        {
            typeof(ITraktEpisodeScrobblePostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeScrobblePostResponse_Inherits_ITraktScrobblePostResponse_Interface()
        {
            typeof(ITraktEpisodeScrobblePostResponse).GetInterfaces().Should().Contain(typeof(ITraktScrobblePostResponse));
        }

        [Fact]
        public void Test_ITraktEpisodeScrobblePostResponse_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }

        [Fact]
        public void Test_ITraktEpisodeScrobblePostResponse_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
