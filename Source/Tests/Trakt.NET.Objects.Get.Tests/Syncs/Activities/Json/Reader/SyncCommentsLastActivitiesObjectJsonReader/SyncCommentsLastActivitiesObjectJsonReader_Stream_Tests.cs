namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                commentsLastActivities.Should().NotBeNull();
                commentsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                commentsLastActivities.Should().NotBeNull();
                commentsLastActivities.LikedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            var commentsLastActivities = await traktJsonReader.ReadObjectAsync(default(Stream));
            commentsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCommentsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncCommentsLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var commentsLastActivities = await traktJsonReader.ReadObjectAsync(stream);
                commentsLastActivities.Should().BeNull();
            }
        }
    }
}
