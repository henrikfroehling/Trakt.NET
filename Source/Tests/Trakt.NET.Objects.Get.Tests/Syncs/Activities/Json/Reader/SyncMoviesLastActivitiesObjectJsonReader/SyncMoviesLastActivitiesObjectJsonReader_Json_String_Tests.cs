namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.RecommendationsAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncMoviesLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncMoviesLastActivities>> moviesLastActivities = () => jsonReader.ReadObjectAsync(default(string));
            await moviesLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            moviesLastActivities.Should().BeNull();
        }
    }
}
