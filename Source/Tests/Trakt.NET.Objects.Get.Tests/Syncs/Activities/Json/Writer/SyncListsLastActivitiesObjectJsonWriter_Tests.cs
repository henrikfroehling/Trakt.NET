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
    public class SyncListsLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime LIKED_AT = DateTime.UtcNow;
        private readonly DateTime UPDATED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime COMMENTED_AT = DateTime.UtcNow.AddMinutes(10);

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncListsLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonWriter_Only_LikedAt_Property()
        {
            ITraktSyncListsLastActivities syncLastActivities = new TraktSyncListsLastActivities
            {
                LikedAt = LIKED_AT
            };

            var traktJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonWriter_Only_UpdatedAt_Property()
        {
            ITraktSyncListsLastActivities syncLastActivities = new TraktSyncListsLastActivities
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonWriter_Only_CommentedAt_Property()
        {
            ITraktSyncListsLastActivities syncLastActivities = new TraktSyncListsLastActivities
            {
                CommentedAt = COMMENTED_AT
            };

            var traktJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncListsLastActivities syncLastActivities = new TraktSyncListsLastActivities
            {
                LikedAt = LIKED_AT,
                UpdatedAt = UPDATED_AT,
                CommentedAt = COMMENTED_AT
            };

            var traktJsonWriter = new SyncListsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
