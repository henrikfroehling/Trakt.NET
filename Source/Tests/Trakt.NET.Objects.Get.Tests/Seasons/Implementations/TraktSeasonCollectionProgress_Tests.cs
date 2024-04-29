﻿namespace TraktNet.Objects.Get.Tests.Seasons.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Seasons.Implementations")]
    public class TraktSeasonCollectionProgress_Tests
    {
        [Fact]
        public void Test_TraktSeasonCollectionProgress_Default_Constructor()
        {
            var seasonCollectionProgress = new TraktSeasonCollectionProgress();

            seasonCollectionProgress.Number.Should().BeNull();
            seasonCollectionProgress.Title.Should().BeNull();
            seasonCollectionProgress.Aired.Should().BeNull();
            seasonCollectionProgress.Completed.Should().BeNull();
            seasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSeasonCollectionProgress_From_Json()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();
            var seasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON) as TraktSeasonCollectionProgress;

            seasonCollectionProgress.Should().NotBeNull();
            seasonCollectionProgress.Number.Should().Be(2);
            seasonCollectionProgress.Title.Should().Be("The first Hodor.");
            seasonCollectionProgress.Aired.Should().Be(3);
            seasonCollectionProgress.Completed.Should().Be(2);
            seasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = seasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";
    }
}
