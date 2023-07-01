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
    public class SyncAccountLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime SETTINGS_AT = DateTime.UtcNow;
        private readonly DateTime FOLLOWED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime FOLLOWING_AT = DateTime.UtcNow.AddMinutes(10);
        private readonly DateTime PENDING_AT = DateTime.UtcNow.AddMinutes(15);
        private readonly DateTime REQUESTED_AT = DateTime.UtcNow.AddMinutes(20);

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncAccountLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Only_SettingsAt_Property()
        {
            ITraktSyncAccountLastActivities syncLastActivities = new TraktSyncAccountLastActivities
            {
                SettingsAt = SETTINGS_AT
            };

            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"settings_at\":\"{SETTINGS_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Only_FollowedAt_Property()
        {
            ITraktSyncAccountLastActivities syncLastActivities = new TraktSyncAccountLastActivities
            {
                FollowedAt = FOLLOWED_AT
            };

            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"followed_at\":\"{FOLLOWED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Only_FollowingAt_Property()
        {
            ITraktSyncAccountLastActivities syncLastActivities = new TraktSyncAccountLastActivities
            {
                FollowingAt = FOLLOWING_AT
            };

            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"following_at\":\"{FOLLOWING_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Only_PendingAt_Property()
        {
            ITraktSyncAccountLastActivities syncLastActivities = new TraktSyncAccountLastActivities
            {
                PendingAt = PENDING_AT
            };

            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"pending_at\":\"{PENDING_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Only_RequestedAt_Property()
        {
            ITraktSyncAccountLastActivities syncLastActivities = new TraktSyncAccountLastActivities
            {
                RequestedAt = REQUESTED_AT
            };

            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"requested_at\":\"{REQUESTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncAccountLastActivities syncLastActivities = new TraktSyncAccountLastActivities
            {
                SettingsAt = SETTINGS_AT,
                FollowedAt = FOLLOWED_AT,
                FollowingAt = FOLLOWING_AT,
                PendingAt = PENDING_AT,
                RequestedAt = REQUESTED_AT
            };

            var traktJsonWriter = new SyncAccountLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"settings_at\":\"{SETTINGS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"followed_at\":\"{FOLLOWED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"following_at\":\"{FOLLOWING_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"pending_at\":\"{PENDING_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"requested_at\":\"{REQUESTED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
