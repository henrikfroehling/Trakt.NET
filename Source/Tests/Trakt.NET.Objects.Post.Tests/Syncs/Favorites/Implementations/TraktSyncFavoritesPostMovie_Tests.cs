namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Implementations")]
    public class TraktSyncFavoritesPostMovie_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesPostMovie_Default_Constructor()
        {
            var syncFavoritesPostMovie = new TraktSyncFavoritesPostMovie();

            syncFavoritesPostMovie.Title.Should().BeNull();
            syncFavoritesPostMovie.Year.Should().BeNull();
            syncFavoritesPostMovie.Ids.Should().BeNull();
            syncFavoritesPostMovie.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesPostMovie_From_Json()
        {
            var jsonReader = new SyncFavoritesPostMovieObjectJsonReader();
            var syncFavoritesPostMovie = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesPostMovie;

            syncFavoritesPostMovie.Should().NotBeNull();

            syncFavoritesPostMovie.Title.Should().Be("Batman Begins");
            syncFavoritesPostMovie.Year.Should().Be(2005);
            syncFavoritesPostMovie.Ids.Should().NotBeNull();
            syncFavoritesPostMovie.Ids.Trakt.Should().Be(1U);
            syncFavoritesPostMovie.Ids.Slug.Should().Be("batman-begins-2005");
            syncFavoritesPostMovie.Ids.Imdb.Should().Be("tt0372784");
            syncFavoritesPostMovie.Ids.Tmdb.Should().Be(272U);
            syncFavoritesPostMovie.Notes.Should().Be("One of Chritian Bale's most iconic roles.");
        }

        private const string JSON =
            @"{
                ""title"": ""Batman Begins"",
                ""year"": 2005,
                ""ids"": {
                  ""trakt"": 1,
                  ""slug"": ""batman-begins-2005"",
                  ""imdb"": ""tt0372784"",
                  ""tmdb"": 272
                },
                ""notes"": ""One of Chritian Bale's most iconic roles.""
              }";
    }
}
