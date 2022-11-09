namespace TraktNet.Objects.Get.Tests.People.Credits.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonMovieCreditsCrewItem_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCreditsCrewItem_Default_Constructor()
        {
            var creditsCrewItem = new TraktPersonMovieCreditsCrewItem();

            creditsCrewItem.Jobs.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonMovieCreditsCrewItem_From_Json()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();
            var creditsCrewItem = await jsonReader.ReadObjectAsync(JSON) as TraktPersonMovieCreditsCrewItem;

            creditsCrewItem.Should().NotBeNull();
            creditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            creditsCrewItem.Movie.Should().NotBeNull();
            creditsCrewItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCrewItem.Movie.Year.Should().Be(2015);
            creditsCrewItem.Movie.Ids.Should().NotBeNull();
            creditsCrewItem.Movie.Ids.Trakt.Should().Be(94024U);
            creditsCrewItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCrewItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCrewItem.Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCrewItem.Movie.Tagline.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Overview.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Released.Should().NotHaveValue();
            creditsCrewItem.Movie.Runtime.Should().NotHaveValue();
            creditsCrewItem.Movie.UpdatedAt.Should().NotHaveValue();
            creditsCrewItem.Movie.Trailer.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Homepage.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Rating.Should().NotHaveValue();
            creditsCrewItem.Movie.Votes.Should().NotHaveValue();
            creditsCrewItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCrewItem.Movie.Genres.Should().BeNull();
            creditsCrewItem.Movie.Certification.Should().BeNullOrEmpty();
        }

        private const string JSON =
            @"{
                ""jobs"": [
                  ""Director""
                ],
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";
    }
}
