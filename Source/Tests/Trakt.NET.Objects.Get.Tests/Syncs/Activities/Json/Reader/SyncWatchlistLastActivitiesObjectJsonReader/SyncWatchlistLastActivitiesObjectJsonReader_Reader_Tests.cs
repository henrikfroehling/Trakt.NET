namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncWatchlistLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                watchlistLastActivities.Should().NotBeNull();
                watchlistLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                watchlistLastActivities.Should().NotBeNull();
                watchlistLastActivities.UpdatedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncWatchlistLastActivities>> watchlistLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await watchlistLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                watchlistLastActivities.Should().BeNull();
            }
        }
    }
}
