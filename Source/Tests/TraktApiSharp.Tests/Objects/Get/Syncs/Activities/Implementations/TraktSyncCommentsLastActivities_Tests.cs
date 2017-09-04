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
    public class TraktSyncCommentsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncCommentsLastActivities_Implements_ITraktSyncCommentsLastActivities_Interface()
        {
            typeof(TraktSyncCommentsLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncCommentsLastActivities));
        }

        [Fact]
        public void Test_TraktSyncCommentsLastActivities_Default_Constructor()
        {
            var commentsLastActivities = new TraktSyncCommentsLastActivities();

            commentsLastActivities.LikedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivities_From_Json()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();
            var commentsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncCommentsLastActivities;

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""liked_at"": ""2014-09-01T09:10:11.000Z""
              }";
    }
}
