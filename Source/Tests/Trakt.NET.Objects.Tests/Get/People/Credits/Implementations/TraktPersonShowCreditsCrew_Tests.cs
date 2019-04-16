namespace TraktNet.Objects.Tests.Get.People.Credits.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonShowCreditsCrew_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsCrew_Default_Constructor()
        {
            var creditsCrew = new TraktPersonShowCreditsCrew();

            creditsCrew.Production.Should().BeNull();
            creditsCrew.Art.Should().BeNull();
            creditsCrew.Crew.Should().BeNull();
            creditsCrew.CostumeAndMakeup.Should().BeNull();
            creditsCrew.Directing.Should().BeNull();
            creditsCrew.Writing.Should().BeNull();
            creditsCrew.Sound.Should().BeNull();
            creditsCrew.Camera.Should().BeNull();
            creditsCrew.Lighting.Should().BeNull();
            creditsCrew.VisualEffects.Should().BeNull();
            creditsCrew.Editing.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonShowCreditsCrew_From_Minimal_Json()
        {
            var jsonReader = new PersonShowCreditsCrewObjectJsonReader();
            var creditsCrew = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktPersonShowCreditsCrew;

            creditsCrew.Should().NotBeNull();
            creditsCrew.Production.Should().NotBeNull().And.HaveCount(2);

            var productionCrew = creditsCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Job.Should().Be("Producer 1");
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
            productionCrew[1].Job.Should().Be("Producer 2");
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
            artCrew[0].Job.Should().Be("Art Director 1");
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
            artCrew[1].Job.Should().Be("Art Director 2");
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
            crew[0].Job.Should().Be("Crew Member 1");
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
            crew[1].Job.Should().Be("Crew Member 2");
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
            costumeAndMakeupCrew[0].Job.Should().Be("Costume Designer");
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
            costumeAndMakeupCrew[1].Job.Should().Be("Make Up Artist");
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
            directingCrew[0].Job.Should().Be("Director 1");
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
            directingCrew[1].Job.Should().Be("Director 2");
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
            writingCrew[0].Job.Should().Be("Writer 1");
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
            writingCrew[1].Job.Should().Be("Writer 2");
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
            soundCrew[0].Job.Should().Be("Sound Designer 1");
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
            soundCrew[1].Job.Should().Be("Sound Designer 2");
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
            cameraCrew[0].Job.Should().Be("Camera Man 1");
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
            cameraCrew[1].Job.Should().Be("Camera Man 2");
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
            lightingCrew[0].Job.Should().Be("Light Technician 1");
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
            lightingCrew[1].Job.Should().Be("Light Technician 2");
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
            vfxCrew[0].Job.Should().Be("VFX Artist 1");
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
            vfxCrew[1].Job.Should().Be("VFX Artist 2");
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
            editingCrew[0].Job.Should().Be("Editor 1");
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
            editingCrew[1].Job.Should().Be("Editor 2");
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

        [Fact]
        public async Task Test_TraktPersonShowCreditsCrew_From_Full_Json()
        {
            var jsonReader = new PersonShowCreditsCrewObjectJsonReader();
            var creditsCrew = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktPersonShowCreditsCrew;

            creditsCrew.Should().NotBeNull();
            creditsCrew.Production.Should().NotBeNull().And.HaveCount(2);

            var productionCrew = creditsCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Job.Should().Be("Producer 1");
            productionCrew[0].Show.Should().NotBeNull();
            productionCrew[0].Show.Title.Should().Be("Game of Thrones");
            productionCrew[0].Show.Year.Should().Be(2011);
            productionCrew[0].Show.Airs.Should().NotBeNull();
            productionCrew[0].Show.Airs.Day.Should().Be("Sunday");
            productionCrew[0].Show.Airs.Time.Should().Be("21:00");
            productionCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            productionCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            productionCrew[0].Show.Ids.Should().NotBeNull();
            productionCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            productionCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            productionCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            productionCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            productionCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            productionCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            productionCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            productionCrew[0].Show.Seasons.Should().BeNull();
            productionCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            productionCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            productionCrew[0].Show.Runtime.Should().Be(60);
            productionCrew[0].Show.Certification.Should().Be("TV-MA");
            productionCrew[0].Show.Network.Should().Be("HBO");
            productionCrew[0].Show.CountryCode.Should().Be("us");
            productionCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            productionCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            productionCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            productionCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            productionCrew[0].Show.Rating.Should().Be(9.38327f);
            productionCrew[0].Show.Votes.Should().Be(44773);
            productionCrew[0].Show.LanguageCode.Should().Be("en");
            productionCrew[0].Show.AiredEpisodes.Should().Be(50);

            productionCrew[1].Should().NotBeNull();
            productionCrew[1].Job.Should().Be("Producer 2");
            productionCrew[1].Show.Should().NotBeNull();
            productionCrew[1].Show.Title.Should().Be("Game of Thrones");
            productionCrew[1].Show.Year.Should().Be(2011);
            productionCrew[1].Show.Airs.Should().NotBeNull();
            productionCrew[1].Show.Airs.Day.Should().Be("Sunday");
            productionCrew[1].Show.Airs.Time.Should().Be("21:00");
            productionCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            productionCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            productionCrew[1].Show.Ids.Should().NotBeNull();
            productionCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            productionCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            productionCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            productionCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            productionCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            productionCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            productionCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            productionCrew[1].Show.Seasons.Should().BeNull();
            productionCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            productionCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            productionCrew[1].Show.Runtime.Should().Be(60);
            productionCrew[1].Show.Certification.Should().Be("TV-MA");
            productionCrew[1].Show.Network.Should().Be("HBO");
            productionCrew[1].Show.CountryCode.Should().Be("us");
            productionCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            productionCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            productionCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            productionCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            productionCrew[1].Show.Rating.Should().Be(9.38327f);
            productionCrew[1].Show.Votes.Should().Be(44773);
            productionCrew[1].Show.LanguageCode.Should().Be("en");
            productionCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Art.Should().NotBeNull().And.HaveCount(2);

            var artCrew = creditsCrew.Art.ToArray();

            artCrew[0].Should().NotBeNull();
            artCrew[0].Job.Should().Be("Art Director 1");
            artCrew[0].Show.Should().NotBeNull();
            artCrew[0].Show.Title.Should().Be("Game of Thrones");
            artCrew[0].Show.Year.Should().Be(2011);
            artCrew[0].Show.Airs.Should().NotBeNull();
            artCrew[0].Show.Airs.Day.Should().Be("Sunday");
            artCrew[0].Show.Airs.Time.Should().Be("21:00");
            artCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            artCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            artCrew[0].Show.Ids.Should().NotBeNull();
            artCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            artCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            artCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            artCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            artCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            artCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            artCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            artCrew[0].Show.Seasons.Should().BeNull();
            artCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            artCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            artCrew[0].Show.Runtime.Should().Be(60);
            artCrew[0].Show.Certification.Should().Be("TV-MA");
            artCrew[0].Show.Network.Should().Be("HBO");
            artCrew[0].Show.CountryCode.Should().Be("us");
            artCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            artCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            artCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            artCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            artCrew[0].Show.Rating.Should().Be(9.38327f);
            artCrew[0].Show.Votes.Should().Be(44773);
            artCrew[0].Show.LanguageCode.Should().Be("en");
            artCrew[0].Show.AiredEpisodes.Should().Be(50);

            artCrew[1].Should().NotBeNull();
            artCrew[1].Job.Should().Be("Art Director 2");
            artCrew[1].Show.Should().NotBeNull();
            artCrew[1].Show.Title.Should().Be("Game of Thrones");
            artCrew[1].Show.Year.Should().Be(2011);
            artCrew[1].Show.Airs.Should().NotBeNull();
            artCrew[1].Show.Airs.Day.Should().Be("Sunday");
            artCrew[1].Show.Airs.Time.Should().Be("21:00");
            artCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            artCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            artCrew[1].Show.Ids.Should().NotBeNull();
            artCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            artCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            artCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            artCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            artCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            artCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            artCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            artCrew[1].Show.Seasons.Should().BeNull();
            artCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            artCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            artCrew[1].Show.Runtime.Should().Be(60);
            artCrew[1].Show.Certification.Should().Be("TV-MA");
            artCrew[1].Show.Network.Should().Be("HBO");
            artCrew[1].Show.CountryCode.Should().Be("us");
            artCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            artCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            artCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            artCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            artCrew[1].Show.Rating.Should().Be(9.38327f);
            artCrew[1].Show.Votes.Should().Be(44773);
            artCrew[1].Show.LanguageCode.Should().Be("en");
            artCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);

            var crew = creditsCrew.Crew.ToArray();

            crew[0].Should().NotBeNull();
            crew[0].Job.Should().Be("Crew Member 1");
            crew[0].Show.Should().NotBeNull();
            crew[0].Show.Title.Should().Be("Game of Thrones");
            crew[0].Show.Year.Should().Be(2011);
            crew[0].Show.Airs.Should().NotBeNull();
            crew[0].Show.Airs.Day.Should().Be("Sunday");
            crew[0].Show.Airs.Time.Should().Be("21:00");
            crew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            crew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            crew[0].Show.Ids.Should().NotBeNull();
            crew[0].Show.Ids.Trakt.Should().Be(1390U);
            crew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            crew[0].Show.Ids.Tvdb.Should().Be(121361U);
            crew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            crew[0].Show.Ids.Tmdb.Should().Be(1399U);
            crew[0].Show.Ids.TvRage.Should().Be(24493U);
            crew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            crew[0].Show.Seasons.Should().BeNull();
            crew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            crew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            crew[0].Show.Runtime.Should().Be(60);
            crew[0].Show.Certification.Should().Be("TV-MA");
            crew[0].Show.Network.Should().Be("HBO");
            crew[0].Show.CountryCode.Should().Be("us");
            crew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            crew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            crew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            crew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            crew[0].Show.Rating.Should().Be(9.38327f);
            crew[0].Show.Votes.Should().Be(44773);
            crew[0].Show.LanguageCode.Should().Be("en");
            crew[0].Show.AiredEpisodes.Should().Be(50);

            crew[1].Should().NotBeNull();
            crew[1].Job.Should().Be("Crew Member 2");
            crew[1].Show.Should().NotBeNull();
            crew[1].Show.Title.Should().Be("Game of Thrones");
            crew[1].Show.Year.Should().Be(2011);
            crew[1].Show.Airs.Should().NotBeNull();
            crew[1].Show.Airs.Day.Should().Be("Sunday");
            crew[1].Show.Airs.Time.Should().Be("21:00");
            crew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            crew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            crew[1].Show.Ids.Should().NotBeNull();
            crew[1].Show.Ids.Trakt.Should().Be(1390U);
            crew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            crew[1].Show.Ids.Tvdb.Should().Be(121361U);
            crew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            crew[1].Show.Ids.Tmdb.Should().Be(1399U);
            crew[1].Show.Ids.TvRage.Should().Be(24493U);
            crew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            crew[1].Show.Seasons.Should().BeNull();
            crew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            crew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            crew[1].Show.Runtime.Should().Be(60);
            crew[1].Show.Certification.Should().Be("TV-MA");
            crew[1].Show.Network.Should().Be("HBO");
            crew[1].Show.CountryCode.Should().Be("us");
            crew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            crew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            crew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            crew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            crew[1].Show.Rating.Should().Be(9.38327f);
            crew[1].Show.Votes.Should().Be(44773);
            crew[1].Show.LanguageCode.Should().Be("en");
            crew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);

            var costumeAndMakeupCrew = creditsCrew.CostumeAndMakeup.ToArray();

            costumeAndMakeupCrew[0].Should().NotBeNull();
            costumeAndMakeupCrew[0].Job.Should().Be("Costume Designer");
            costumeAndMakeupCrew[0].Show.Should().NotBeNull();
            costumeAndMakeupCrew[0].Show.Title.Should().Be("Game of Thrones");
            costumeAndMakeupCrew[0].Show.Year.Should().Be(2011);
            costumeAndMakeupCrew[0].Show.Airs.Should().NotBeNull();
            costumeAndMakeupCrew[0].Show.Airs.Day.Should().Be("Sunday");
            costumeAndMakeupCrew[0].Show.Airs.Time.Should().Be("21:00");
            costumeAndMakeupCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            costumeAndMakeupCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            costumeAndMakeupCrew[0].Show.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            costumeAndMakeupCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            costumeAndMakeupCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            costumeAndMakeupCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            costumeAndMakeupCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            costumeAndMakeupCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            costumeAndMakeupCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            costumeAndMakeupCrew[0].Show.Seasons.Should().BeNull();
            costumeAndMakeupCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            costumeAndMakeupCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            costumeAndMakeupCrew[0].Show.Runtime.Should().Be(60);
            costumeAndMakeupCrew[0].Show.Certification.Should().Be("TV-MA");
            costumeAndMakeupCrew[0].Show.Network.Should().Be("HBO");
            costumeAndMakeupCrew[0].Show.CountryCode.Should().Be("us");
            costumeAndMakeupCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            costumeAndMakeupCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            costumeAndMakeupCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            costumeAndMakeupCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            costumeAndMakeupCrew[0].Show.Rating.Should().Be(9.38327f);
            costumeAndMakeupCrew[0].Show.Votes.Should().Be(44773);
            costumeAndMakeupCrew[0].Show.LanguageCode.Should().Be("en");
            costumeAndMakeupCrew[0].Show.AiredEpisodes.Should().Be(50);

            costumeAndMakeupCrew[1].Should().NotBeNull();
            costumeAndMakeupCrew[1].Job.Should().Be("Make Up Artist");
            costumeAndMakeupCrew[1].Show.Should().NotBeNull();
            costumeAndMakeupCrew[1].Show.Title.Should().Be("Game of Thrones");
            costumeAndMakeupCrew[1].Show.Year.Should().Be(2011);
            costumeAndMakeupCrew[1].Show.Airs.Should().NotBeNull();
            costumeAndMakeupCrew[1].Show.Airs.Day.Should().Be("Sunday");
            costumeAndMakeupCrew[1].Show.Airs.Time.Should().Be("21:00");
            costumeAndMakeupCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            costumeAndMakeupCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            costumeAndMakeupCrew[1].Show.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            costumeAndMakeupCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            costumeAndMakeupCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            costumeAndMakeupCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            costumeAndMakeupCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            costumeAndMakeupCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            costumeAndMakeupCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            costumeAndMakeupCrew[1].Show.Seasons.Should().BeNull();
            costumeAndMakeupCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            costumeAndMakeupCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            costumeAndMakeupCrew[1].Show.Runtime.Should().Be(60);
            costumeAndMakeupCrew[1].Show.Certification.Should().Be("TV-MA");
            costumeAndMakeupCrew[1].Show.Network.Should().Be("HBO");
            costumeAndMakeupCrew[1].Show.CountryCode.Should().Be("us");
            costumeAndMakeupCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            costumeAndMakeupCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            costumeAndMakeupCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            costumeAndMakeupCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            costumeAndMakeupCrew[1].Show.Rating.Should().Be(9.38327f);
            costumeAndMakeupCrew[1].Show.Votes.Should().Be(44773);
            costumeAndMakeupCrew[1].Show.LanguageCode.Should().Be("en");
            costumeAndMakeupCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);

            var directingCrew = creditsCrew.Directing.ToArray();

            directingCrew[0].Should().NotBeNull();
            directingCrew[0].Job.Should().Be("Director 1");
            directingCrew[0].Show.Should().NotBeNull();
            directingCrew[0].Show.Title.Should().Be("Game of Thrones");
            directingCrew[0].Show.Year.Should().Be(2011);
            directingCrew[0].Show.Airs.Should().NotBeNull();
            directingCrew[0].Show.Airs.Day.Should().Be("Sunday");
            directingCrew[0].Show.Airs.Time.Should().Be("21:00");
            directingCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            directingCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            directingCrew[0].Show.Ids.Should().NotBeNull();
            directingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            directingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            directingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            directingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            directingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            directingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            directingCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            directingCrew[0].Show.Seasons.Should().BeNull();
            directingCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            directingCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            directingCrew[0].Show.Runtime.Should().Be(60);
            directingCrew[0].Show.Certification.Should().Be("TV-MA");
            directingCrew[0].Show.Network.Should().Be("HBO");
            directingCrew[0].Show.CountryCode.Should().Be("us");
            directingCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            directingCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            directingCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            directingCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            directingCrew[0].Show.Rating.Should().Be(9.38327f);
            directingCrew[0].Show.Votes.Should().Be(44773);
            directingCrew[0].Show.LanguageCode.Should().Be("en");
            directingCrew[0].Show.AiredEpisodes.Should().Be(50);

            directingCrew[1].Should().NotBeNull();
            directingCrew[1].Job.Should().Be("Director 2");
            directingCrew[1].Show.Should().NotBeNull();
            directingCrew[1].Show.Title.Should().Be("Game of Thrones");
            directingCrew[1].Show.Year.Should().Be(2011);
            directingCrew[1].Show.Airs.Should().NotBeNull();
            directingCrew[1].Show.Airs.Day.Should().Be("Sunday");
            directingCrew[1].Show.Airs.Time.Should().Be("21:00");
            directingCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            directingCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            directingCrew[1].Show.Ids.Should().NotBeNull();
            directingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            directingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            directingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            directingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            directingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            directingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            directingCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            directingCrew[1].Show.Seasons.Should().BeNull();
            directingCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            directingCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            directingCrew[1].Show.Runtime.Should().Be(60);
            directingCrew[1].Show.Certification.Should().Be("TV-MA");
            directingCrew[1].Show.Network.Should().Be("HBO");
            directingCrew[1].Show.CountryCode.Should().Be("us");
            directingCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            directingCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            directingCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            directingCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            directingCrew[1].Show.Rating.Should().Be(9.38327f);
            directingCrew[1].Show.Votes.Should().Be(44773);
            directingCrew[1].Show.LanguageCode.Should().Be("en");
            directingCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);

            var writingCrew = creditsCrew.Writing.ToArray();

            writingCrew[0].Should().NotBeNull();
            writingCrew[0].Job.Should().Be("Writer 1");
            writingCrew[0].Show.Should().NotBeNull();
            writingCrew[0].Show.Title.Should().Be("Game of Thrones");
            writingCrew[0].Show.Year.Should().Be(2011);
            writingCrew[0].Show.Airs.Should().NotBeNull();
            writingCrew[0].Show.Airs.Day.Should().Be("Sunday");
            writingCrew[0].Show.Airs.Time.Should().Be("21:00");
            writingCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            writingCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            writingCrew[0].Show.Ids.Should().NotBeNull();
            writingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            writingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            writingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            writingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            writingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            writingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            writingCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            writingCrew[0].Show.Seasons.Should().BeNull();
            writingCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            writingCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            writingCrew[0].Show.Runtime.Should().Be(60);
            writingCrew[0].Show.Certification.Should().Be("TV-MA");
            writingCrew[0].Show.Network.Should().Be("HBO");
            writingCrew[0].Show.CountryCode.Should().Be("us");
            writingCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            writingCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            writingCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            writingCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            writingCrew[0].Show.Rating.Should().Be(9.38327f);
            writingCrew[0].Show.Votes.Should().Be(44773);
            writingCrew[0].Show.LanguageCode.Should().Be("en");
            writingCrew[0].Show.AiredEpisodes.Should().Be(50);

            writingCrew[1].Should().NotBeNull();
            writingCrew[1].Job.Should().Be("Writer 2");
            writingCrew[1].Show.Should().NotBeNull();
            writingCrew[1].Show.Title.Should().Be("Game of Thrones");
            writingCrew[1].Show.Year.Should().Be(2011);
            writingCrew[1].Show.Airs.Should().NotBeNull();
            writingCrew[1].Show.Airs.Day.Should().Be("Sunday");
            writingCrew[1].Show.Airs.Time.Should().Be("21:00");
            writingCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            writingCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            writingCrew[1].Show.Ids.Should().NotBeNull();
            writingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            writingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            writingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            writingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            writingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            writingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            writingCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            writingCrew[1].Show.Seasons.Should().BeNull();
            writingCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            writingCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            writingCrew[1].Show.Runtime.Should().Be(60);
            writingCrew[1].Show.Certification.Should().Be("TV-MA");
            writingCrew[1].Show.Network.Should().Be("HBO");
            writingCrew[1].Show.CountryCode.Should().Be("us");
            writingCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            writingCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            writingCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            writingCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            writingCrew[1].Show.Rating.Should().Be(9.38327f);
            writingCrew[1].Show.Votes.Should().Be(44773);
            writingCrew[1].Show.LanguageCode.Should().Be("en");
            writingCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);

            var soundCrew = creditsCrew.Sound.ToArray();

            soundCrew[0].Should().NotBeNull();
            soundCrew[0].Job.Should().Be("Sound Designer 1");
            soundCrew[0].Show.Should().NotBeNull();
            soundCrew[0].Show.Title.Should().Be("Game of Thrones");
            soundCrew[0].Show.Year.Should().Be(2011);
            soundCrew[0].Show.Airs.Should().NotBeNull();
            soundCrew[0].Show.Airs.Day.Should().Be("Sunday");
            soundCrew[0].Show.Airs.Time.Should().Be("21:00");
            soundCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            soundCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            soundCrew[0].Show.Ids.Should().NotBeNull();
            soundCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            soundCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            soundCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            soundCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            soundCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            soundCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            soundCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            soundCrew[0].Show.Seasons.Should().BeNull();
            soundCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            soundCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            soundCrew[0].Show.Runtime.Should().Be(60);
            soundCrew[0].Show.Certification.Should().Be("TV-MA");
            soundCrew[0].Show.Network.Should().Be("HBO");
            soundCrew[0].Show.CountryCode.Should().Be("us");
            soundCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            soundCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            soundCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            soundCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            soundCrew[0].Show.Rating.Should().Be(9.38327f);
            soundCrew[0].Show.Votes.Should().Be(44773);
            soundCrew[0].Show.LanguageCode.Should().Be("en");
            soundCrew[0].Show.AiredEpisodes.Should().Be(50);

            soundCrew[1].Should().NotBeNull();
            soundCrew[1].Job.Should().Be("Sound Designer 2");
            soundCrew[1].Show.Should().NotBeNull();
            soundCrew[1].Show.Title.Should().Be("Game of Thrones");
            soundCrew[1].Show.Year.Should().Be(2011);
            soundCrew[1].Show.Airs.Should().NotBeNull();
            soundCrew[1].Show.Airs.Day.Should().Be("Sunday");
            soundCrew[1].Show.Airs.Time.Should().Be("21:00");
            soundCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            soundCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            soundCrew[1].Show.Ids.Should().NotBeNull();
            soundCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            soundCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            soundCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            soundCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            soundCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            soundCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            soundCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            soundCrew[1].Show.Seasons.Should().BeNull();
            soundCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            soundCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            soundCrew[1].Show.Runtime.Should().Be(60);
            soundCrew[1].Show.Certification.Should().Be("TV-MA");
            soundCrew[1].Show.Network.Should().Be("HBO");
            soundCrew[1].Show.CountryCode.Should().Be("us");
            soundCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            soundCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            soundCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            soundCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            soundCrew[1].Show.Rating.Should().Be(9.38327f);
            soundCrew[1].Show.Votes.Should().Be(44773);
            soundCrew[1].Show.LanguageCode.Should().Be("en");
            soundCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);

            var cameraCrew = creditsCrew.Camera.ToArray();

            cameraCrew[0].Should().NotBeNull();
            cameraCrew[0].Job.Should().Be("Camera Man 1");
            cameraCrew[0].Show.Should().NotBeNull();
            cameraCrew[0].Show.Title.Should().Be("Game of Thrones");
            cameraCrew[0].Show.Year.Should().Be(2011);
            cameraCrew[0].Show.Airs.Should().NotBeNull();
            cameraCrew[0].Show.Airs.Day.Should().Be("Sunday");
            cameraCrew[0].Show.Airs.Time.Should().Be("21:00");
            cameraCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            cameraCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            cameraCrew[0].Show.Ids.Should().NotBeNull();
            cameraCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            cameraCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            cameraCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            cameraCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            cameraCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            cameraCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            cameraCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            cameraCrew[0].Show.Seasons.Should().BeNull();
            cameraCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            cameraCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            cameraCrew[0].Show.Runtime.Should().Be(60);
            cameraCrew[0].Show.Certification.Should().Be("TV-MA");
            cameraCrew[0].Show.Network.Should().Be("HBO");
            cameraCrew[0].Show.CountryCode.Should().Be("us");
            cameraCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            cameraCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            cameraCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            cameraCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            cameraCrew[0].Show.Rating.Should().Be(9.38327f);
            cameraCrew[0].Show.Votes.Should().Be(44773);
            cameraCrew[0].Show.LanguageCode.Should().Be("en");
            cameraCrew[0].Show.AiredEpisodes.Should().Be(50);

            cameraCrew[1].Should().NotBeNull();
            cameraCrew[1].Job.Should().Be("Camera Man 2");
            cameraCrew[1].Show.Should().NotBeNull();
            cameraCrew[1].Show.Title.Should().Be("Game of Thrones");
            cameraCrew[1].Show.Year.Should().Be(2011);
            cameraCrew[1].Show.Airs.Should().NotBeNull();
            cameraCrew[1].Show.Airs.Day.Should().Be("Sunday");
            cameraCrew[1].Show.Airs.Time.Should().Be("21:00");
            cameraCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            cameraCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            cameraCrew[1].Show.Ids.Should().NotBeNull();
            cameraCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            cameraCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            cameraCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            cameraCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            cameraCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            cameraCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            cameraCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            cameraCrew[1].Show.Seasons.Should().BeNull();
            cameraCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            cameraCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            cameraCrew[1].Show.Runtime.Should().Be(60);
            cameraCrew[1].Show.Certification.Should().Be("TV-MA");
            cameraCrew[1].Show.Network.Should().Be("HBO");
            cameraCrew[1].Show.CountryCode.Should().Be("us");
            cameraCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            cameraCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            cameraCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            cameraCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            cameraCrew[1].Show.Rating.Should().Be(9.38327f);
            cameraCrew[1].Show.Votes.Should().Be(44773);
            cameraCrew[1].Show.LanguageCode.Should().Be("en");
            cameraCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);

            var lightingCrew = creditsCrew.Lighting.ToArray();

            lightingCrew[0].Should().NotBeNull();
            lightingCrew[0].Job.Should().Be("Light Technician 1");
            lightingCrew[0].Show.Should().NotBeNull();
            lightingCrew[0].Show.Title.Should().Be("Game of Thrones");
            lightingCrew[0].Show.Year.Should().Be(2011);
            lightingCrew[0].Show.Airs.Should().NotBeNull();
            lightingCrew[0].Show.Airs.Day.Should().Be("Sunday");
            lightingCrew[0].Show.Airs.Time.Should().Be("21:00");
            lightingCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            lightingCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            lightingCrew[0].Show.Ids.Should().NotBeNull();
            lightingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            lightingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            lightingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            lightingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            lightingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            lightingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            lightingCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            lightingCrew[0].Show.Seasons.Should().BeNull();
            lightingCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            lightingCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            lightingCrew[0].Show.Runtime.Should().Be(60);
            lightingCrew[0].Show.Certification.Should().Be("TV-MA");
            lightingCrew[0].Show.Network.Should().Be("HBO");
            lightingCrew[0].Show.CountryCode.Should().Be("us");
            lightingCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            lightingCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            lightingCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            lightingCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            lightingCrew[0].Show.Rating.Should().Be(9.38327f);
            lightingCrew[0].Show.Votes.Should().Be(44773);
            lightingCrew[0].Show.LanguageCode.Should().Be("en");
            lightingCrew[0].Show.AiredEpisodes.Should().Be(50);

            lightingCrew[1].Should().NotBeNull();
            lightingCrew[1].Job.Should().Be("Light Technician 2");
            lightingCrew[1].Show.Should().NotBeNull();
            lightingCrew[1].Show.Title.Should().Be("Game of Thrones");
            lightingCrew[1].Show.Year.Should().Be(2011);
            lightingCrew[1].Show.Airs.Should().NotBeNull();
            lightingCrew[1].Show.Airs.Day.Should().Be("Sunday");
            lightingCrew[1].Show.Airs.Time.Should().Be("21:00");
            lightingCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            lightingCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            lightingCrew[1].Show.Ids.Should().NotBeNull();
            lightingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            lightingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            lightingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            lightingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            lightingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            lightingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            lightingCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            lightingCrew[1].Show.Seasons.Should().BeNull();
            lightingCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            lightingCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            lightingCrew[1].Show.Runtime.Should().Be(60);
            lightingCrew[1].Show.Certification.Should().Be("TV-MA");
            lightingCrew[1].Show.Network.Should().Be("HBO");
            lightingCrew[1].Show.CountryCode.Should().Be("us");
            lightingCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            lightingCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            lightingCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            lightingCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            lightingCrew[1].Show.Rating.Should().Be(9.38327f);
            lightingCrew[1].Show.Votes.Should().Be(44773);
            lightingCrew[1].Show.LanguageCode.Should().Be("en");
            lightingCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);

            var vfxCrew = creditsCrew.VisualEffects.ToArray();

            vfxCrew[0].Should().NotBeNull();
            vfxCrew[0].Job.Should().Be("VFX Artist 1");
            vfxCrew[0].Show.Should().NotBeNull();
            vfxCrew[0].Show.Title.Should().Be("Game of Thrones");
            vfxCrew[0].Show.Year.Should().Be(2011);
            vfxCrew[0].Show.Airs.Should().NotBeNull();
            vfxCrew[0].Show.Airs.Day.Should().Be("Sunday");
            vfxCrew[0].Show.Airs.Time.Should().Be("21:00");
            vfxCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            vfxCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            vfxCrew[0].Show.Ids.Should().NotBeNull();
            vfxCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            vfxCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            vfxCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            vfxCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            vfxCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            vfxCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            vfxCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            vfxCrew[0].Show.Seasons.Should().BeNull();
            vfxCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            vfxCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            vfxCrew[0].Show.Runtime.Should().Be(60);
            vfxCrew[0].Show.Certification.Should().Be("TV-MA");
            vfxCrew[0].Show.Network.Should().Be("HBO");
            vfxCrew[0].Show.CountryCode.Should().Be("us");
            vfxCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            vfxCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            vfxCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            vfxCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            vfxCrew[0].Show.Rating.Should().Be(9.38327f);
            vfxCrew[0].Show.Votes.Should().Be(44773);
            vfxCrew[0].Show.LanguageCode.Should().Be("en");
            vfxCrew[0].Show.AiredEpisodes.Should().Be(50);

            vfxCrew[1].Should().NotBeNull();
            vfxCrew[1].Job.Should().Be("VFX Artist 2");
            vfxCrew[1].Show.Should().NotBeNull();
            vfxCrew[1].Show.Title.Should().Be("Game of Thrones");
            vfxCrew[1].Show.Year.Should().Be(2011);
            vfxCrew[1].Show.Airs.Should().NotBeNull();
            vfxCrew[1].Show.Airs.Day.Should().Be("Sunday");
            vfxCrew[1].Show.Airs.Time.Should().Be("21:00");
            vfxCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            vfxCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            vfxCrew[1].Show.Ids.Should().NotBeNull();
            vfxCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            vfxCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            vfxCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            vfxCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            vfxCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            vfxCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            vfxCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            vfxCrew[1].Show.Seasons.Should().BeNull();
            vfxCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            vfxCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            vfxCrew[1].Show.Runtime.Should().Be(60);
            vfxCrew[1].Show.Certification.Should().Be("TV-MA");
            vfxCrew[1].Show.Network.Should().Be("HBO");
            vfxCrew[1].Show.CountryCode.Should().Be("us");
            vfxCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            vfxCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            vfxCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            vfxCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            vfxCrew[1].Show.Rating.Should().Be(9.38327f);
            vfxCrew[1].Show.Votes.Should().Be(44773);
            vfxCrew[1].Show.LanguageCode.Should().Be("en");
            vfxCrew[1].Show.AiredEpisodes.Should().Be(50);

            creditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);

            var editingCrew = creditsCrew.Editing.ToArray();

            editingCrew[0].Should().NotBeNull();
            editingCrew[0].Job.Should().Be("Editor 1");
            editingCrew[0].Show.Should().NotBeNull();
            editingCrew[0].Show.Title.Should().Be("Game of Thrones");
            editingCrew[0].Show.Year.Should().Be(2011);
            editingCrew[0].Show.Airs.Should().NotBeNull();
            editingCrew[0].Show.Airs.Day.Should().Be("Sunday");
            editingCrew[0].Show.Airs.Time.Should().Be("21:00");
            editingCrew[0].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            editingCrew[0].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            editingCrew[0].Show.Ids.Should().NotBeNull();
            editingCrew[0].Show.Ids.Trakt.Should().Be(1390U);
            editingCrew[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            editingCrew[0].Show.Ids.Tvdb.Should().Be(121361U);
            editingCrew[0].Show.Ids.Imdb.Should().Be("tt0944947");
            editingCrew[0].Show.Ids.Tmdb.Should().Be(1399U);
            editingCrew[0].Show.Ids.TvRage.Should().Be(24493U);
            editingCrew[0].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            editingCrew[0].Show.Seasons.Should().BeNull();
            editingCrew[0].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            editingCrew[0].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            editingCrew[0].Show.Runtime.Should().Be(60);
            editingCrew[0].Show.Certification.Should().Be("TV-MA");
            editingCrew[0].Show.Network.Should().Be("HBO");
            editingCrew[0].Show.CountryCode.Should().Be("us");
            editingCrew[0].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            editingCrew[0].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            editingCrew[0].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            editingCrew[0].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            editingCrew[0].Show.Rating.Should().Be(9.38327f);
            editingCrew[0].Show.Votes.Should().Be(44773);
            editingCrew[0].Show.LanguageCode.Should().Be("en");
            editingCrew[0].Show.AiredEpisodes.Should().Be(50);

            editingCrew[1].Should().NotBeNull();
            editingCrew[1].Job.Should().Be("Editor 2");
            editingCrew[1].Show.Should().NotBeNull();
            editingCrew[1].Show.Title.Should().Be("Game of Thrones");
            editingCrew[1].Show.Year.Should().Be(2011);
            editingCrew[1].Show.Airs.Should().NotBeNull();
            editingCrew[1].Show.Airs.Day.Should().Be("Sunday");
            editingCrew[1].Show.Airs.Time.Should().Be("21:00");
            editingCrew[1].Show.Airs.TimeZoneId.Should().Be("America/New_York");
            editingCrew[1].Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            editingCrew[1].Show.Ids.Should().NotBeNull();
            editingCrew[1].Show.Ids.Trakt.Should().Be(1390U);
            editingCrew[1].Show.Ids.Slug.Should().Be("game-of-thrones");
            editingCrew[1].Show.Ids.Tvdb.Should().Be(121361U);
            editingCrew[1].Show.Ids.Imdb.Should().Be("tt0944947");
            editingCrew[1].Show.Ids.Tmdb.Should().Be(1399U);
            editingCrew[1].Show.Ids.TvRage.Should().Be(24493U);
            editingCrew[1].Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            editingCrew[1].Show.Seasons.Should().BeNull();
            editingCrew[1].Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            editingCrew[1].Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            editingCrew[1].Show.Runtime.Should().Be(60);
            editingCrew[1].Show.Certification.Should().Be("TV-MA");
            editingCrew[1].Show.Network.Should().Be("HBO");
            editingCrew[1].Show.CountryCode.Should().Be("us");
            editingCrew[1].Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            editingCrew[1].Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            editingCrew[1].Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            editingCrew[1].Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            editingCrew[1].Show.Rating.Should().Be(9.38327f);
            editingCrew[1].Show.Votes.Should().Be(44773);
            editingCrew[1].Show.LanguageCode.Should().Be("en");
            editingCrew[1].Show.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""production"": [
                  {
                    ""job"": ""Producer 1"",
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
                    ""job"": ""Producer 2"",
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
                    ""job"": ""Art Director 1"",
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
                    ""job"": ""Art Director 2"",
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
                    ""job"": ""Crew Member 1"",
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
                    ""job"": ""Crew Member 2"",
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
                    ""job"": ""Costume Designer"",
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
                    ""job"": ""Make Up Artist"",
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
                    ""job"": ""Director 1"",
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
                    ""job"": ""Director 2"",
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
                    ""job"": ""Writer 1"",
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
                    ""job"": ""Writer 2"",
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
                    ""job"": ""Sound Designer 1"",
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
                    ""job"": ""Sound Designer 2"",
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
                    ""job"": ""Camera Man 1"",
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
                    ""job"": ""Camera Man 2"",
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
                    ""job"": ""Light Technician 1"",
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
                    ""job"": ""Light Technician 2"",
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
                    ""job"": ""VFX Artist 1"",
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
                    ""job"": ""VFX Artist 2"",
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
                    ""job"": ""Editor 1"",
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
                    ""job"": ""Editor 2"",
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
              }";

        private const string FULL_JSON =
            @"{
                ""production"": [
                  {
                    ""job"": ""Producer 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Producer 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""art"": [
                  {
                    ""job"": ""Art Director 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Art Director 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""job"": ""Crew Member 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Crew Member 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""job"": ""Costume Designer"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Make Up Artist"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""job"": ""Director 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Director 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""job"": ""Writer 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Writer 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""job"": ""Sound Designer 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Sound Designer 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""job"": ""Camera Man 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Camera Man 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""job"": ""Light Technician 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Light Technician 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""job"": ""VFX Artist 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""VFX Artist 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""job"": ""Editor 1"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  },
                  {
                    ""job"": ""Editor 2"",
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
                      },
                      ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                      ""first_aired"": ""2011-04-17T07:00:00Z"",
                      ""airs"": {
                        ""day"": ""Sunday"",
                        ""time"": ""21:00"",
                        ""timezone"": ""America/New_York""
                      },
                      ""runtime"": 60,
                      ""certification"": ""TV-MA"",
                      ""network"": ""HBO"",
                      ""country"": ""us"",
                      ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                      ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                      ""status"": ""returning series"",
                      ""rating"": 9.38327,
                      ""votes"": 44773,
                      ""updated_at"": ""2016-04-06T10:39:11Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""fr"",
                        ""it"",
                        ""de""
                      ],
                      ""genres"": [
                        ""drama"",
                        ""fantasy"",
                        ""science-fiction"",
                        ""action"",
                        ""adventure""
                      ],
                      ""aired_episodes"": 50
                    }
                  }
                ]
              }";
    }
}
