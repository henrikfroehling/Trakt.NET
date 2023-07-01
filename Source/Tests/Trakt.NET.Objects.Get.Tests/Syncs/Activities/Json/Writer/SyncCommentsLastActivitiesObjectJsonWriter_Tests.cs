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
    public class SyncCommentsLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime LIKED_AT = DateTime.UtcNow;
        private readonly DateTime BLOCKED_AT = DateTime.UtcNow.AddMinutes(5);

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncCommentsLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncCommentsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncCommentsLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonWriter_Only_LikedAt_Property()
        {
            ITraktSyncCommentsLastActivities syncLastActivities = new TraktSyncCommentsLastActivities
            {
                LikedAt = LIKED_AT
            };

            var traktJsonWriter = new SyncCommentsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonWriter_Only_BlockedAt_Property()
        {
            ITraktSyncCommentsLastActivities syncLastActivities = new TraktSyncCommentsLastActivities
            {
                BlockedAt = BLOCKED_AT
            };

            var traktJsonWriter = new SyncCommentsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"blocked_at\":\"{BLOCKED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncCommentsLastActivities syncLastActivities = new TraktSyncCommentsLastActivities
            {
                LikedAt = LIKED_AT,
                BlockedAt = BLOCKED_AT
            };

            var traktJsonWriter = new SyncCommentsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"blocked_at\":\"{BLOCKED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
