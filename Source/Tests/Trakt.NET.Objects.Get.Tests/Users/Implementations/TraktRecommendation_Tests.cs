namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.Implementations")]
    public class TraktRecommendation_Tests
    {
        [Fact]
        public void Test_TraktRecommendation_Default_Constructor()
        {
            var recommendation = new TraktRecommendation();

            recommendation.Id.Should().BeNull();
            recommendation.Rank.Should().BeNull();
            recommendation.ListedAt.Should().BeNull();
            recommendation.Type.Should().BeNull();
            recommendation.Notes.Should().BeNull();
            recommendation.Movie.Should().BeNull();
            recommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecommendation_From_Json_With_Movie()
        {
            var jsonReader = new RecommendationObjectJsonReader();
            var recommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE) as TraktRecommendation;

            recommendation.Should().NotBeNull();
            recommendation.Id.Should().Be(101);
            recommendation.Rank.Should().Be(1);
            recommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendation.Movie.Should().NotBeNull();
            recommendation.Movie.Title.Should().Be("TRON: Legacy");
            recommendation.Movie.Year.Should().Be(2010);
            recommendation.Movie.Ids.Should().NotBeNull();
            recommendation.Movie.Ids.Trakt.Should().Be(1U);
            recommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            recommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecommendation_From_Json_With_Show()
        {
            var jsonReader = new RecommendationObjectJsonReader();
            var recommendation = await jsonReader.ReadObjectAsync(JSON_SHOW) as TraktRecommendation;

            recommendation.Should().NotBeNull();
            recommendation.Id.Should().Be(102);
            recommendation.Rank.Should().Be(1);
            recommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendation.Notes.Should().Be("Atmospheric for days.");
            recommendation.Movie.Should().BeNull();
            recommendation.Show.Should().NotBeNull();
            recommendation.Show.Title.Should().Be("The Walking Dead");
            recommendation.Show.Year.Should().Be(2010);
            recommendation.Show.Ids.Should().NotBeNull();
            recommendation.Show.Ids.Trakt.Should().Be(2U);
            recommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendation.Show.Ids.Tvdb.Should().Be(153021U);
            recommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            recommendation.Show.Ids.Tmdb.Should().Be(1402U);
        }

        private const string JSON_MOVIE =
            @"{
                ""id"": 101,
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

        private const string JSON_SHOW =
            @"{
                ""id"": 102,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""show"": {
                  ""title"": ""The Walking Dead"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""the-walking-dead"",
                    ""tvdb"": 153021,
                    ""imdb"": ""tt1520211"",
                    ""tmdb"": 1402
                  }
                }
              }";
    }
}
