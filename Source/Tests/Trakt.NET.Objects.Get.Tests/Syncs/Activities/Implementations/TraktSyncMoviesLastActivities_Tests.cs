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
    public class TraktSyncMoviesLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncMoviesLastActivities_Default_Constructor()
        {
            var moviesLastActivities = new TraktSyncMoviesLastActivities();
            
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.RecommendationsAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivities_From_Json()
        {
            var jsonReader = new SyncMoviesLastActivitiesObjectJsonReader();
            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncMoviesLastActivities;

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""recommendations_at"": ""2014-11-20T06:51:30.325Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";
    }
}
