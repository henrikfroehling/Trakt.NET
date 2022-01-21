namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.JsonReader")]
    public partial class SyncRecommendationsPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseObjectJsonReader();

            using var stream = JSON_COMPLETE.ToStream();
            ITraktSyncRecommendationsPostResponse traktSyncRecommendationsPostResponse = await traktJsonReader.ReadObjectAsync(stream);

            traktSyncRecommendationsPostResponse.Should().NotBeNull();
            traktSyncRecommendationsPostResponse.Added.Should().NotBeNull();
            traktSyncRecommendationsPostResponse.Added.Movies.Should().Be(1);
            traktSyncRecommendationsPostResponse.Added.Shows.Should().Be(2);

            traktSyncRecommendationsPostResponse.Existing.Should().NotBeNull();
            traktSyncRecommendationsPostResponse.Existing.Movies.Should().Be(3);
            traktSyncRecommendationsPostResponse.Existing.Shows.Should().Be(4);

            traktSyncRecommendationsPostResponse.NotFound.Should().NotBeNull();

            traktSyncRecommendationsPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktMovieIds[] notFoundMovies = traktSyncRecommendationsPostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Trakt.Should().Be(0U);
            notFoundMovies[0].Slug.Should().BeNull();
            notFoundMovies[0].Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Tmdb.Should().BeNull();

            traktSyncRecommendationsPostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktShowIds[] notFoundShows = traktSyncRecommendationsPostResponse.NotFound.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Trakt.Should().Be(0U);
            notFoundShows[0].Slug.Should().BeNull();
            notFoundShows[0].Imdb.Should().Be("tt0000222");
            notFoundShows[0].Tvdb.Should().BeNull();
            notFoundShows[0].Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostResponse>> traktSyncRecommendationsPostResponse = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktSyncRecommendationsPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseObjectJsonReader();

            using var stream = string.Empty.ToStream();
            ITraktSyncRecommendationsPostResponse traktSyncRecommendationsPostResponse = await traktJsonReader.ReadObjectAsync(stream);
            traktSyncRecommendationsPostResponse.Should().BeNull();
        }
    }
}
