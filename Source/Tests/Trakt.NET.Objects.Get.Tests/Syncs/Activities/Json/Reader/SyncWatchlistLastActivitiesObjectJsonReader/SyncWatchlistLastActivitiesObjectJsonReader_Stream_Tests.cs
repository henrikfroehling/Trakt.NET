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
    public partial class SyncWatchlistLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                watchlistLastActivities.Should().NotBeNull();
                watchlistLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                watchlistLastActivities.Should().NotBeNull();
                watchlistLastActivities.UpdatedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncWatchlistLastActivities>> watchlistLastActivities = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await watchlistLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncWatchlistLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncWatchlistLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var watchlistLastActivities = await traktJsonReader.ReadObjectAsync(stream);
                watchlistLastActivities.Should().BeNull();
            }
        }
    }
}
