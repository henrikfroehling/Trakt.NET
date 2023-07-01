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
    public class TraktSyncShowsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncShowsLastActivities_Default_Constructor()
        {
            var showsLastActivities = new TraktSyncShowsLastActivities();

            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.FavoritedAt.Should().BeNull();
            showsLastActivities.RecommendationsAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivities_From_Json()
        {
            var jsonReader = new SyncShowsLastActivitiesObjectJsonReader();
            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncShowsLastActivities;

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";
    }
}
