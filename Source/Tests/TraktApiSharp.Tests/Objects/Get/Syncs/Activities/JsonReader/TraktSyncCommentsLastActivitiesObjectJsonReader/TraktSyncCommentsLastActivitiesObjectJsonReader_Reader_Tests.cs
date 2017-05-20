namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                commentsLastActivities.Should().NotBeNull();
                commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                commentsLastActivities.Should().NotBeNull();
                commentsLastActivities.LikedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            commentsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                commentsLastActivities.Should().BeNull();
            }
        }
    }
}
