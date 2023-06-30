namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncEpisodesLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncEpisodesLastActivities_Default_Constructor()
        {
            var episodesLastActivities = new TraktSyncEpisodesLastActivities();

            episodesLastActivities.WatchedAt.Should().BeNull();
            episodesLastActivities.CollectedAt.Should().BeNull();
            episodesLastActivities.RatedAt.Should().BeNull();
            episodesLastActivities.WatchlistedAt.Should().BeNull();
            episodesLastActivities.CommentedAt.Should().BeNull();
            episodesLastActivities.PausedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncEpisodesLastActivities_From_Json()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();
            var episodesLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncEpisodesLastActivities;

            episodesLastActivities.Should().NotBeNull();
            episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2023-06-30T13:38:37.000Z").ToUniversalTime());
            episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2016-11-09T23:16:22.000Z").ToUniversalTime());
            episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
