namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.Implementations")]
    public class TraktSyncRecommendationsRemovePostResponseResponse_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsRemovePostResponse_Default_Constructor()
        {
            var syncRecommendationsRemovePostResponse = new TraktSyncRecommendationsRemovePostResponse();

            syncRecommendationsRemovePostResponse.Deleted.Should().BeNull();
            syncRecommendationsRemovePostResponse.NotFound.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsRemovePostResponse_From_Json()
        {
            var jsonReader = new SyncRecommendationsRemovePostResponseObjectJsonReader();
            var syncRecommendationsRemovePostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsRemovePostResponse;

            syncRecommendationsRemovePostResponse.Should().NotBeNull();

            syncRecommendationsRemovePostResponse.Deleted.Should().NotBeNull();
            syncRecommendationsRemovePostResponse.Deleted.Movies.Should().Be(1);
            syncRecommendationsRemovePostResponse.Deleted.Shows.Should().Be(2);

            syncRecommendationsRemovePostResponse.NotFound.Should().NotBeNull();

            syncRecommendationsRemovePostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostMovie[] notFoundMovies = syncRecommendationsRemovePostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            syncRecommendationsRemovePostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow[] notFoundShows = syncRecommendationsRemovePostResponse.NotFound.Shows.ToArray();

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
