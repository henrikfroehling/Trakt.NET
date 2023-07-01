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
    public class SyncCollaborationsLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncCollaborationsLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncCollaborationsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncCollaborationsLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncCollaborationsLastActivities syncLastActivities = new TraktSyncCollaborationsLastActivities
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new SyncCollaborationsLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
