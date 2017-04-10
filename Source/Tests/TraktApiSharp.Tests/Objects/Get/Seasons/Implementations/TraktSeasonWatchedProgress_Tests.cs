namespace TraktApiSharp.Tests.Objects.Get.Seasons.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.Implementations")]
    public class TraktSeasonWatchedProgress_Tests
    {
        [Fact]
        public void Test_TraktSeasonWatchedProgress_Inherits_TraktSeasonProgress()
        {
            typeof(TraktSeasonWatchedProgress).IsSubclassOf(typeof(TraktSeasonProgress)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgress_Implements_ITraktSeasonWatchedProgress_Interface()
        {
            typeof(TraktSeasonWatchedProgress).GetInterfaces().Should().Contain(typeof(ITraktSeasonWatchedProgress));
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgress_Default_Constructor()
        {
            var seasonWatchedProgress = new TraktSeasonWatchedProgress();

            seasonWatchedProgress.Number.Should().NotHaveValue();
            seasonWatchedProgress.Aired.Should().NotHaveValue();
            seasonWatchedProgress.Completed.Should().NotHaveValue();
            seasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSeasonWatchedProgress_From_Json()
        {
            var jsonReader = new ITraktSeasonWatchedProgressObjectJsonReader();
            var seasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON);

            seasonWatchedProgress.Should().NotBeNull();
            seasonWatchedProgress.Number.Should().Be(2);
            seasonWatchedProgress.Aired.Should().Be(3);
            seasonWatchedProgress.Completed.Should().Be(2);
            seasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = seasonWatchedProgress.Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";
    }
}
