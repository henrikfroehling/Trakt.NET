namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.JsonReader")]
    public partial class SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();
            ITraktSyncRecommendationsPostResponseNotFoundGroup traktSyncRecommendationsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSyncRecommendationsPostResponseNotFoundGroup.Should().NotBeNull();
            traktSyncRecommendationsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktMovieIds[] notFoundMovies = traktSyncRecommendationsPostResponseNotFoundGroup.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Trakt.Should().Be(0U);
            notFoundMovies[0].Slug.Should().BeNull();
            notFoundMovies[0].Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Tmdb.Should().BeNull();

            traktSyncRecommendationsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktShowIds[] notFoundShows = traktSyncRecommendationsPostResponseNotFoundGroup.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Trakt.Should().Be(0U);
            notFoundShows[0].Slug.Should().BeNull();
            notFoundShows[0].Imdb.Should().Be("tt0000222");
            notFoundShows[0].Tvdb.Should().BeNull();
            notFoundShows[0].Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostResponseNotFoundGroup>> traktSyncRecommendationsPostResponseNotFoundGroup = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktSyncRecommendationsPostResponseNotFoundGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();
            ITraktSyncRecommendationsPostResponseNotFoundGroup traktSyncRecommendationsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktSyncRecommendationsPostResponseNotFoundGroup.Should().BeNull();
        }
    }
}
