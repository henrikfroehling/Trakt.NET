namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.JsonReader")]
    public partial class SyncRecommendationsPostShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();

            using var stream = JSON_COMPLETE.ToStream();
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = await traktJsonReader.ReadObjectAsync(stream);

            traktSyncRecommendationsPostShow.Should().NotBeNull();
            traktSyncRecommendationsPostShow.Title.Should().Be("Breaking Bad");
            traktSyncRecommendationsPostShow.Year.Should().Be(2008);
            traktSyncRecommendationsPostShow.Ids.Should().NotBeNull();
            traktSyncRecommendationsPostShow.Ids.Trakt.Should().Be(1U);
            traktSyncRecommendationsPostShow.Ids.Slug.Should().Be("breaking-bad");
            traktSyncRecommendationsPostShow.Ids.Tvdb.Should().Be(81189U);
            traktSyncRecommendationsPostShow.Ids.Imdb.Should().Be("tt0903747");
            traktSyncRecommendationsPostShow.Ids.Tmdb.Should().Be(1396U);
            traktSyncRecommendationsPostShow.Notes.Should().Be("I AM THE DANGER!");
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostShow>> traktSyncRecommendationsPostShow = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktSyncRecommendationsPostShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();

            using var stream = string.Empty.ToStream();
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = await traktJsonReader.ReadObjectAsync(stream);
            traktSyncRecommendationsPostShow.Should().BeNull();
        }
    }
}
