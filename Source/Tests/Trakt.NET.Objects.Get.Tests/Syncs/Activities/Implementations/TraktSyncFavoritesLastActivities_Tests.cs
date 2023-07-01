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
    public class TraktSyncFavoritesLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesLastActivities_Default_Constructor()
        {
            var favoritesLastActivities = new TraktSyncFavoritesLastActivities();
            favoritesLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesLastActivities_From_Json()
        {
            var jsonReader = new SyncFavoritesLastActivitiesObjectJsonReader();
            var favoritesLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesLastActivities;

            favoritesLastActivities.Should().NotBeNull();
            favoritesLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2022-05-14T19:04:12.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2022-05-14T19:04:12.000Z""
              }";
    }
}
