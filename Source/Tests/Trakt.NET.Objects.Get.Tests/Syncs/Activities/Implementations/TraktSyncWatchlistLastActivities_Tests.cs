namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncWatchlistLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistLastActivities_Default_Constructor()
        {
            var watchlistLastActivities = new TraktSyncWatchlistLastActivities();
            watchlistLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncWatchlistLastActivities_From_Json()
        {
            var jsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();
            var watchlistLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncWatchlistLastActivities;

            watchlistLastActivities.Should().NotBeNull();
            watchlistLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2023-06-22T16:39:23.000Z""
              }";
    }
}
