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
    public class TraktSyncLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncLastActivities_Default_Constructor()
        {
            var lastActivities = new TraktSyncLastActivities();

            lastActivities.All.Should().BeNull();
            lastActivities.Movies.Should().BeNull();
            lastActivities.Episodes.Should().BeNull();
            lastActivities.Shows.Should().BeNull();
            lastActivities.Seasons.Should().BeNull();
            lastActivities.Comments.Should().BeNull();
            lastActivities.Lists.Should().BeNull();
            lastActivities.Watchlist.Should().BeNull();
            lastActivities.Favorites.Should().BeNull();
            lastActivities.Recommendations.Should().BeNull();
            lastActivities.Collaborations.Should().BeNull();
            lastActivities.Account.Should().BeNull();
            lastActivities.SavedFilters.Should().BeNull();
            lastActivities.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncLastActivities_From_Json()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();
            var lastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncLastActivities;

            lastActivities.Should().NotBeNull();
            lastActivities.All.Should().Be(DateTime.Parse("2023-06-30T13:38:37.000Z").ToUniversalTime());

            lastActivities.Movies.Should().NotBeNull();
            lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2023-06-11T20:00:28.000Z").ToUniversalTime());
            lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2016-11-07T03:11:00.000Z").ToUniversalTime());
            lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-04T13:48:29.000Z").ToUniversalTime());
            lastActivities.Movies.FavoritedAt.Should().Be(DateTime.Parse("2021-04-07T22:07:11.000Z").ToUniversalTime());
            lastActivities.Movies.RecommendationsAt.Should().Be(DateTime.Parse("2021-04-07T22:07:11.000Z").ToUniversalTime());
            lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Episodes.Should().NotBeNull();
            lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2023-06-30T13:38:37.000Z").ToUniversalTime());
            lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2016-11-09T23:16:22.000Z").ToUniversalTime());
            lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Shows.Should().NotBeNull();
            lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            lastActivities.Shows.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            lastActivities.Shows.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());

            lastActivities.Seasons.Should().NotBeNull();
            lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Comments.Should().NotBeNull();
            lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Comments.BlockedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Lists.Should().NotBeNull();
            lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2022-06-28T21:32:53.000Z").ToUniversalTime());
            lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2022-10-14T21:47:15.000Z").ToUniversalTime());
            lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Watchlist.Should().NotBeNull();
            lastActivities.Watchlist.UpdatedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());

            lastActivities.Favorites.Should().NotBeNull();
            lastActivities.Favorites.UpdatedAt.Should().Be(DateTime.Parse("2022-05-14T19:04:12.000Z").ToUniversalTime());

            lastActivities.Recommendations.Should().NotBeNull();
            lastActivities.Recommendations.UpdatedAt.Should().Be(DateTime.Parse("2022-05-14T19:04:12.000Z").ToUniversalTime());

            lastActivities.Collaborations.Should().NotBeNull();
            lastActivities.Collaborations.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Account.Should().NotBeNull();
            lastActivities.Account.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            lastActivities.Account.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            lastActivities.Account.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Account.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Account.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.SavedFilters.Should().NotBeNull();
            lastActivities.SavedFilters.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.Notes.Should().NotBeNull();
            lastActivities.Notes.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""notes"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";
    }
}
