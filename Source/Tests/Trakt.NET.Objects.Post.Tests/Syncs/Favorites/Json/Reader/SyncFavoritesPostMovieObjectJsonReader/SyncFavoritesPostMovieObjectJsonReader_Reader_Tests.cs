namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.JsonReader")]
    public partial class SyncFavoritesPostMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncFavoritesPostMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncFavoritesPostMovieObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostMovie traktSyncFavoritesPostMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncFavoritesPostMovie.Should().NotBeNull();
            traktSyncFavoritesPostMovie.Title.Should().Be("Batman Begins");
            traktSyncFavoritesPostMovie.Year.Should().Be(2005);
            traktSyncFavoritesPostMovie.Ids.Should().NotBeNull();
            traktSyncFavoritesPostMovie.Ids.Trakt.Should().Be(1U);
            traktSyncFavoritesPostMovie.Ids.Slug.Should().Be("batman-begins-2005");
            traktSyncFavoritesPostMovie.Ids.Imdb.Should().Be("tt0372784");
            traktSyncFavoritesPostMovie.Ids.Tmdb.Should().Be(272U);
            traktSyncFavoritesPostMovie.Notes.Should().Be("One of Chritian Bale's most iconic roles.");
        }

        [Fact]
        public async Task Test_SyncFavoritesPostMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncFavoritesPostMovieObjectJsonReader();
            Func<Task<ITraktSyncFavoritesPostMovie>> traktSyncFavoritesPostMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncFavoritesPostMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncFavoritesPostMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncFavoritesPostMovieObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncFavoritesPostMovie traktSyncFavoritesPostMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncFavoritesPostMovie.Should().BeNull();
        }
    }
}
