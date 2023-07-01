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
    public class SyncEpisodesLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime WATCHED_AT = DateTime.UtcNow;
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime RATED_AT = DateTime.UtcNow.AddMinutes(10);
        private readonly DateTime WATCHLISTED_AT = DateTime.UtcNow.AddMinutes(15);
        private readonly DateTime COMMENTED_AT = DateTime.UtcNow.AddMinutes(20);
        private readonly DateTime PAUSED_AT = DateTime.UtcNow.AddMinutes(25);

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncEpisodesLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Only_WatchedAt_Property()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                WatchedAt = WATCHED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Only_CollectedAt_Property()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                CollectedAt = COLLECTED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Only_RatedAt_Property()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                RatedAt = RATED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Only_WatchlistedAt_Property()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                WatchlistedAt = WATCHLISTED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Only_CommentedAt_Property()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                CommentedAt = COMMENTED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Only_PausedAt_Property()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                PausedAt = PAUSED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncEpisodesLastActivities syncLastActivities = new TraktSyncEpisodesLastActivities
            {
                WatchedAt = WATCHED_AT,
                CollectedAt = COLLECTED_AT,
                RatedAt = RATED_AT,
                WatchlistedAt = WATCHLISTED_AT,
                CommentedAt = COMMENTED_AT,
                PausedAt = PAUSED_AT
            };

            var traktJsonWriter = new SyncEpisodesLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
