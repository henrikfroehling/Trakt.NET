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
    public class TraktSyncAccountLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncAccountLastActivities_Default_Constructor()
        {
            var accountLastActivities = new TraktSyncAccountLastActivities();

            accountLastActivities.SettingsAt.Should().BeNull();
            accountLastActivities.FollowedAt.Should().BeNull();
            accountLastActivities.FollowingAt.Should().BeNull();
            accountLastActivities.PendingAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncAccountLastActivities_From_Json()
        {
            var jsonReader = new SyncAccountLastActivitiesObjectJsonReader();
            var accountLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncAccountLastActivities;

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""settings_at"": ""2014-09-01T09:10:11.000Z"",
                ""followed_at"": ""2014-09-01T09:10:11.000Z"",
                ""following_at"": ""2014-09-01T09:10:11.000Z"",
                ""pending_at"": ""2014-09-01T09:10:11.000Z""
              }";
    }
}
