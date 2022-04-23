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
    public class TraktSyncRecommendationsPostResponseResponse_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsPostResponse_Default_Constructor()
        {
            var syncRecommendationsPostResponse = new TraktSyncRecommendationsPostResponse();

            syncRecommendationsPostResponse.Added.Should().BeNull();
            syncRecommendationsPostResponse.Existing.Should().BeNull();
            syncRecommendationsPostResponse.NotFound.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsPostResponse_From_Json()
        {
            var jsonReader = new SyncRecommendationsPostResponseObjectJsonReader();
            var syncRecommendationsPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsPostResponse;

            syncRecommendationsPostResponse.Should().NotBeNull();

            syncRecommendationsPostResponse.Added.Should().NotBeNull();
            syncRecommendationsPostResponse.Added.Movies.Should().Be(1);
            syncRecommendationsPostResponse.Added.Shows.Should().Be(2);

            syncRecommendationsPostResponse.Existing.Should().NotBeNull();
            syncRecommendationsPostResponse.Existing.Movies.Should().Be(3);
            syncRecommendationsPostResponse.Existing.Shows.Should().Be(4);
            
            syncRecommendationsPostResponse.NotFound.Should().NotBeNull();

            syncRecommendationsPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostMovie[] notFoundMovies = syncRecommendationsPostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Ids.Should().NotBeNull();
            notFoundMovies[0].Ids.Trakt.Should().Be(0U);
            notFoundMovies[0].Ids.Slug.Should().BeNull();
            notFoundMovies[0].Ids.Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Ids.Tmdb.Should().BeNull();

            syncRecommendationsPostResponse.NotFound.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow[] notFoundShows = syncRecommendationsPostResponse.NotFound.Shows.ToArray();

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
