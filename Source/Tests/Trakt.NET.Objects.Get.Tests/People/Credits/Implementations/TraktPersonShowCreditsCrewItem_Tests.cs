namespace TraktNet.Objects.Get.Tests.People.Credits.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonShowCreditsCrewItem_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsCrewItem_Default_Constructor()
        {
            var creditsCrewItem = new TraktPersonShowCreditsCrewItem();

            creditsCrewItem.Job.Should().BeNullOrEmpty();
            creditsCrewItem.Jobs.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonShowCreditsCrewItem_From_Minimal_Json()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();
            var creditsCrewItem = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktPersonShowCreditsCrewItem;

            creditsCrewItem.Should().NotBeNull();
            creditsCrewItem.Job.Should().Be("Director");
            creditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            creditsCrewItem.Show.Should().NotBeNull();
            creditsCrewItem.Show.Title.Should().Be("Game of Thrones");
            creditsCrewItem.Show.Year.Should().Be(2011);
            creditsCrewItem.Show.Airs.Should().BeNull();
            creditsCrewItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCrewItem.Show.Ids.Should().NotBeNull();
            creditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
            creditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
            creditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
            creditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
            creditsCrewItem.Show.Genres.Should().BeNull();
            creditsCrewItem.Show.Seasons.Should().BeNull();
            creditsCrewItem.Show.Overview.Should().BeNullOrEmpty();
            creditsCrewItem.Show.FirstAired.Should().NotHaveValue();
            creditsCrewItem.Show.Runtime.Should().NotHaveValue();
            creditsCrewItem.Show.Certification.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Network.Should().BeNullOrEmpty();
            creditsCrewItem.Show.CountryCode.Should().BeNullOrEmpty();
            creditsCrewItem.Show.UpdatedAt.Should().NotHaveValue();
            creditsCrewItem.Show.Trailer.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Homepage.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Status.Should().BeNull();
            creditsCrewItem.Show.Rating.Should().NotHaveValue();
            creditsCrewItem.Show.Votes.Should().NotHaveValue();
            creditsCrewItem.Show.LanguageCode.Should().BeNullOrEmpty();
            creditsCrewItem.Show.AiredEpisodes.Should().NotHaveValue();
        }

        private const string MINIMAL_JSON =
            @"{
                ""job"": ""Director"",
                ""jobs"": [
                  ""Director""
                ],
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";
    }
}
