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
    public class TraktSyncSeasonsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncSeasonsLastActivities_Default_Constructor()
        {
            var seasonsLastActivities = new TraktSyncSeasonsLastActivities();

            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncSeasonsLastActivities_From_Json()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();
            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncSeasonsLastActivities;

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
