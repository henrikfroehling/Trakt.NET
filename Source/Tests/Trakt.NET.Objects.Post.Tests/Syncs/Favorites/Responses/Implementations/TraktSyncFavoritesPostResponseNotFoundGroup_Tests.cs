namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Responses.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses;
    using TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Responses.Implementations")]
    public class TraktSyncFavoritesPostResponseNotFoundGroup_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesPostResponseNotFoundGroup_Default_Constructor()
        {
            var syncFavoritesPostResponseNotFoundGroup = new TraktSyncFavoritesPostResponseNotFoundGroup();

            syncFavoritesPostResponseNotFoundGroup.Movies.Should().BeNull();
            syncFavoritesPostResponseNotFoundGroup.Shows.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesPostResponseNotFoundGroup_From_Json()
        {
            var jsonReader = new SyncFavoritesPostResponseNotFoundGroupObjectJsonReader();
            var syncFavoritesPostResponseNotFoundGroup = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesPostResponseNotFoundGroup;

            syncFavoritesPostResponseNotFoundGroup.Should().NotBeNull();

            syncFavoritesPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie[] notFoundMovies = syncFavoritesPostResponseNotFoundGroup.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            syncFavoritesPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostShow[] notFoundShows = syncFavoritesPostResponseNotFoundGroup.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Ids.Should().NotBeNull();
            notFoundShows[0].Ids.Trakt.Should().Be(0U);
            notFoundShows[0].Ids.Slug.Should().BeNull();
            notFoundShows[0].Ids.Imdb.Should().Be("tt0000222");
            notFoundShows[0].Ids.Tvdb.Should().BeNull();
            notFoundShows[0].Ids.Tmdb.Should().BeNull();

        }

        private const string JSON =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""imdb"": ""tt0000111""
                    }
                  }
                ],
                ""shows"": [
                  {
                    ""ids"": {
                      ""imdb"": ""tt0000222""
                    }
                  }
                ]
              }";
    }
}
