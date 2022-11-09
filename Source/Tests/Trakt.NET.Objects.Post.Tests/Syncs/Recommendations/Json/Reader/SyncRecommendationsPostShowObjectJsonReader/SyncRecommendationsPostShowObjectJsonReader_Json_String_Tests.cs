namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.JsonReader")]
    public partial class SyncRecommendationsPostShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

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
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostShow>> traktSyncRecommendationsPostShow = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktSyncRecommendationsPostShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktSyncRecommendationsPostShow.Should().BeNull();
        }
    }
}
