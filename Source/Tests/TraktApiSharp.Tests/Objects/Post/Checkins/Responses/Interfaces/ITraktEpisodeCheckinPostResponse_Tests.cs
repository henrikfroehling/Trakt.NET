namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Interfaces")]
    public class ITraktEpisodeCheckinPostResponse_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeCheckinPostResponse_Is_Interface()
        {
            typeof(ITraktEpisodeCheckinPostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeCheckinPostResponse_Inherits_ITraktCheckinPostResponse_Interface()
        {
            typeof(ITraktEpisodeCheckinPostResponse).GetInterfaces().Should().Contain(typeof(ITraktCheckinPostResponse));
        }

        [Fact]
        public void Test_ITraktEpisodeCheckinPostResponse_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeCheckinPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }

        [Fact]
        public void Test_ITraktEpisodeCheckinPostResponse_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeCheckinPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
