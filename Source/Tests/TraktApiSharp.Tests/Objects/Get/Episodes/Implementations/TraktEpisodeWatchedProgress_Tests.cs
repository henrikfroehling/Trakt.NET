namespace TraktApiSharp.Tests.Objects.Get.Episodes.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.Implementations")]
    public class TraktEpisodeWatchedProgress_Tests
    {
        [Fact]
        public void Test_TraktEpisodeWatchedProgress_Inherits_TraktEpisodeProgress()
        {
            typeof(TraktEpisodeWatchedProgress).IsSubclassOf(typeof(TraktEpisodeProgress)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeWatchedProgress_Implements_ITraktEpisodeWatchedProgress_Interface()
        {
            typeof(TraktEpisodeWatchedProgress).GetInterfaces().Should().Contain(typeof(ITraktEpisodeWatchedProgress));
        }

        [Fact]
        public void Test_TraktEpisodeWatchedProgress_Default_Constructor()
        {
            var episodeWatchedProgress = new TraktEpisodeWatchedProgress();

            episodeWatchedProgress.Number.Should().NotHaveValue();
            episodeWatchedProgress.Completed.Should().NotHaveValue();
            episodeWatchedProgress.LastWatchedAt.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktEpisodeWatchedProgress_From_Json()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();
            var episodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON);

            episodeWatchedProgress.Should().NotBeNull();
            episodeWatchedProgress.Number.Should().Be(2);
            episodeWatchedProgress.Completed.Should().BeFalse();
            episodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""number"": 2,
                ""completed"": false,
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";
    }
}
