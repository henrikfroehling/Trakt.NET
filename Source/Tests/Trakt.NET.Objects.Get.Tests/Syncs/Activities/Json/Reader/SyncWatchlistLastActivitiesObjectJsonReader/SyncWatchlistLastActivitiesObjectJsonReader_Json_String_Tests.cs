namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncWatchlistLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            var watchlistLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            watchlistLastActivities.Should().NotBeNull();
            watchlistLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            var watchlistLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            watchlistLastActivities.Should().NotBeNull();
            watchlistLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncWatchlistLastActivities>> watchlistLastActivities = () => jsonReader.ReadObjectAsync(default(string));
            await watchlistLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            var watchlistLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            watchlistLastActivities.Should().BeNull();
        }
    }
}
