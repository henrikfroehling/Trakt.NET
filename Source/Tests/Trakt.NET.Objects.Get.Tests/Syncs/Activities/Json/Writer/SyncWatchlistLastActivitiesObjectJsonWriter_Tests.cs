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
    public class SyncWatchlistLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncWatchlistLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncWatchlistLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncWatchlistLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncWatchlistLastActivities syncLastActivities = new TraktSyncWatchlistLastActivities
            {
                UpdatedAt = UPDATED_AT
            };

            var traktJsonWriter = new SyncWatchlistLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}
