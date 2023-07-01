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
            moviesLastActivities.FavoritedAt.Should().BeNull();
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
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2023-06-11T20:00:28.000Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2016-11-07T03:11:00.000Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-04T13:48:29.000Z").ToUniversalTime());
            moviesLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-04-07T22:07:11.000Z").ToUniversalTime());
            moviesLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-04-07T22:07:11.000Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
