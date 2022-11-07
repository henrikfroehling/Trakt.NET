namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncRecommendationsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var recommendationsLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                recommendationsLastActivities.Should().NotBeNull();
                recommendationsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var recommendationsLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                recommendationsLastActivities.Should().NotBeNull();
                recommendationsLastActivities.UpdatedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsLastActivities>> recommendationsLastActivities = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await recommendationsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncRecommendationsLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var recommendationsLastActivities = await traktJsonReader.ReadObjectAsync(stream);
                recommendationsLastActivities.Should().BeNull();
            }
        }
    }
}
