namespace TraktNet.Objects.Get.Tests.People.Credits.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonMovieCreditsCastItem_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCreditsCastItem_Default_Constructor()
        {
            var creditsCastItem = new TraktPersonMovieCreditsCastItem();

            creditsCastItem.Characters.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonMovieCreditsCastItem_From_Json()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();
            var creditsCastItem = await jsonReader.ReadObjectAsync(JSON) as TraktPersonMovieCreditsCastItem;

            creditsCastItem.Should().NotBeNull();
            creditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            creditsCastItem.Movie.Should().NotBeNull();
            creditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCastItem.Movie.Year.Should().Be(2015);
            creditsCastItem.Movie.Ids.Should().NotBeNull();
            creditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
            creditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCastItem.Movie.Tagline.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Overview.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Released.Should().NotHaveValue();
            creditsCastItem.Movie.Runtime.Should().NotHaveValue();
            creditsCastItem.Movie.UpdatedAt.Should().NotHaveValue();
            creditsCastItem.Movie.Trailer.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Homepage.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Rating.Should().NotHaveValue();
            creditsCastItem.Movie.Votes.Should().NotHaveValue();
            creditsCastItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            creditsCastItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCastItem.Movie.Genres.Should().BeNull();
            creditsCastItem.Movie.Certification.Should().BeNullOrEmpty();
        }

        private const string JSON =
            @"{
                ""characters"": [
                  ""Joe Brody""
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
