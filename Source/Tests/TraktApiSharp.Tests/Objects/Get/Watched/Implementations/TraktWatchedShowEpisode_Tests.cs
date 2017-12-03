namespace TraktApiSharp.Tests.Objects.Get.Watched.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.Implementations;
    using TraktApiSharp.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.Implementations")]
    public class TraktWatchedShowEpisode_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowEpisode_Default_Constructor()
        {
            var watchedShowEpisode = new TraktWatchedShowEpisode();

            watchedShowEpisode.Number.Should().BeNull();
            watchedShowEpisode.Plays.Should().BeNull();
            watchedShowEpisode.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchedShowEpisode_From_Json()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();
            var watchedShowEpisode = await jsonReader.ReadObjectAsync(JSON) as TraktWatchedShowEpisode;

            watchedShowEpisode.Should().NotBeNull();
            watchedShowEpisode.Number.Should().Be(1);
            watchedShowEpisode.Plays.Should().Be(1);
            watchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""number"": 1,
                ""plays"": 1,
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";
    }
}
