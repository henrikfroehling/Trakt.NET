namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                commentsLastActivities.Should().NotBeNull();
                commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                commentsLastActivities.Should().NotBeNull();
                commentsLastActivities.LikedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(default(Stream));
            commentsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new TraktSyncCommentsLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(stream);
                commentsLastActivities.Should().BeNull();
            }
        }
    }
}
