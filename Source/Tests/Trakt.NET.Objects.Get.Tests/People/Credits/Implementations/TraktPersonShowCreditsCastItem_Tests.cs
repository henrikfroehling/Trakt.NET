namespace TraktNet.Objects.Get.Tests.People.Credits.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonShowCreditsCastItem_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsCastItem_Default_Constructor()
        {
            var creditsCastItem = new TraktPersonShowCreditsCastItem();

            creditsCastItem.Characters.Should().BeNullOrEmpty();
            creditsCastItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonShowCreditsCastItem_From_Json()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();
            var creditsCastItem = await jsonReader.ReadObjectAsync(JSON) as TraktPersonShowCreditsCastItem;

            creditsCastItem.Should().NotBeNull();
            creditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            creditsCastItem.Show.Should().NotBeNull();
            creditsCastItem.Show.Title.Should().Be("Game of Thrones");
            creditsCastItem.Show.Year.Should().Be(2011);
            creditsCastItem.Show.Airs.Should().BeNull();
            creditsCastItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCastItem.Show.Ids.Should().NotBeNull();
            creditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
            creditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
            creditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
            creditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            creditsCastItem.Show.Genres.Should().BeNull();
            creditsCastItem.Show.Seasons.Should().BeNull();
            creditsCastItem.Show.Overview.Should().BeNullOrEmpty();
            creditsCastItem.Show.FirstAired.Should().NotHaveValue();
            creditsCastItem.Show.Runtime.Should().NotHaveValue();
            creditsCastItem.Show.Certification.Should().BeNullOrEmpty();
            creditsCastItem.Show.Network.Should().BeNullOrEmpty();
            creditsCastItem.Show.CountryCode.Should().BeNullOrEmpty();
            creditsCastItem.Show.UpdatedAt.Should().NotHaveValue();
            creditsCastItem.Show.Trailer.Should().BeNullOrEmpty();
            creditsCastItem.Show.Homepage.Should().BeNullOrEmpty();
            creditsCastItem.Show.Status.Should().BeNull();
            creditsCastItem.Show.Rating.Should().NotHaveValue();
            creditsCastItem.Show.Votes.Should().NotHaveValue();
            creditsCastItem.Show.LanguageCode.Should().BeNullOrEmpty();
            creditsCastItem.Show.AiredEpisodes.Should().NotHaveValue();
        }

        private const string JSON =
            @"{
                ""characters"": [
                  ""Joe Brody""
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
