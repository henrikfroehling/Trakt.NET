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
    public partial class SyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            commentsLastActivities.BlockedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().BeNull();
            commentsLastActivities.BlockedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncCommentsLastActivities>> commentsLastActivities = () => jsonReader.ReadObjectAsync(default(string));
            await commentsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            commentsLastActivities.Should().BeNull();
        }
    }
}
