namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Recommendations.Implementations")]
    public class TraktSyncRecommendationsPostMovie_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsPostMovie_Default_Constructor()
        {
            var syncRecommendationsPostMovie = new TraktSyncRecommendationsPostMovie();

            syncRecommendationsPostMovie.Title.Should().BeNull();
            syncRecommendationsPostMovie.Year.Should().BeNull();
            syncRecommendationsPostMovie.Ids.Should().BeNull();
            syncRecommendationsPostMovie.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsPostMovie_From_Json()
        {
            var jsonReader = new SyncRecommendationsPostMovieObjectJsonReader();
            var syncRecommendationsPostMovie = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsPostMovie;

            syncRecommendationsPostMovie.Should().NotBeNull();

            syncRecommendationsPostMovie.Title.Should().Be("Batman Begins");
            syncRecommendationsPostMovie.Year.Should().Be(2005);
            syncRecommendationsPostMovie.Ids.Should().NotBeNull();
            syncRecommendationsPostMovie.Ids.Trakt.Should().Be(1U);
            syncRecommendationsPostMovie.Ids.Slug.Should().Be("batman-begins-2005");
            syncRecommendationsPostMovie.Ids.Imdb.Should().Be("tt0372784");
            syncRecommendationsPostMovie.Ids.Tmdb.Should().Be(272U);
            syncRecommendationsPostMovie.Notes.Should().Be("One of Chritian Bale's most iconic roles.");
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
