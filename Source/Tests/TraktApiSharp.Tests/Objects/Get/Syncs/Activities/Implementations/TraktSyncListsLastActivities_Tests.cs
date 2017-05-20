namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncListsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncListsLastActivities_Implements_ITraktSyncListsLastActivities_Interface()
        {
            typeof(TraktSyncListsLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncListsLastActivities));
        }

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
            var jsonReader = new TraktSyncListsLastActivitiesObjectJsonReader();
            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncListsLastActivities;

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z"",
                ""updated_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";
    }
}
