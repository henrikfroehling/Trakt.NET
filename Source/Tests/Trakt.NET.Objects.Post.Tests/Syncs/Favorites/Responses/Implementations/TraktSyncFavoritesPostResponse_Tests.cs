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
    public class TraktSyncFavoritesPostResponseResponse_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesPostResponse_Default_Constructor()
        {
            var syncFavoritesPostResponse = new TraktSyncFavoritesPostResponse();

            syncFavoritesPostResponse.Added.Should().BeNull();
            syncFavoritesPostResponse.Existing.Should().BeNull();
            syncFavoritesPostResponse.NotFound.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncFavoritesPostResponse_From_Json()
        {
            var jsonReader = new SyncFavoritesPostResponseObjectJsonReader();
            var syncFavoritesPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktSyncFavoritesPostResponse;

            syncFavoritesPostResponse.Should().NotBeNull();

            syncFavoritesPostResponse.Added.Should().NotBeNull();
            syncFavoritesPostResponse.Added.Movies.Should().Be(1);
            syncFavoritesPostResponse.Added.Shows.Should().Be(2);

            syncFavoritesPostResponse.Existing.Should().NotBeNull();
            syncFavoritesPostResponse.Existing.Movies.Should().Be(3);
            syncFavoritesPostResponse.Existing.Shows.Should().Be(4);
            
            syncFavoritesPostResponse.NotFound.Should().NotBeNull();

            syncFavoritesPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie[] notFoundMovies = syncFavoritesPostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            syncFavoritesPostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostShow[] notFoundShows = syncFavoritesPostResponse.NotFound.Shows.ToArray();

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
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2
                },
                ""existing"": {
                  ""movies"": 3,
                  ""shows"": 4
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
