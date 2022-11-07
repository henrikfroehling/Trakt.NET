namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncRecommendationsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            var recommendationsLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            recommendationsLastActivities.Should().NotBeNull();
            recommendationsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            var recommendationsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            recommendationsLastActivities.Should().NotBeNull();
            recommendationsLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsLastActivities>> recommendationsLastActivities = () => jsonReader.ReadObjectAsync(default(string));
            await recommendationsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            var recommendationsLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            recommendationsLastActivities.Should().BeNull();
        }
    }
}
