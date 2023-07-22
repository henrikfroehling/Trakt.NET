namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Responses.JsonReader")]
    public partial class SyncFavoritesPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncFavoritesPostResponseObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostResponse traktSyncFavoritesPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncFavoritesPostResponse.Should().NotBeNull();
            traktSyncFavoritesPostResponse.Added.Should().NotBeNull();
            traktSyncFavoritesPostResponse.Added.Movies.Should().Be(1);
            traktSyncFavoritesPostResponse.Added.Shows.Should().Be(2);

            traktSyncFavoritesPostResponse.Existing.Should().NotBeNull();
            traktSyncFavoritesPostResponse.Existing.Movies.Should().Be(3);
            traktSyncFavoritesPostResponse.Existing.Shows.Should().Be(4);

            traktSyncFavoritesPostResponse.NotFound.Should().NotBeNull();

            traktSyncFavoritesPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie[] notFoundMovies = traktSyncFavoritesPostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            traktSyncFavoritesPostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostShow[] notFoundShows = traktSyncFavoritesPostResponse.NotFound.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Ids.Should().NotBeNull();
            notFoundShows[0].Ids.Trakt.Should().Be(0U);
            notFoundShows[0].Ids.Slug.Should().BeNull();
            notFoundShows[0].Ids.Imdb.Should().Be("tt0000222");
            notFoundShows[0].Ids.Tvdb.Should().BeNull();
            notFoundShows[0].Ids.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncFavoritesPostResponseObjectJsonReader();
            Func<Task<ITraktSyncFavoritesPostResponse>> traktSyncFavoritesPostResponse = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncFavoritesPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncFavoritesPostResponseObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostResponse traktSyncFavoritesPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncFavoritesPostResponse.Should().BeNull();
        }
    }
}
