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
    public class SyncSeasonsLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime RATED_AT = DateTime.UtcNow;
        private readonly DateTime WATCHLISTED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime COMMENTED_AT = DateTime.UtcNow.AddMinutes(10);
        private readonly DateTime HIDDEN_AT = DateTime.UtcNow.AddMinutes(15);

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncSeasonsLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Only_RatedAt_Property()
        {
            ITraktSyncSeasonsLastActivities syncLastActivities = new TraktSyncSeasonsLastActivities
            {
                RatedAt = RATED_AT
            };

            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Only_WatchlistedAt_Property()
        {
            ITraktSyncSeasonsLastActivities syncLastActivities = new TraktSyncSeasonsLastActivities
            {
                WatchlistedAt = WATCHLISTED_AT
            };

            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Only_CommentedAt_Property()
        {
            ITraktSyncSeasonsLastActivities syncLastActivities = new TraktSyncSeasonsLastActivities
            {
                CommentedAt = COMMENTED_AT
            };

            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Only_HiddenAt_Property()
        {
            ITraktSyncSeasonsLastActivities syncLastActivities = new TraktSyncSeasonsLastActivities
            {
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncSeasonsLastActivities syncLastActivities = new TraktSyncSeasonsLastActivities
            {
                RatedAt = RATED_AT,
                WatchlistedAt = WATCHLISTED_AT,
                CommentedAt = COMMENTED_AT,
                HiddenAt = HIDDEN_AT
            };

            var traktJsonWriter = new SyncSeasonsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
