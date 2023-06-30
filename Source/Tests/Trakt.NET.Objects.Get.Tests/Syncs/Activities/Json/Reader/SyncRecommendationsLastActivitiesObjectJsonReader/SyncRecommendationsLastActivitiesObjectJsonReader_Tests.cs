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
    public partial class SyncRecommendationsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var recommendationsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            recommendationsLastActivities.Should().NotBeNull();
            recommendationsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2022-05-14T19:04:12.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var recommendationsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            recommendationsLastActivities.Should().NotBeNull();
            recommendationsLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsLastActivities>> recommendationsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await recommendationsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var recommendationsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            recommendationsLastActivities.Should().BeNull();
        }
    }
}
