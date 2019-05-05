namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
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
            episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z""
              }";
    }
}
