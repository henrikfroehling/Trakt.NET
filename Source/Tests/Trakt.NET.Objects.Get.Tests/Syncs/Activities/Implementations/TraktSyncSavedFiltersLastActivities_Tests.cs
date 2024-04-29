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
    public class TraktSyncSavedFiltersLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncSavedFiltersLastActivities_Default_Constructor()
        {
            var savedFiltersLastActivities = new TraktSyncSavedFiltersLastActivities();
            savedFiltersLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncSavedFiltersLastActivities_From_Json()
        {
            var jsonReader = new SyncSavedFiltersLastActivitiesObjectJsonReader();
            var savedFiltersLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncSavedFiltersLastActivities;

            savedFiltersLastActivities.Should().NotBeNull();
            savedFiltersLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
