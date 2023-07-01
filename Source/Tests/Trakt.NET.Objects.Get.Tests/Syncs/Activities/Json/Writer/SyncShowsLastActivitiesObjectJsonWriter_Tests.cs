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
    public class SyncShowsLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime RATED_AT = DateTime.UtcNow;
        private readonly DateTime WATCHLISTED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime FAVORITED_AT = DateTime.UtcNow.AddMinutes(10);
        private readonly DateTime RECOMMENDATIONS_AT = DateTime.UtcNow.AddMinutes(15);
        private readonly DateTime COMMENTED_AT = DateTime.UtcNow.AddMinutes(20);
        private readonly DateTime HIDDEN_AT = DateTime.UtcNow.AddMinutes(25);

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncShowsLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Only_RatedAt_Property()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                RatedAt = RATED_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Only_WatchlistedAt_Property()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                WatchlistedAt = WATCHLISTED_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Only_FavoritedAt_Property()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                FavoritedAt = FAVORITED_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Only_RecommendationsAt_Property()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                RecommendationsAt = RECOMMENDATIONS_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Only_CommentedAt_Property()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                CommentedAt = COMMENTED_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Only_HiddenAt_Property()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncShowsLastActivities syncLastActivities = new TraktSyncShowsLastActivities
            {
                RatedAt = RATED_AT,
                WatchlistedAt = WATCHLISTED_AT,
                FavoritedAt = FAVORITED_AT,
                RecommendationsAt = RECOMMENDATIONS_AT,
                CommentedAt = COMMENTED_AT,
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new SyncShowsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
