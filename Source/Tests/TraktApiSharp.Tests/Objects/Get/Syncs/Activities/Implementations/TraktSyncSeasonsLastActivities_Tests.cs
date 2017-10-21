namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
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
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";
    }
}
