namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
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
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await jsonReader.ReadObjectAsync(default(string));
            commentsLastActivities.Should().BeNull();
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
