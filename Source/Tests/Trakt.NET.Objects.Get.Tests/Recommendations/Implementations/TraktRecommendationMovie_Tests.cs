namespace TraktNet.Objects.Get.Tests.Recommendations.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Recommendations.Implementations")]
    public class TraktRecommendationMovie_Tests
    {
        [Fact]
        public void Test_TraktRecommendationMovie_Default_Constructor()
        {
            var recommendationMovie = new TraktRecommendationMovie();

            recommendationMovie.Rank.Should().BeNull();
            recommendationMovie.ListedAt.Should().BeNull();
            recommendationMovie.Type.Should().BeNull();
            recommendationMovie.Notes.Should().BeNull();
            recommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecommendationMovie_From_Json()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();
            var recommendationMovie = await jsonReader.ReadObjectAsync(JSON) as TraktRecommendationMovie;

            recommendationMovie.Should().NotBeNull();
            recommendationMovie.Rank.Should().Be(1);
            recommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovie.Movie.Should().NotBeNull();
            recommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovie.Movie.Year.Should().Be(2010);
            recommendationMovie.Movie.Ids.Should().NotBeNull();
            recommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        private const string JSON =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";
    }
}
