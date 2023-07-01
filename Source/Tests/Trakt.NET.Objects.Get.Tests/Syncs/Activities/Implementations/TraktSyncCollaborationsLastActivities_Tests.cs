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
    public class TraktSyncCollaborationsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncCollaborationsLastActivities_Default_Constructor()
        {
            var collaborationsLastActivities = new TraktSyncCollaborationsLastActivities();
            collaborationsLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncCollaborationsLastActivities_From_Json()
        {
            var jsonReader = new SyncCollaborationsLastActivitiesObjectJsonReader();
            var collaborationsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncCollaborationsLastActivities;

            collaborationsLastActivities.Should().NotBeNull();
            collaborationsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
