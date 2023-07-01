namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonWriter")]
    public class SyncMoviesLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime WATCHED_AT = DateTime.UtcNow;
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime RATED_AT = DateTime.UtcNow.AddMinutes(10);
        private readonly DateTime WATCHLISTED_AT = DateTime.UtcNow.AddMinutes(15);
        private readonly DateTime FAVORITED_AT = DateTime.UtcNow.AddMinutes(20);
        private readonly DateTime RECOMMENDATIONS_AT = DateTime.UtcNow.AddMinutes(25);
        private readonly DateTime COMMENTED_AT = DateTime.UtcNow.AddMinutes(30);
        private readonly DateTime PAUSED_AT = DateTime.UtcNow.AddMinutes(35);

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncMoviesLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_WatchedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                WatchedAt = WATCHED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_CollectedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                CollectedAt = COLLECTED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_RatedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                RatedAt = RATED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_WatchlistedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                WatchlistedAt = WATCHLISTED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_FavoritedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                FavoritedAt = FAVORITED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_RecommendationsAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                RecommendationsAt = RECOMMENDATIONS_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_CommentedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                CommentedAt = COMMENTED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Only_PausedAt_Property()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                PausedAt = PAUSED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncMoviesLastActivities syncLastActivities = new TraktSyncMoviesLastActivities
            {
                WatchedAt = WATCHED_AT,
                CollectedAt = COLLECTED_AT,
                RatedAt = RATED_AT,
                WatchlistedAt = WATCHLISTED_AT,
                FavoritedAt = FAVORITED_AT,
                RecommendationsAt = RECOMMENDATIONS_AT,
                CommentedAt = COMMENTED_AT,
                PausedAt = PAUSED_AT
            };

            var traktJsonWriter = new SyncMoviesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
