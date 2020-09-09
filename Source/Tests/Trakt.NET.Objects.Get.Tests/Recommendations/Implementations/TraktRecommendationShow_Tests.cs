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
    public class TraktRecommendationShow_Tests
    {
        [Fact]
        public void Test_TraktRecommendationShow_Default_Constructor()
        {
            var recommendationShow = new TraktRecommendationShow();

            recommendationShow.Rank.Should().BeNull();
            recommendationShow.ListedAt.Should().BeNull();
            recommendationShow.Type.Should().BeNull();
            recommendationShow.Notes.Should().BeNull();
            recommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecommendationShow_From_Json()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();
            var recommendationShow = await jsonReader.ReadObjectAsync(JSON) as TraktRecommendationShow;

            recommendationShow.Should().NotBeNull();
            recommendationShow.Rank.Should().Be(1);
            recommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShow.Notes.Should().Be("Atmospheric for days.");
            recommendationShow.Show.Should().NotBeNull();
            recommendationShow.Show.Title.Should().Be("The Walking Dead");
            recommendationShow.Show.Year.Should().Be(2010);
            recommendationShow.Show.Ids.Should().NotBeNull();
            recommendationShow.Show.Ids.Trakt.Should().Be(2U);
            recommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        private const string JSON =
            @"{
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
