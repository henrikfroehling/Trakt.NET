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
    public class TraktSyncLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncLastActivities_Default_Constructor()
        {
            var lastActivities = new TraktSyncLastActivities();

            lastActivities.All.Should().BeNull();
            lastActivities.Movies.Should().BeNull();
            lastActivities.Episodes.Should().BeNull();
            lastActivities.Shows.Should().BeNull();
            lastActivities.Seasons.Should().BeNull();
            lastActivities.Comments.Should().BeNull();
            lastActivities.Lists.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncLastActivities_From_Json()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();
            var lastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncLastActivities;

            lastActivities.Should().NotBeNull();
            lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

            lastActivities.Movies.Should().NotBeNull();
            lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
            lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
            lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
            lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
            lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

            lastActivities.Episodes.Should().NotBeNull();
            lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

            lastActivities.Shows.Should().NotBeNull();
            lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
            lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
            lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
            lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

            lastActivities.Seasons.Should().NotBeNull();
            lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
            lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
            lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
            lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

            lastActivities.Comments.Should().NotBeNull();
            lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

            lastActivities.Lists.Should().NotBeNull();
            lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
            lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
            lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";
    }
}
