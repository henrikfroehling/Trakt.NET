﻿namespace TraktNet.Objects.Get.Tests.Watched.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Watched.Implementations")]
    public class TraktWatchedShowSeason_Tests
    {
        [Fact]
        public void Test_TraktWatchedShowSeason_Default_Constructor()
        {
            var watchedShowSeason = new TraktWatchedShowSeason();

            watchedShowSeason.Number.Should().BeNull();
            watchedShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchedShowSeason_From_Json()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();
            var watchedShowSeason = await jsonReader.ReadObjectAsync(JSON) as TraktWatchedShowSeason;

            watchedShowSeason.Should().NotBeNull();
            watchedShowSeason.Number.Should().Be(1);

            watchedShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var episodes = watchedShowSeason.Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""number"": 1,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""plays"": 1,
                    ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                  },
                  {
                    ""number"": 2,
                    ""plays"": 1,
                    ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                  }
                ]
              }";
    }
}
