namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            lastActivities.Should().NotBeNull();
            lastActivities.All.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            lastActivities.Should().NotBeNull();
            lastActivities.All.Should().Be(DateTime.Parse("2023-06-30T13:38:37.000Z").ToUniversalTime());

            lastActivities.Movies.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Episodes.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Shows.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Seasons.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Comments.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Lists.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Watchlist.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Favorites.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Recommendations.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_11);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Collaborations.Should().BeNull();

            lastActivities.Account.Should().NotBeNull();
            lastActivities.Account.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            lastActivities.Account.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            lastActivities.Account.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Account.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Account.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.SavedFilters.Should().NotBeNull();
            lastActivities.SavedFilters.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_12);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Account.Should().BeNull();

            lastActivities.SavedFilters.Should().NotBeNull();
            lastActivities.SavedFilters.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_13);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.SavedFilters.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            lastActivities.Should().NotBeNull();
            lastActivities.All.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            lastActivities.Should().NotBeNull();
            lastActivities.All.Should().Be(DateTime.Parse("2023-06-30T13:38:37.000Z").ToUniversalTime());

            lastActivities.Movies.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Episodes.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Shows.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Seasons.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Comments.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Lists.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_8);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Watchlist.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_9()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_9);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Favorites.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_10()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_10);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Recommendations.Should().BeNull();

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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_11()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_11);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Collaborations.Should().BeNull();

            lastActivities.Account.Should().NotBeNull();
            lastActivities.Account.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            lastActivities.Account.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            lastActivities.Account.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Account.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            lastActivities.Account.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());

            lastActivities.SavedFilters.Should().NotBeNull();
            lastActivities.SavedFilters.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_12()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_12);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.Account.Should().BeNull();

            lastActivities.SavedFilters.Should().NotBeNull();
            lastActivities.SavedFilters.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_13()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_13);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

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

            lastActivities.SavedFilters.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_14()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_14);
            using var jsonReader = new JsonTextReader(reader);
            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            lastActivities.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncLastActivities>> lastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await lastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncLastActivitiesObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var lastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            lastActivities.Should().BeNull();
        }
    }
}
