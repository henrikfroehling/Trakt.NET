namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncShowsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.RecommendationsAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncShowsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncShowsLastActivities>> showsLastActivities = () => jsonReader.ReadObjectAsync(default(string));
            await showsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            showsLastActivities.Should().BeNull();
        }
    }
}
