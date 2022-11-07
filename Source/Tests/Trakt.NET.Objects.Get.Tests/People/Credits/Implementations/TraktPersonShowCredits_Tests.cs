namespace TraktNet.Objects.Get.Tests.People.Credits.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonShowCredits_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCredits_Default_Constructor()
        {
            var credits = new TraktPersonShowCredits();

            credits.Cast.Should().BeNull();
            credits.Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonShowCredits_From_Json()
        {
            var jsonReader = new PersonShowCreditsObjectJsonReader();
            var credits = await jsonReader.ReadObjectAsync(JSON) as TraktPersonShowCredits;

            credits.Should().NotBeNull();
            credits.Cast.Should().NotBeNull().And.HaveCount(2);
            credits.Crew.Should().NotBeNull();

            var creditsCast = credits.Cast.ToArray();

            creditsCast[0].Should().NotBeNull();
            creditsCast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Jon Snow");
            creditsCast[0].Show.Should().NotBeNull();
            creditsCast[0].Show.Title.Should().Be("Game of Thrones");
            creditsCast[0].Show.Year.Should().Be(2011);
            creditsCast[0].Show.Airs.Should().BeNull();
            creditsCast[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCast[0].Show.Ids.Should().NotBeNull();
            creditsCast[0].Show.Ids.Trakt.Should().Be(1390U);
            creditsCast[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCast[0].Show.Ids.Tvdb.Should().Be(121361U);
            creditsCast[0].Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCast[0].Show.Ids.Tmdb.Should().Be(1399U);
            creditsCast[0].Show.Ids.TvRage.Should().Be(24493U);
            creditsCast[0].Show.Genres.Should().BeNull();
            creditsCast[0].Show.Seasons.Should().BeNull();
            creditsCast[0].Show.Overview.Should().BeNullOrEmpty();
            creditsCast[0].Show.FirstAired.Should().NotHaveValue();
            creditsCast[0].Show.Runtime.Should().NotHaveValue();
            creditsCast[0].Show.Certification.Should().BeNullOrEmpty();
            creditsCast[0].Show.Network.Should().BeNullOrEmpty();
            creditsCast[0].Show.CountryCode.Should().BeNullOrEmpty();
            creditsCast[0].Show.UpdatedAt.Should().NotHaveValue();
            creditsCast[0].Show.Trailer.Should().BeNullOrEmpty();
            creditsCast[0].Show.Homepage.Should().BeNullOrEmpty();
            creditsCast[0].Show.Status.Should().BeNull();
            creditsCast[0].Show.Rating.Should().NotHaveValue();
            creditsCast[0].Show.Votes.Should().NotHaveValue();
            creditsCast[0].Show.LanguageCode.Should().BeNullOrEmpty();
            creditsCast[0].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCast[1].Should().NotBeNull();
            creditsCast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Jon Snow");
            creditsCast[1].Show.Should().NotBeNull();
            creditsCast[1].Show.Title.Should().Be("Game of Thrones");
            creditsCast[1].Show.Year.Should().Be(2011);
            creditsCast[1].Show.Airs.Should().BeNull();
            creditsCast[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCast[1].Show.Ids.Should().NotBeNull();
            creditsCast[1].Show.Ids.Trakt.Should().Be(1390U);
            creditsCast[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCast[1].Show.Ids.Tvdb.Should().Be(121361U);
            creditsCast[1].Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCast[1].Show.Ids.Tmdb.Should().Be(1399U);
            creditsCast[1].Show.Ids.TvRage.Should().Be(24493U);
            creditsCast[1].Show.Genres.Should().BeNull();
            creditsCast[1].Show.Seasons.Should().BeNull();
            creditsCast[1].Show.Overview.Should().BeNullOrEmpty();
            creditsCast[1].Show.FirstAired.Should().NotHaveValue();
            creditsCast[1].Show.Runtime.Should().NotHaveValue();
            creditsCast[1].Show.Certification.Should().BeNullOrEmpty();
            creditsCast[1].Show.Network.Should().BeNullOrEmpty();
            creditsCast[1].Show.CountryCode.Should().BeNullOrEmpty();
            creditsCast[1].Show.UpdatedAt.Should().NotHaveValue();
            creditsCast[1].Show.Trailer.Should().BeNullOrEmpty();
            creditsCast[1].Show.Homepage.Should().BeNullOrEmpty();
            creditsCast[1].Show.Status.Should().BeNull();
            creditsCast[1].Show.Rating.Should().NotHaveValue();
            creditsCast[1].Show.Votes.Should().NotHaveValue();
            creditsCast[1].Show.LanguageCode.Should().BeNullOrEmpty();
            creditsCast[1].Show.AiredEpisodes.Should().NotHaveValue();

            var creditsCrew = credits.Crew;

            creditsCrew.Production.Should().NotBeNull().And.HaveCount(2);

            var productionCrew = creditsCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer 1");
            productionCrew[0].Show.Should().NotBeNull();
            productionCrew[0].Show.Title.Should().Be("Game of Thrones");
            productionCrew[0].Show.Year.Should().Be(2011);
            productionCrew[0].Show.Airs.Should().BeNull();
            productionCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            productionCrew[0].Show.Ids.Should().NotBeNull();
            productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            productionCrew[0].Show.Genres.Should().BeNull();
            productionCrew[0].Show.Seasons.Should().BeNull();
            productionCrew[0].Show.Overview.Should().BeNullOrEmpty();
            productionCrew[0].Show.FirstAired.Should().NotHaveValue();
            productionCrew[0].Show.Runtime.Should().NotHaveValue();
            productionCrew[0].Show.Certification.Should().BeNullOrEmpty();
            productionCrew[0].Show.Network.Should().BeNullOrEmpty();
            productionCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            productionCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            productionCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            productionCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            productionCrew[0].Show.Status.Should().BeNull();
            productionCrew[0].Show.Rating.Should().NotHaveValue();
            productionCrew[0].Show.Votes.Should().NotHaveValue();
            productionCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            productionCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            productionCrew[1].Should().NotBeNull();
            productionCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer 2");
            productionCrew[1].Show.Should().NotBeNull();
            productionCrew[1].Show.Title.Should().Be("Game of Thrones");
            productionCrew[1].Show.Year.Should().Be(2011);
            productionCrew[1].Show.Airs.Should().BeNull();
            productionCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            productionCrew[1].Show.Ids.Should().NotBeNull();
            productionCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            productionCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            productionCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            productionCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            productionCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            productionCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            productionCrew[1].Show.Genres.Should().BeNull();
            productionCrew[1].Show.Seasons.Should().BeNull();
            productionCrew[1].Show.Overview.Should().BeNullOrEmpty();
            productionCrew[1].Show.FirstAired.Should().NotHaveValue();
            productionCrew[1].Show.Runtime.Should().NotHaveValue();
            productionCrew[1].Show.Certification.Should().BeNullOrEmpty();
            productionCrew[1].Show.Network.Should().BeNullOrEmpty();
            productionCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            productionCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            productionCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            productionCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            productionCrew[1].Show.Status.Should().BeNull();
            productionCrew[1].Show.Rating.Should().NotHaveValue();
            productionCrew[1].Show.Votes.Should().NotHaveValue();
            productionCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            productionCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Art.Should().NotBeNull().And.HaveCount(2);

            var artCrew = creditsCrew.Art.ToArray();

            artCrew[0].Should().NotBeNull();
            artCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Art Director 1");
            artCrew[0].Show.Should().NotBeNull();
            artCrew[0].Show.Title.Should().Be("Game of Thrones");
            artCrew[0].Show.Year.Should().Be(2011);
            artCrew[0].Show.Airs.Should().BeNull();
            artCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            artCrew[0].Show.Ids.Should().NotBeNull();
            artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            artCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            artCrew[0].Show.Genres.Should().BeNull();
            artCrew[0].Show.Seasons.Should().BeNull();
            artCrew[0].Show.Overview.Should().BeNullOrEmpty();
            artCrew[0].Show.FirstAired.Should().NotHaveValue();
            artCrew[0].Show.Runtime.Should().NotHaveValue();
            artCrew[0].Show.Certification.Should().BeNullOrEmpty();
            artCrew[0].Show.Network.Should().BeNullOrEmpty();
            artCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            artCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            artCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            artCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            artCrew[0].Show.Status.Should().BeNull();
            artCrew[0].Show.Rating.Should().NotHaveValue();
            artCrew[0].Show.Votes.Should().NotHaveValue();
            artCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            artCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            artCrew[1].Should().NotBeNull();
            artCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Art Director 2");
            artCrew[1].Show.Should().NotBeNull();
            artCrew[1].Show.Title.Should().Be("Game of Thrones");
            artCrew[1].Show.Year.Should().Be(2011);
            artCrew[1].Show.Airs.Should().BeNull();
            artCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            artCrew[1].Show.Ids.Should().NotBeNull();
            artCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            artCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            artCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            artCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            artCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            artCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            artCrew[1].Show.Genres.Should().BeNull();
            artCrew[1].Show.Seasons.Should().BeNull();
            artCrew[1].Show.Overview.Should().BeNullOrEmpty();
            artCrew[1].Show.FirstAired.Should().NotHaveValue();
            artCrew[1].Show.Runtime.Should().NotHaveValue();
            artCrew[1].Show.Certification.Should().BeNullOrEmpty();
            artCrew[1].Show.Network.Should().BeNullOrEmpty();
            artCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            artCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            artCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            artCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            artCrew[1].Show.Status.Should().BeNull();
            artCrew[1].Show.Rating.Should().NotHaveValue();
            artCrew[1].Show.Votes.Should().NotHaveValue();
            artCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            artCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);

            var crew = creditsCrew.Crew.ToArray();

            crew[0].Should().NotBeNull();
            crew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Crew Member 1");
            crew[0].Show.Should().NotBeNull();
            crew[0].Show.Title.Should().Be("Game of Thrones");
            crew[0].Show.Year.Should().Be(2011);
            crew[0].Show.Airs.Should().BeNull();
            crew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            crew[0].Show.Ids.Should().NotBeNull();
            crew[0].Show.Ids.Trakt.Should().Be(1390U);
            crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            crew[0].Show.Ids.Tvdb.Should().Be(121361U);
            crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            crew[0].Show.Ids.Tmdb.Should().Be(1399U);
            crew[0].Show.Ids.TvRage.Should().Be(24493U);
            crew[0].Show.Genres.Should().BeNull();
            crew[0].Show.Seasons.Should().BeNull();
            crew[0].Show.Overview.Should().BeNullOrEmpty();
            crew[0].Show.FirstAired.Should().NotHaveValue();
            crew[0].Show.Runtime.Should().NotHaveValue();
            crew[0].Show.Certification.Should().BeNullOrEmpty();
            crew[0].Show.Network.Should().BeNullOrEmpty();
            crew[0].Show.CountryCode.Should().BeNullOrEmpty();
            crew[0].Show.UpdatedAt.Should().NotHaveValue();
            crew[0].Show.Trailer.Should().BeNullOrEmpty();
            crew[0].Show.Homepage.Should().BeNullOrEmpty();
            crew[0].Show.Status.Should().BeNull();
            crew[0].Show.Rating.Should().NotHaveValue();
            crew[0].Show.Votes.Should().NotHaveValue();
            crew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            crew[0].Show.AiredEpisodes.Should().NotHaveValue();

            crew[1].Should().NotBeNull();
            crew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Crew Member 2");
            crew[1].Show.Should().NotBeNull();
            crew[1].Show.Title.Should().Be("Game of Thrones");
            crew[1].Show.Year.Should().Be(2011);
            crew[1].Show.Airs.Should().BeNull();
            crew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            crew[1].Show.Ids.Should().NotBeNull();
            crew[1].Show.Ids.Trakt.Should().Be(1390U);
            crew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            crew[1].Show.Ids.Tvdb.Should().Be(121361U);
            crew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            crew[1].Show.Ids.Tmdb.Should().Be(1399U);
            crew[1].Show.Ids.TvRage.Should().Be(24493U);
            crew[1].Show.Genres.Should().BeNull();
            crew[1].Show.Seasons.Should().BeNull();
            crew[1].Show.Overview.Should().BeNullOrEmpty();
            crew[1].Show.FirstAired.Should().NotHaveValue();
            crew[1].Show.Runtime.Should().NotHaveValue();
            crew[1].Show.Certification.Should().BeNullOrEmpty();
            crew[1].Show.Network.Should().BeNullOrEmpty();
            crew[1].Show.CountryCode.Should().BeNullOrEmpty();
            crew[1].Show.UpdatedAt.Should().NotHaveValue();
            crew[1].Show.Trailer.Should().BeNullOrEmpty();
            crew[1].Show.Homepage.Should().BeNullOrEmpty();
            crew[1].Show.Status.Should().BeNull();
            crew[1].Show.Rating.Should().NotHaveValue();
            crew[1].Show.Votes.Should().NotHaveValue();
            crew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            crew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);

            var costumeAndMakeupCrew = creditsCrew.CostumeAndMakeup.ToArray();

            costumeAndMakeupCrew[0].Should().NotBeNull();
            costumeAndMakeupCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Costume Designer");
            costumeAndMakeupCrew[0].Show.Should().NotBeNull();
            costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
            costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
            costumeAndMakeupCrew[0].Show.Airs.Should().BeNull();
            costumeAndMakeupCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            costumeAndMakeupCrew[0].Show.Genres.Should().BeNull();
            costumeAndMakeupCrew[0].Show.Seasons.Should().BeNull();
            costumeAndMakeupCrew[0].Show.Overview.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.FirstAired.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Show.Runtime.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Show.Certification.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.Network.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.Status.Should().BeNull();
            costumeAndMakeupCrew[0].Show.Rating.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Show.Votes.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            costumeAndMakeupCrew[1].Should().NotBeNull();
            costumeAndMakeupCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Make Up Artist");
            costumeAndMakeupCrew[1].Show.Should().NotBeNull();
            costumeAndMakeupCrew[1].Show.Title.Should().Be("Game of Thrones");
            costumeAndMakeupCrew[1].Show.Year.Should().Be(2011);
            costumeAndMakeupCrew[1].Show.Airs.Should().BeNull();
            costumeAndMakeupCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            costumeAndMakeupCrew[1].Show.Genres.Should().BeNull();
            costumeAndMakeupCrew[1].Show.Seasons.Should().BeNull();
            costumeAndMakeupCrew[1].Show.Overview.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.FirstAired.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Show.Runtime.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Show.Certification.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.Network.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.Status.Should().BeNull();
            costumeAndMakeupCrew[1].Show.Rating.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Show.Votes.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);

            var directingCrew = creditsCrew.Directing.ToArray();

            directingCrew[0].Should().NotBeNull();
            directingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director 1");
            directingCrew[0].Show.Should().NotBeNull();
            directingCrew[0].Show.Title.Should().Be("Game of Thrones");
            directingCrew[0].Show.Year.Should().Be(2011);
            directingCrew[0].Show.Airs.Should().BeNull();
            directingCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            directingCrew[0].Show.Ids.Should().NotBeNull();
            directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            directingCrew[0].Show.Genres.Should().BeNull();
            directingCrew[0].Show.Seasons.Should().BeNull();
            directingCrew[0].Show.Overview.Should().BeNullOrEmpty();
            directingCrew[0].Show.FirstAired.Should().NotHaveValue();
            directingCrew[0].Show.Runtime.Should().NotHaveValue();
            directingCrew[0].Show.Certification.Should().BeNullOrEmpty();
            directingCrew[0].Show.Network.Should().BeNullOrEmpty();
            directingCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            directingCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            directingCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            directingCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            directingCrew[0].Show.Status.Should().BeNull();
            directingCrew[0].Show.Rating.Should().NotHaveValue();
            directingCrew[0].Show.Votes.Should().NotHaveValue();
            directingCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            directingCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            directingCrew[1].Should().NotBeNull();
            directingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director 2");
            directingCrew[1].Show.Should().NotBeNull();
            directingCrew[1].Show.Title.Should().Be("Game of Thrones");
            directingCrew[1].Show.Year.Should().Be(2011);
            directingCrew[1].Show.Airs.Should().BeNull();
            directingCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            directingCrew[1].Show.Ids.Should().NotBeNull();
            directingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            directingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            directingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            directingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            directingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            directingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            directingCrew[1].Show.Genres.Should().BeNull();
            directingCrew[1].Show.Seasons.Should().BeNull();
            directingCrew[1].Show.Overview.Should().BeNullOrEmpty();
            directingCrew[1].Show.FirstAired.Should().NotHaveValue();
            directingCrew[1].Show.Runtime.Should().NotHaveValue();
            directingCrew[1].Show.Certification.Should().BeNullOrEmpty();
            directingCrew[1].Show.Network.Should().BeNullOrEmpty();
            directingCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            directingCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            directingCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            directingCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            directingCrew[1].Show.Status.Should().BeNull();
            directingCrew[1].Show.Rating.Should().NotHaveValue();
            directingCrew[1].Show.Votes.Should().NotHaveValue();
            directingCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            directingCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);

            var writingCrew = creditsCrew.Writing.ToArray();

            writingCrew[0].Should().NotBeNull();
            writingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer 1");
            writingCrew[0].Show.Should().NotBeNull();
            writingCrew[0].Show.Title.Should().Be("Game of Thrones");
            writingCrew[0].Show.Year.Should().Be(2011);
            writingCrew[0].Show.Airs.Should().BeNull();
            writingCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            writingCrew[0].Show.Ids.Should().NotBeNull();
            writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            writingCrew[0].Show.Genres.Should().BeNull();
            writingCrew[0].Show.Seasons.Should().BeNull();
            writingCrew[0].Show.Overview.Should().BeNullOrEmpty();
            writingCrew[0].Show.FirstAired.Should().NotHaveValue();
            writingCrew[0].Show.Runtime.Should().NotHaveValue();
            writingCrew[0].Show.Certification.Should().BeNullOrEmpty();
            writingCrew[0].Show.Network.Should().BeNullOrEmpty();
            writingCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            writingCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            writingCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            writingCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            writingCrew[0].Show.Status.Should().BeNull();
            writingCrew[0].Show.Rating.Should().NotHaveValue();
            writingCrew[0].Show.Votes.Should().NotHaveValue();
            writingCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            writingCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            writingCrew[1].Should().NotBeNull();
            writingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer 2");
            writingCrew[1].Show.Should().NotBeNull();
            writingCrew[1].Show.Title.Should().Be("Game of Thrones");
            writingCrew[1].Show.Year.Should().Be(2011);
            writingCrew[1].Show.Airs.Should().BeNull();
            writingCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            writingCrew[1].Show.Ids.Should().NotBeNull();
            writingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            writingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            writingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            writingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            writingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            writingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            writingCrew[1].Show.Genres.Should().BeNull();
            writingCrew[1].Show.Seasons.Should().BeNull();
            writingCrew[1].Show.Overview.Should().BeNullOrEmpty();
            writingCrew[1].Show.FirstAired.Should().NotHaveValue();
            writingCrew[1].Show.Runtime.Should().NotHaveValue();
            writingCrew[1].Show.Certification.Should().BeNullOrEmpty();
            writingCrew[1].Show.Network.Should().BeNullOrEmpty();
            writingCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            writingCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            writingCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            writingCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            writingCrew[1].Show.Status.Should().BeNull();
            writingCrew[1].Show.Rating.Should().NotHaveValue();
            writingCrew[1].Show.Votes.Should().NotHaveValue();
            writingCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            writingCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);

            var soundCrew = creditsCrew.Sound.ToArray();

            soundCrew[0].Should().NotBeNull();
            soundCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Sound Designer 1");
            soundCrew[0].Show.Should().NotBeNull();
            soundCrew[0].Show.Title.Should().Be("Game of Thrones");
            soundCrew[0].Show.Year.Should().Be(2011);
            soundCrew[0].Show.Airs.Should().BeNull();
            soundCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            soundCrew[0].Show.Ids.Should().NotBeNull();
            soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            soundCrew[0].Show.Genres.Should().BeNull();
            soundCrew[0].Show.Seasons.Should().BeNull();
            soundCrew[0].Show.Overview.Should().BeNullOrEmpty();
            soundCrew[0].Show.FirstAired.Should().NotHaveValue();
            soundCrew[0].Show.Runtime.Should().NotHaveValue();
            soundCrew[0].Show.Certification.Should().BeNullOrEmpty();
            soundCrew[0].Show.Network.Should().BeNullOrEmpty();
            soundCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            soundCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            soundCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            soundCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            soundCrew[0].Show.Status.Should().BeNull();
            soundCrew[0].Show.Rating.Should().NotHaveValue();
            soundCrew[0].Show.Votes.Should().NotHaveValue();
            soundCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            soundCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            soundCrew[1].Should().NotBeNull();
            soundCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Sound Designer 2");
            soundCrew[1].Show.Should().NotBeNull();
            soundCrew[1].Show.Title.Should().Be("Game of Thrones");
            soundCrew[1].Show.Year.Should().Be(2011);
            soundCrew[1].Show.Airs.Should().BeNull();
            soundCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            soundCrew[1].Show.Ids.Should().NotBeNull();
            soundCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            soundCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            soundCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            soundCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            soundCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            soundCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            soundCrew[1].Show.Genres.Should().BeNull();
            soundCrew[1].Show.Seasons.Should().BeNull();
            soundCrew[1].Show.Overview.Should().BeNullOrEmpty();
            soundCrew[1].Show.FirstAired.Should().NotHaveValue();
            soundCrew[1].Show.Runtime.Should().NotHaveValue();
            soundCrew[1].Show.Certification.Should().BeNullOrEmpty();
            soundCrew[1].Show.Network.Should().BeNullOrEmpty();
            soundCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            soundCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            soundCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            soundCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            soundCrew[1].Show.Status.Should().BeNull();
            soundCrew[1].Show.Rating.Should().NotHaveValue();
            soundCrew[1].Show.Votes.Should().NotHaveValue();
            soundCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            soundCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);

            var cameraCrew = creditsCrew.Camera.ToArray();

            cameraCrew[0].Should().NotBeNull();
            cameraCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Camera Man 1");
            cameraCrew[0].Show.Should().NotBeNull();
            cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
            cameraCrew[0].Show.Year.Should().Be(2011);
            cameraCrew[0].Show.Airs.Should().BeNull();
            cameraCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            cameraCrew[0].Show.Ids.Should().NotBeNull();
            cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            cameraCrew[0].Show.Genres.Should().BeNull();
            cameraCrew[0].Show.Seasons.Should().BeNull();
            cameraCrew[0].Show.Overview.Should().BeNullOrEmpty();
            cameraCrew[0].Show.FirstAired.Should().NotHaveValue();
            cameraCrew[0].Show.Runtime.Should().NotHaveValue();
            cameraCrew[0].Show.Certification.Should().BeNullOrEmpty();
            cameraCrew[0].Show.Network.Should().BeNullOrEmpty();
            cameraCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            cameraCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            cameraCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            cameraCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            cameraCrew[0].Show.Status.Should().BeNull();
            cameraCrew[0].Show.Rating.Should().NotHaveValue();
            cameraCrew[0].Show.Votes.Should().NotHaveValue();
            cameraCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            cameraCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            cameraCrew[1].Should().NotBeNull();
            cameraCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Camera Man 2");
            cameraCrew[1].Show.Should().NotBeNull();
            cameraCrew[1].Show.Title.Should().Be("Game of Thrones");
            cameraCrew[1].Show.Year.Should().Be(2011);
            cameraCrew[1].Show.Airs.Should().BeNull();
            cameraCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            cameraCrew[1].Show.Ids.Should().NotBeNull();
            cameraCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            cameraCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            cameraCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            cameraCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            cameraCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            cameraCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            cameraCrew[1].Show.Genres.Should().BeNull();
            cameraCrew[1].Show.Seasons.Should().BeNull();
            cameraCrew[1].Show.Overview.Should().BeNullOrEmpty();
            cameraCrew[1].Show.FirstAired.Should().NotHaveValue();
            cameraCrew[1].Show.Runtime.Should().NotHaveValue();
            cameraCrew[1].Show.Certification.Should().BeNullOrEmpty();
            cameraCrew[1].Show.Network.Should().BeNullOrEmpty();
            cameraCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            cameraCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            cameraCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            cameraCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            cameraCrew[1].Show.Status.Should().BeNull();
            cameraCrew[1].Show.Rating.Should().NotHaveValue();
            cameraCrew[1].Show.Votes.Should().NotHaveValue();
            cameraCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            cameraCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);

            var lightingCrew = creditsCrew.Lighting.ToArray();

            lightingCrew[0].Should().NotBeNull();
            lightingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Light Technician 1");
            lightingCrew[0].Show.Should().NotBeNull();
            lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
            lightingCrew[0].Show.Year.Should().Be(2011);
            lightingCrew[0].Show.Airs.Should().BeNull();
            lightingCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            lightingCrew[0].Show.Ids.Should().NotBeNull();
            lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            lightingCrew[0].Show.Genres.Should().BeNull();
            lightingCrew[0].Show.Seasons.Should().BeNull();
            lightingCrew[0].Show.Overview.Should().BeNullOrEmpty();
            lightingCrew[0].Show.FirstAired.Should().NotHaveValue();
            lightingCrew[0].Show.Runtime.Should().NotHaveValue();
            lightingCrew[0].Show.Certification.Should().BeNullOrEmpty();
            lightingCrew[0].Show.Network.Should().BeNullOrEmpty();
            lightingCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            lightingCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            lightingCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            lightingCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            lightingCrew[0].Show.Status.Should().BeNull();
            lightingCrew[0].Show.Rating.Should().NotHaveValue();
            lightingCrew[0].Show.Votes.Should().NotHaveValue();
            lightingCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            lightingCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            lightingCrew[1].Should().NotBeNull();
            lightingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Light Technician 2");
            lightingCrew[1].Show.Should().NotBeNull();
            lightingCrew[1].Show.Title.Should().Be("Game of Thrones");
            lightingCrew[1].Show.Year.Should().Be(2011);
            lightingCrew[1].Show.Airs.Should().BeNull();
            lightingCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            lightingCrew[1].Show.Ids.Should().NotBeNull();
            lightingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            lightingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            lightingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            lightingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            lightingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            lightingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            lightingCrew[1].Show.Genres.Should().BeNull();
            lightingCrew[1].Show.Seasons.Should().BeNull();
            lightingCrew[1].Show.Overview.Should().BeNullOrEmpty();
            lightingCrew[1].Show.FirstAired.Should().NotHaveValue();
            lightingCrew[1].Show.Runtime.Should().NotHaveValue();
            lightingCrew[1].Show.Certification.Should().BeNullOrEmpty();
            lightingCrew[1].Show.Network.Should().BeNullOrEmpty();
            lightingCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            lightingCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            lightingCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            lightingCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            lightingCrew[1].Show.Status.Should().BeNull();
            lightingCrew[1].Show.Rating.Should().NotHaveValue();
            lightingCrew[1].Show.Votes.Should().NotHaveValue();
            lightingCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            lightingCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);

            var vfxCrew = creditsCrew.VisualEffects.ToArray();

            vfxCrew[0].Should().NotBeNull();
            vfxCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("VFX Artist 1");
            vfxCrew[0].Show.Should().NotBeNull();
            vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
            vfxCrew[0].Show.Year.Should().Be(2011);
            vfxCrew[0].Show.Airs.Should().BeNull();
            vfxCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            vfxCrew[0].Show.Ids.Should().NotBeNull();
            vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            vfxCrew[0].Show.Genres.Should().BeNull();
            vfxCrew[0].Show.Seasons.Should().BeNull();
            vfxCrew[0].Show.Overview.Should().BeNullOrEmpty();
            vfxCrew[0].Show.FirstAired.Should().NotHaveValue();
            vfxCrew[0].Show.Runtime.Should().NotHaveValue();
            vfxCrew[0].Show.Certification.Should().BeNullOrEmpty();
            vfxCrew[0].Show.Network.Should().BeNullOrEmpty();
            vfxCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            vfxCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            vfxCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            vfxCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            vfxCrew[0].Show.Status.Should().BeNull();
            vfxCrew[0].Show.Rating.Should().NotHaveValue();
            vfxCrew[0].Show.Votes.Should().NotHaveValue();
            vfxCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            vfxCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            vfxCrew[1].Should().NotBeNull();
            vfxCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("VFX Artist 2");
            vfxCrew[1].Show.Should().NotBeNull();
            vfxCrew[1].Show.Title.Should().Be("Game of Thrones");
            vfxCrew[1].Show.Year.Should().Be(2011);
            vfxCrew[1].Show.Airs.Should().BeNull();
            vfxCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            vfxCrew[1].Show.Ids.Should().NotBeNull();
            vfxCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            vfxCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            vfxCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            vfxCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            vfxCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            vfxCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            vfxCrew[1].Show.Genres.Should().BeNull();
            vfxCrew[1].Show.Seasons.Should().BeNull();
            vfxCrew[1].Show.Overview.Should().BeNullOrEmpty();
            vfxCrew[1].Show.FirstAired.Should().NotHaveValue();
            vfxCrew[1].Show.Runtime.Should().NotHaveValue();
            vfxCrew[1].Show.Certification.Should().BeNullOrEmpty();
            vfxCrew[1].Show.Network.Should().BeNullOrEmpty();
            vfxCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            vfxCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            vfxCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            vfxCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            vfxCrew[1].Show.Status.Should().BeNull();
            vfxCrew[1].Show.Rating.Should().NotHaveValue();
            vfxCrew[1].Show.Votes.Should().NotHaveValue();
            vfxCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            vfxCrew[1].Show.AiredEpisodes.Should().NotHaveValue();

            creditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);

            var editingCrew = creditsCrew.Editing.ToArray();

            editingCrew[0].Should().NotBeNull();
            editingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor 1");
            editingCrew[0].Show.Should().NotBeNull();
            editingCrew[0].Show.Title.Should().Be("Game of Thrones");
            editingCrew[0].Show.Year.Should().Be(2011);
            editingCrew[0].Show.Airs.Should().BeNull();
            editingCrew[0].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            editingCrew[0].Show.Ids.Should().NotBeNull();
            editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            editingCrew[0].Show.Genres.Should().BeNull();
            editingCrew[0].Show.Seasons.Should().BeNull();
            editingCrew[0].Show.Overview.Should().BeNullOrEmpty();
            editingCrew[0].Show.FirstAired.Should().NotHaveValue();
            editingCrew[0].Show.Runtime.Should().NotHaveValue();
            editingCrew[0].Show.Certification.Should().BeNullOrEmpty();
            editingCrew[0].Show.Network.Should().BeNullOrEmpty();
            editingCrew[0].Show.CountryCode.Should().BeNullOrEmpty();
            editingCrew[0].Show.UpdatedAt.Should().NotHaveValue();
            editingCrew[0].Show.Trailer.Should().BeNullOrEmpty();
            editingCrew[0].Show.Homepage.Should().BeNullOrEmpty();
            editingCrew[0].Show.Status.Should().BeNull();
            editingCrew[0].Show.Rating.Should().NotHaveValue();
            editingCrew[0].Show.Votes.Should().NotHaveValue();
            editingCrew[0].Show.LanguageCode.Should().BeNullOrEmpty();
            editingCrew[0].Show.AiredEpisodes.Should().NotHaveValue();

            editingCrew[1].Should().NotBeNull();
            editingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor 2");
            editingCrew[1].Show.Should().NotBeNull();
            editingCrew[1].Show.Title.Should().Be("Game of Thrones");
            editingCrew[1].Show.Year.Should().Be(2011);
            editingCrew[1].Show.Airs.Should().BeNull();
            editingCrew[1].Show.AvailableTranslationLanguageCodes.Should().BeNull();
            editingCrew[1].Show.Ids.Should().NotBeNull();
            editingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            editingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            editingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            editingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            editingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            editingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            editingCrew[1].Show.Genres.Should().BeNull();
            editingCrew[1].Show.Seasons.Should().BeNull();
            editingCrew[1].Show.Overview.Should().BeNullOrEmpty();
            editingCrew[1].Show.FirstAired.Should().NotHaveValue();
            editingCrew[1].Show.Runtime.Should().NotHaveValue();
            editingCrew[1].Show.Certification.Should().BeNullOrEmpty();
            editingCrew[1].Show.Network.Should().BeNullOrEmpty();
            editingCrew[1].Show.CountryCode.Should().BeNullOrEmpty();
            editingCrew[1].Show.UpdatedAt.Should().NotHaveValue();
            editingCrew[1].Show.Trailer.Should().BeNullOrEmpty();
            editingCrew[1].Show.Homepage.Should().BeNullOrEmpty();
            editingCrew[1].Show.Status.Should().BeNull();
            editingCrew[1].Show.Rating.Should().NotHaveValue();
            editingCrew[1].Show.Votes.Should().NotHaveValue();
            editingCrew[1].Show.LanguageCode.Should().BeNullOrEmpty();
            editingCrew[1].Show.AiredEpisodes.Should().NotHaveValue();
        }

        private const string JSON =
            @"{
                ""cast"": [
                  {
                     ""characters"": [
                       ""Jon Snow""
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
                  },
                  {
                     ""characters"": [
                       ""Jon Snow""
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
                  }
                ],
                ""crew"": {
                  ""production"": [
                    {
                      ""jobs"": [
                        ""Producer 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Producer 2""
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
                    }
                  ],
                  ""art"": [
                    {
                      ""jobs"": [
                        ""Art Director 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Art Director 2""
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
                    }
                  ],
                  ""crew"": [
                    {
                      ""jobs"": [
                        ""Crew Member 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Crew Member 2""
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
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""jobs"": [
                        ""Costume Designer""
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
                    },
                    {
                      ""jobs"": [
                        ""Make Up Artist""
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
                    }
                  ],
                  ""directing"": [
                    {
                      ""jobs"": [
                        ""Director 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Director 2""
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
                    }
                  ],
                  ""writing"": [
                    {
                      ""jobs"": [
                        ""Writer 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Writer 2""
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
                    }
                  ],
                  ""sound"": [
                    {
                      ""jobs"": [
                        ""Sound Designer 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Sound Designer 2""
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
                    }
                  ],
                  ""camera"": [
                    {
                      ""jobs"": [
                        ""Camera Man 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Camera Man 2""
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
                    }
                  ],
                  ""lighting"": [
                    {
                      ""jobs"": [
                        ""Light Technician 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Light Technician 2""
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
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""jobs"": [
                        ""VFX Artist 1""
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
                    },
                    {
                      ""jobs"": [
                        ""VFX Artist 2""
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
                    }
                  ],
                  ""editing"": [
                    {
                      ""jobs"": [
                        ""Editor 1""
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
                    },
                    {
                      ""jobs"": [
                        ""Editor 2""
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
                    }
                  ]
                }
              }";
    }
}
