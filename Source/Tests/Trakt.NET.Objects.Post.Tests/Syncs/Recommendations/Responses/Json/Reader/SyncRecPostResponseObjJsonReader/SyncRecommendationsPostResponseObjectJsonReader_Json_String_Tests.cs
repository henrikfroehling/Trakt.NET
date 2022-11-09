namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.Responses.JsonReader")]
    public partial class SyncRecommendationsPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseObjectJsonReader();
            ITraktSyncRecommendationsPostResponse traktSyncRecommendationsPostResponse = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSyncRecommendationsPostResponse.Should().NotBeNull();
            traktSyncRecommendationsPostResponse.Added.Should().NotBeNull();
            traktSyncRecommendationsPostResponse.Added.Movies.Should().Be(1);
            traktSyncRecommendationsPostResponse.Added.Shows.Should().Be(2);

            traktSyncRecommendationsPostResponse.Existing.Should().NotBeNull();
            traktSyncRecommendationsPostResponse.Existing.Movies.Should().Be(3);
            traktSyncRecommendationsPostResponse.Existing.Shows.Should().Be(4);

            traktSyncRecommendationsPostResponse.NotFound.Should().NotBeNull();

            traktSyncRecommendationsPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostMovie[] notFoundMovies = traktSyncRecommendationsPostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            traktSyncRecommendationsPostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow[] notFoundShows = traktSyncRecommendationsPostResponse.NotFound.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Ids.Should().NotBeNull();
            notFoundShows[0].Ids.Trakt.Should().Be(0U);
            notFoundShows[0].Ids.Slug.Should().BeNull();
            notFoundShows[0].Ids.Imdb.Should().Be("tt0000222");
            notFoundShows[0].Ids.Tvdb.Should().BeNull();
            notFoundShows[0].Ids.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostResponse>> traktSyncRecommendationsPostResponse = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktSyncRecommendationsPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseObjectJsonReader();
            ITraktSyncRecommendationsPostResponse traktSyncRecommendationsPostResponse = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktSyncRecommendationsPostResponse.Should().BeNull();
        }
    }
}
