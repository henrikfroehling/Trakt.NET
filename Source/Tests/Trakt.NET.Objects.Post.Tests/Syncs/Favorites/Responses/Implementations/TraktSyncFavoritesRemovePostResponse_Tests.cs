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
    public class TraktSyncFavoritesRemovePostResponseResponse_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesRemovePostResponse_Default_Constructor()
        {
            var syncFavoritesRemovePostResponse = new TraktSyncFavoritesRemovePostResponse();

            syncFavoritesRemovePostResponse.Deleted.Should().BeNull();
            syncFavoritesRemovePostResponse.NotFound.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesRemovePostResponse_From_Json()
        {
            var jsonReader = new SyncFavoritesRemovePostResponseObjectJsonReader();
            var syncFavoritesRemovePostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesRemovePostResponse;

            syncFavoritesRemovePostResponse.Should().NotBeNull();

            syncFavoritesRemovePostResponse.Deleted.Should().NotBeNull();
            syncFavoritesRemovePostResponse.Deleted.Movies.Should().Be(1);
            syncFavoritesRemovePostResponse.Deleted.Shows.Should().Be(2);

            syncFavoritesRemovePostResponse.NotFound.Should().NotBeNull();

            syncFavoritesRemovePostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie[] notFoundMovies = syncFavoritesRemovePostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            syncFavoritesRemovePostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostShow[] notFoundShows = syncFavoritesRemovePostResponse.NotFound.Shows.ToArray();

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
                ""deleted"": {
                  ""movies"": 1,
                  ""shows"": 2
                },
                ""not_found"": {
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
                }
              }";
    }
}
