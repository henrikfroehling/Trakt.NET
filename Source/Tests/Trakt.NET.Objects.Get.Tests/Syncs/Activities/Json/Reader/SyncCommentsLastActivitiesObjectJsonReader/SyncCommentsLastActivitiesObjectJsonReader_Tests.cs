namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            commentsLastActivities.BlockedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().BeNull();
            commentsLastActivities.BlockedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            commentsLastActivities.BlockedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().BeNull();
            commentsLastActivities.BlockedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            commentsLastActivities.BlockedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            commentsLastActivities.Should().NotBeNull();
            commentsLastActivities.LikedAt.Should().BeNull();
            commentsLastActivities.BlockedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncCommentsLastActivities>> commentsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await commentsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            commentsLastActivities.Should().BeNull();
        }
    }
}
