namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncRecommendationsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsLastActivities_Default_Constructor()
        {
            var recommendationsLastActivities = new TraktSyncRecommendationsLastActivities();
            recommendationsLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsLastActivities_From_Json()
        {
            var jsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();
            var recommendationsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsLastActivities;

            recommendationsLastActivities.Should().NotBeNull();
            recommendationsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2014-09-01T09:10:11.000Z""
              }";
    }
}
