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
    public class TraktSyncListsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncListsLastActivities_Default_Constructor()
        {
            var listsLastActivities = new TraktSyncListsLastActivities();

            listsLastActivities.LikedAt.Should().BeNull();
            listsLastActivities.UpdatedAt.Should().BeNull();
            listsLastActivities.CommentedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncListsLastActivities_From_Json()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();
            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncListsLastActivities;

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2022-06-28T21:32:53.000Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2022-10-14T21:47:15.000Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
