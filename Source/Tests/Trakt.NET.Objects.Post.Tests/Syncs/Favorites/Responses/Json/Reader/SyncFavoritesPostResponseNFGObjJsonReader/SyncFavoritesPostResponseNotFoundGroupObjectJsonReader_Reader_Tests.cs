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
    public partial class SyncFavoritesPostResponseNotFoundGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncFavoritesPostResponseNotFoundGroupObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostResponseNotFoundGroup traktSyncFavoritesPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncFavoritesPostResponseNotFoundGroup.Should().NotBeNull();
            traktSyncFavoritesPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie[] notFoundMovies = traktSyncFavoritesPostResponseNotFoundGroup.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            traktSyncFavoritesPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostShow[] notFoundShows = traktSyncFavoritesPostResponseNotFoundGroup.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Ids.Should().NotBeNull();
            notFoundShows[0].Ids.Trakt.Should().Be(0U);
            notFoundShows[0].Ids.Slug.Should().BeNull();
            notFoundShows[0].Ids.Imdb.Should().Be("tt0000222");
            notFoundShows[0].Ids.Tvdb.Should().BeNull();
            notFoundShows[0].Ids.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncFavoritesPostResponseNotFoundGroupObjectJsonReader();
            Func<Task<ITraktSyncFavoritesPostResponseNotFoundGroup>> traktSyncFavoritesPostResponseNotFoundGroup = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncFavoritesPostResponseNotFoundGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncFavoritesPostResponseNotFoundGroupObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostResponseNotFoundGroup traktSyncFavoritesPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncFavoritesPostResponseNotFoundGroup.Should().BeNull();
        }
    }
}
