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
    public partial class SyncSavedFiltersLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncSavedFiltersLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncSavedFiltersLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            watchlistLastActivities.Should().NotBeNull();
            watchlistLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSavedFiltersLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new SyncSavedFiltersLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            watchlistLastActivities.Should().NotBeNull();
            watchlistLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSavedFiltersLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncSavedFiltersLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncSavedFiltersLastActivities>> watchlistLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await watchlistLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncSavedFiltersLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncSavedFiltersLastActivitiesObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            watchlistLastActivities.Should().BeNull();
        }
    }
}
