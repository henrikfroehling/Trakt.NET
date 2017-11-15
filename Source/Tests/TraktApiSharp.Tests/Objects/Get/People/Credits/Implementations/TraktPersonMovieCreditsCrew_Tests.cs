namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits.Implementations;
    using TraktApiSharp.Objects.Get.People.Credits.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonMovieCreditsCrew_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCreditsCrew_Default_Constructor()
        {
            var creditsCrew = new TraktPersonMovieCreditsCrew();

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
        public async Task Test_TraktPersonMovieCreditsCrew_From_Minimal_Json()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();
            var creditsCrew = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktPersonMovieCreditsCrew;

            creditsCrew.Should().NotBeNull();
            creditsCrew.Production.Should().NotBeNull().And.HaveCount(2);

            var productionCrew = creditsCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Job.Should().Be("Producer 1");
            productionCrew[0].Movie.Should().NotBeNull();
            productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            productionCrew[0].Movie.Year.Should().Be(2015);
            productionCrew[0].Movie.Ids.Should().NotBeNull();
            productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            productionCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            productionCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            productionCrew[0].Movie.Released.Should().NotHaveValue();
            productionCrew[0].Movie.Runtime.Should().NotHaveValue();
            productionCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            productionCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            productionCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            productionCrew[0].Movie.Rating.Should().NotHaveValue();
            productionCrew[0].Movie.Votes.Should().NotHaveValue();
            productionCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            productionCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            productionCrew[0].Movie.Genres.Should().BeNull();
            productionCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            productionCrew[1].Should().NotBeNull();
            productionCrew[1].Job.Should().Be("Producer 2");
            productionCrew[1].Movie.Should().NotBeNull();
            productionCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            productionCrew[1].Movie.Year.Should().Be(2015);
            productionCrew[1].Movie.Ids.Should().NotBeNull();
            productionCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            productionCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            productionCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            productionCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            productionCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            productionCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            productionCrew[1].Movie.Released.Should().NotHaveValue();
            productionCrew[1].Movie.Runtime.Should().NotHaveValue();
            productionCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            productionCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            productionCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            productionCrew[1].Movie.Rating.Should().NotHaveValue();
            productionCrew[1].Movie.Votes.Should().NotHaveValue();
            productionCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            productionCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            productionCrew[1].Movie.Genres.Should().BeNull();
            productionCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Art.Should().NotBeNull().And.HaveCount(2);

            var artCrew = creditsCrew.Art.ToArray();

            artCrew[0].Should().NotBeNull();
            artCrew[0].Job.Should().Be("Art Director 1");
            artCrew[0].Movie.Should().NotBeNull();
            artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            artCrew[0].Movie.Year.Should().Be(2015);
            artCrew[0].Movie.Ids.Should().NotBeNull();
            artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            artCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            artCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            artCrew[0].Movie.Released.Should().NotHaveValue();
            artCrew[0].Movie.Runtime.Should().NotHaveValue();
            artCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            artCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            artCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            artCrew[0].Movie.Rating.Should().NotHaveValue();
            artCrew[0].Movie.Votes.Should().NotHaveValue();
            artCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            artCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            artCrew[0].Movie.Genres.Should().BeNull();
            artCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            artCrew[1].Should().NotBeNull();
            artCrew[1].Job.Should().Be("Art Director 2");
            artCrew[1].Movie.Should().NotBeNull();
            artCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            artCrew[1].Movie.Year.Should().Be(2015);
            artCrew[1].Movie.Ids.Should().NotBeNull();
            artCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            artCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            artCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            artCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            artCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            artCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            artCrew[1].Movie.Released.Should().NotHaveValue();
            artCrew[1].Movie.Runtime.Should().NotHaveValue();
            artCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            artCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            artCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            artCrew[1].Movie.Rating.Should().NotHaveValue();
            artCrew[1].Movie.Votes.Should().NotHaveValue();
            artCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            artCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            artCrew[1].Movie.Genres.Should().BeNull();
            artCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);

            var crew = creditsCrew.Crew.ToArray();

            crew[0].Should().NotBeNull();
            crew[0].Job.Should().Be("Crew Member 1");
            crew[0].Movie.Should().NotBeNull();
            crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            crew[0].Movie.Year.Should().Be(2015);
            crew[0].Movie.Ids.Should().NotBeNull();
            crew[0].Movie.Ids.Trakt.Should().Be(94024U);
            crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            crew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            crew[0].Movie.Tagline.Should().BeNullOrEmpty();
            crew[0].Movie.Overview.Should().BeNullOrEmpty();
            crew[0].Movie.Released.Should().NotHaveValue();
            crew[0].Movie.Runtime.Should().NotHaveValue();
            crew[0].Movie.UpdatedAt.Should().NotHaveValue();
            crew[0].Movie.Trailer.Should().BeNullOrEmpty();
            crew[0].Movie.Homepage.Should().BeNullOrEmpty();
            crew[0].Movie.Rating.Should().NotHaveValue();
            crew[0].Movie.Votes.Should().NotHaveValue();
            crew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            crew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            crew[0].Movie.Genres.Should().BeNull();
            crew[0].Movie.Certification.Should().BeNullOrEmpty();

            crew[1].Should().NotBeNull();
            crew[1].Job.Should().Be("Crew Member 2");
            crew[1].Movie.Should().NotBeNull();
            crew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            crew[1].Movie.Year.Should().Be(2015);
            crew[1].Movie.Ids.Should().NotBeNull();
            crew[1].Movie.Ids.Trakt.Should().Be(94024U);
            crew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            crew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            crew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            crew[1].Movie.Tagline.Should().BeNullOrEmpty();
            crew[1].Movie.Overview.Should().BeNullOrEmpty();
            crew[1].Movie.Released.Should().NotHaveValue();
            crew[1].Movie.Runtime.Should().NotHaveValue();
            crew[1].Movie.UpdatedAt.Should().NotHaveValue();
            crew[1].Movie.Trailer.Should().BeNullOrEmpty();
            crew[1].Movie.Homepage.Should().BeNullOrEmpty();
            crew[1].Movie.Rating.Should().NotHaveValue();
            crew[1].Movie.Votes.Should().NotHaveValue();
            crew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            crew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            crew[1].Movie.Genres.Should().BeNull();
            crew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);

            var costumeAndMakeupCrew = creditsCrew.CostumeAndMakeup.ToArray();

            costumeAndMakeupCrew[0].Should().NotBeNull();
            costumeAndMakeupCrew[0].Job.Should().Be("Costume Designer");
            costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
            costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
            costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            costumeAndMakeupCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie.Released.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Movie.Runtime.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie.Rating.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Movie.Votes.Should().NotHaveValue();
            costumeAndMakeupCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            costumeAndMakeupCrew[0].Movie.Genres.Should().BeNull();
            costumeAndMakeupCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            costumeAndMakeupCrew[1].Should().NotBeNull();
            costumeAndMakeupCrew[1].Job.Should().Be("Make Up Artist");
            costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
            costumeAndMakeupCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            costumeAndMakeupCrew[1].Movie.Year.Should().Be(2015);
            costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            costumeAndMakeupCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie.Released.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Movie.Runtime.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie.Rating.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Movie.Votes.Should().NotHaveValue();
            costumeAndMakeupCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            costumeAndMakeupCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            costumeAndMakeupCrew[1].Movie.Genres.Should().BeNull();
            costumeAndMakeupCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);

            var directingCrew = creditsCrew.Directing.ToArray();

            directingCrew[0].Should().NotBeNull();
            directingCrew[0].Job.Should().Be("Director 1");
            directingCrew[0].Movie.Should().NotBeNull();
            directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            directingCrew[0].Movie.Year.Should().Be(2015);
            directingCrew[0].Movie.Ids.Should().NotBeNull();
            directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            directingCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            directingCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            directingCrew[0].Movie.Released.Should().NotHaveValue();
            directingCrew[0].Movie.Runtime.Should().NotHaveValue();
            directingCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            directingCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            directingCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            directingCrew[0].Movie.Rating.Should().NotHaveValue();
            directingCrew[0].Movie.Votes.Should().NotHaveValue();
            directingCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            directingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            directingCrew[0].Movie.Genres.Should().BeNull();
            directingCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            directingCrew[1].Should().NotBeNull();
            directingCrew[1].Job.Should().Be("Director 2");
            directingCrew[1].Movie.Should().NotBeNull();
            directingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            directingCrew[1].Movie.Year.Should().Be(2015);
            directingCrew[1].Movie.Ids.Should().NotBeNull();
            directingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            directingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            directingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            directingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            directingCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            directingCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            directingCrew[1].Movie.Released.Should().NotHaveValue();
            directingCrew[1].Movie.Runtime.Should().NotHaveValue();
            directingCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            directingCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            directingCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            directingCrew[1].Movie.Rating.Should().NotHaveValue();
            directingCrew[1].Movie.Votes.Should().NotHaveValue();
            directingCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            directingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            directingCrew[1].Movie.Genres.Should().BeNull();
            directingCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);

            var writingCrew = creditsCrew.Writing.ToArray();

            writingCrew[0].Should().NotBeNull();
            writingCrew[0].Job.Should().Be("Writer 1");
            writingCrew[0].Movie.Should().NotBeNull();
            writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            writingCrew[0].Movie.Year.Should().Be(2015);
            writingCrew[0].Movie.Ids.Should().NotBeNull();
            writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            writingCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            writingCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            writingCrew[0].Movie.Released.Should().NotHaveValue();
            writingCrew[0].Movie.Runtime.Should().NotHaveValue();
            writingCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            writingCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            writingCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            writingCrew[0].Movie.Rating.Should().NotHaveValue();
            writingCrew[0].Movie.Votes.Should().NotHaveValue();
            writingCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            writingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            writingCrew[0].Movie.Genres.Should().BeNull();
            writingCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            writingCrew[1].Should().NotBeNull();
            writingCrew[1].Job.Should().Be("Writer 2");
            writingCrew[1].Movie.Should().NotBeNull();
            writingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            writingCrew[1].Movie.Year.Should().Be(2015);
            writingCrew[1].Movie.Ids.Should().NotBeNull();
            writingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            writingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            writingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            writingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            writingCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            writingCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            writingCrew[1].Movie.Released.Should().NotHaveValue();
            writingCrew[1].Movie.Runtime.Should().NotHaveValue();
            writingCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            writingCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            writingCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            writingCrew[1].Movie.Rating.Should().NotHaveValue();
            writingCrew[1].Movie.Votes.Should().NotHaveValue();
            writingCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            writingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            writingCrew[1].Movie.Genres.Should().BeNull();
            writingCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);

            var soundCrew = creditsCrew.Sound.ToArray();

            soundCrew[0].Should().NotBeNull();
            soundCrew[0].Job.Should().Be("Sound Designer 1");
            soundCrew[0].Movie.Should().NotBeNull();
            soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            soundCrew[0].Movie.Year.Should().Be(2015);
            soundCrew[0].Movie.Ids.Should().NotBeNull();
            soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            soundCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            soundCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            soundCrew[0].Movie.Released.Should().NotHaveValue();
            soundCrew[0].Movie.Runtime.Should().NotHaveValue();
            soundCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            soundCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            soundCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            soundCrew[0].Movie.Rating.Should().NotHaveValue();
            soundCrew[0].Movie.Votes.Should().NotHaveValue();
            soundCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            soundCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            soundCrew[0].Movie.Genres.Should().BeNull();
            soundCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            soundCrew[1].Should().NotBeNull();
            soundCrew[1].Job.Should().Be("Sound Designer 2");
            soundCrew[1].Movie.Should().NotBeNull();
            soundCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            soundCrew[1].Movie.Year.Should().Be(2015);
            soundCrew[1].Movie.Ids.Should().NotBeNull();
            soundCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            soundCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            soundCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            soundCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            soundCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            soundCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            soundCrew[1].Movie.Released.Should().NotHaveValue();
            soundCrew[1].Movie.Runtime.Should().NotHaveValue();
            soundCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            soundCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            soundCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            soundCrew[1].Movie.Rating.Should().NotHaveValue();
            soundCrew[1].Movie.Votes.Should().NotHaveValue();
            soundCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            soundCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            soundCrew[1].Movie.Genres.Should().BeNull();
            soundCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);

            var cameraCrew = creditsCrew.Camera.ToArray();

            cameraCrew[0].Should().NotBeNull();
            cameraCrew[0].Job.Should().Be("Camera Man 1");
            cameraCrew[0].Movie.Should().NotBeNull();
            cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            cameraCrew[0].Movie.Year.Should().Be(2015);
            cameraCrew[0].Movie.Ids.Should().NotBeNull();
            cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            cameraCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            cameraCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            cameraCrew[0].Movie.Released.Should().NotHaveValue();
            cameraCrew[0].Movie.Runtime.Should().NotHaveValue();
            cameraCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            cameraCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            cameraCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            cameraCrew[0].Movie.Rating.Should().NotHaveValue();
            cameraCrew[0].Movie.Votes.Should().NotHaveValue();
            cameraCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            cameraCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            cameraCrew[0].Movie.Genres.Should().BeNull();
            cameraCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            cameraCrew[1].Should().NotBeNull();
            cameraCrew[1].Job.Should().Be("Camera Man 2");
            cameraCrew[1].Movie.Should().NotBeNull();
            cameraCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            cameraCrew[1].Movie.Year.Should().Be(2015);
            cameraCrew[1].Movie.Ids.Should().NotBeNull();
            cameraCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            cameraCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            cameraCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            cameraCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            cameraCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            cameraCrew[1].Movie.Released.Should().NotHaveValue();
            cameraCrew[1].Movie.Runtime.Should().NotHaveValue();
            cameraCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            cameraCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            cameraCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            cameraCrew[1].Movie.Rating.Should().NotHaveValue();
            cameraCrew[1].Movie.Votes.Should().NotHaveValue();
            cameraCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            cameraCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            cameraCrew[1].Movie.Genres.Should().BeNull();
            cameraCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);

            var lightingCrew = creditsCrew.Lighting.ToArray();

            lightingCrew[0].Should().NotBeNull();
            lightingCrew[0].Job.Should().Be("Light Technician 1");
            lightingCrew[0].Movie.Should().NotBeNull();
            lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            lightingCrew[0].Movie.Year.Should().Be(2015);
            lightingCrew[0].Movie.Ids.Should().NotBeNull();
            lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            lightingCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            lightingCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            lightingCrew[0].Movie.Released.Should().NotHaveValue();
            lightingCrew[0].Movie.Runtime.Should().NotHaveValue();
            lightingCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            lightingCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            lightingCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            lightingCrew[0].Movie.Rating.Should().NotHaveValue();
            lightingCrew[0].Movie.Votes.Should().NotHaveValue();
            lightingCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            lightingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            lightingCrew[0].Movie.Genres.Should().BeNull();
            lightingCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            lightingCrew[1].Should().NotBeNull();
            lightingCrew[1].Job.Should().Be("Light Technician 2");
            lightingCrew[1].Movie.Should().NotBeNull();
            lightingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            lightingCrew[1].Movie.Year.Should().Be(2015);
            lightingCrew[1].Movie.Ids.Should().NotBeNull();
            lightingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            lightingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            lightingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            lightingCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            lightingCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            lightingCrew[1].Movie.Released.Should().NotHaveValue();
            lightingCrew[1].Movie.Runtime.Should().NotHaveValue();
            lightingCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            lightingCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            lightingCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            lightingCrew[1].Movie.Rating.Should().NotHaveValue();
            lightingCrew[1].Movie.Votes.Should().NotHaveValue();
            lightingCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            lightingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            lightingCrew[1].Movie.Genres.Should().BeNull();
            lightingCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);

            var vfxCrew = creditsCrew.VisualEffects.ToArray();

            vfxCrew[0].Should().NotBeNull();
            vfxCrew[0].Job.Should().Be("VFX Artist 1");
            vfxCrew[0].Movie.Should().NotBeNull();
            vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            vfxCrew[0].Movie.Year.Should().Be(2015);
            vfxCrew[0].Movie.Ids.Should().NotBeNull();
            vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            vfxCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            vfxCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            vfxCrew[0].Movie.Released.Should().NotHaveValue();
            vfxCrew[0].Movie.Runtime.Should().NotHaveValue();
            vfxCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            vfxCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            vfxCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            vfxCrew[0].Movie.Rating.Should().NotHaveValue();
            vfxCrew[0].Movie.Votes.Should().NotHaveValue();
            vfxCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            vfxCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            vfxCrew[0].Movie.Genres.Should().BeNull();
            vfxCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            vfxCrew[1].Should().NotBeNull();
            vfxCrew[1].Job.Should().Be("VFX Artist 2");
            vfxCrew[1].Movie.Should().NotBeNull();
            vfxCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            vfxCrew[1].Movie.Year.Should().Be(2015);
            vfxCrew[1].Movie.Ids.Should().NotBeNull();
            vfxCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            vfxCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            vfxCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            vfxCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            vfxCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            vfxCrew[1].Movie.Released.Should().NotHaveValue();
            vfxCrew[1].Movie.Runtime.Should().NotHaveValue();
            vfxCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            vfxCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            vfxCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            vfxCrew[1].Movie.Rating.Should().NotHaveValue();
            vfxCrew[1].Movie.Votes.Should().NotHaveValue();
            vfxCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            vfxCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            vfxCrew[1].Movie.Genres.Should().BeNull();
            vfxCrew[1].Movie.Certification.Should().BeNullOrEmpty();

            creditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);

            var editingCrew = creditsCrew.Editing.ToArray();

            editingCrew[0].Should().NotBeNull();
            editingCrew[0].Job.Should().Be("Editor 1");
            editingCrew[0].Movie.Should().NotBeNull();
            editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            editingCrew[0].Movie.Year.Should().Be(2015);
            editingCrew[0].Movie.Ids.Should().NotBeNull();
            editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            editingCrew[0].Movie.Tagline.Should().BeNullOrEmpty();
            editingCrew[0].Movie.Overview.Should().BeNullOrEmpty();
            editingCrew[0].Movie.Released.Should().NotHaveValue();
            editingCrew[0].Movie.Runtime.Should().NotHaveValue();
            editingCrew[0].Movie.UpdatedAt.Should().NotHaveValue();
            editingCrew[0].Movie.Trailer.Should().BeNullOrEmpty();
            editingCrew[0].Movie.Homepage.Should().BeNullOrEmpty();
            editingCrew[0].Movie.Rating.Should().NotHaveValue();
            editingCrew[0].Movie.Votes.Should().NotHaveValue();
            editingCrew[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            editingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            editingCrew[0].Movie.Genres.Should().BeNull();
            editingCrew[0].Movie.Certification.Should().BeNullOrEmpty();

            editingCrew[1].Should().NotBeNull();
            editingCrew[1].Job.Should().Be("Editor 2");
            editingCrew[1].Movie.Should().NotBeNull();
            editingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            editingCrew[1].Movie.Year.Should().Be(2015);
            editingCrew[1].Movie.Ids.Should().NotBeNull();
            editingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            editingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            editingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            editingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            editingCrew[1].Movie.Tagline.Should().BeNullOrEmpty();
            editingCrew[1].Movie.Overview.Should().BeNullOrEmpty();
            editingCrew[1].Movie.Released.Should().NotHaveValue();
            editingCrew[1].Movie.Runtime.Should().NotHaveValue();
            editingCrew[1].Movie.UpdatedAt.Should().NotHaveValue();
            editingCrew[1].Movie.Trailer.Should().BeNullOrEmpty();
            editingCrew[1].Movie.Homepage.Should().BeNullOrEmpty();
            editingCrew[1].Movie.Rating.Should().NotHaveValue();
            editingCrew[1].Movie.Votes.Should().NotHaveValue();
            editingCrew[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            editingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            editingCrew[1].Movie.Genres.Should().BeNull();
            editingCrew[1].Movie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktPersonMovieCreditsCrew_From_Full_Json()
        {
            var jsonReader = new PersonMovieCreditsCrewObjectJsonReader();
            var creditsCrew = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktPersonMovieCreditsCrew;

            creditsCrew.Should().NotBeNull();
            creditsCrew.Production.Should().NotBeNull().And.HaveCount(2);

            var productionCrew = creditsCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Job.Should().Be("Producer 1");
            productionCrew[0].Movie.Should().NotBeNull();
            productionCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            productionCrew[0].Movie.Year.Should().Be(2015);
            productionCrew[0].Movie.Ids.Should().NotBeNull();
            productionCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            productionCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            productionCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            productionCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            productionCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            productionCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            productionCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            productionCrew[0].Movie.Runtime.Should().Be(136);
            productionCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            productionCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            productionCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            productionCrew[0].Movie.Rating.Should().Be(8.31988f);
            productionCrew[0].Movie.Votes.Should().Be(9338);
            productionCrew[0].Movie.LanguageCode.Should().Be("en");
            productionCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            productionCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            productionCrew[0].Movie.Certification.Should().Be("PG-13");

            productionCrew[1].Should().NotBeNull();
            productionCrew[1].Job.Should().Be("Producer 2");
            productionCrew[1].Movie.Should().NotBeNull();
            productionCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            productionCrew[1].Movie.Year.Should().Be(2015);
            productionCrew[1].Movie.Ids.Should().NotBeNull();
            productionCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            productionCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            productionCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            productionCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            productionCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            productionCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            productionCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            productionCrew[1].Movie.Runtime.Should().Be(136);
            productionCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            productionCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            productionCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            productionCrew[1].Movie.Rating.Should().Be(8.31988f);
            productionCrew[1].Movie.Votes.Should().Be(9338);
            productionCrew[1].Movie.LanguageCode.Should().Be("en");
            productionCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            productionCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            productionCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Art.Should().NotBeNull().And.HaveCount(2);

            var artCrew = creditsCrew.Art.ToArray();

            artCrew[0].Should().NotBeNull();
            artCrew[0].Job.Should().Be("Art Director 1");
            artCrew[0].Movie.Should().NotBeNull();
            artCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            artCrew[0].Movie.Year.Should().Be(2015);
            artCrew[0].Movie.Ids.Should().NotBeNull();
            artCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            artCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            artCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            artCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            artCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            artCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            artCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            artCrew[0].Movie.Runtime.Should().Be(136);
            artCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            artCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            artCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            artCrew[0].Movie.Rating.Should().Be(8.31988f);
            artCrew[0].Movie.Votes.Should().Be(9338);
            artCrew[0].Movie.LanguageCode.Should().Be("en");
            artCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            artCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            artCrew[0].Movie.Certification.Should().Be("PG-13");

            artCrew[1].Should().NotBeNull();
            artCrew[1].Job.Should().Be("Art Director 2");
            artCrew[1].Movie.Should().NotBeNull();
            artCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            artCrew[1].Movie.Year.Should().Be(2015);
            artCrew[1].Movie.Ids.Should().NotBeNull();
            artCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            artCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            artCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            artCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            artCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            artCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            artCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            artCrew[1].Movie.Runtime.Should().Be(136);
            artCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            artCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            artCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            artCrew[1].Movie.Rating.Should().Be(8.31988f);
            artCrew[1].Movie.Votes.Should().Be(9338);
            artCrew[1].Movie.LanguageCode.Should().Be("en");
            artCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            artCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            artCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Crew.Should().NotBeNull().And.HaveCount(2);

            var crew = creditsCrew.Crew.ToArray();

            crew[0].Should().NotBeNull();
            crew[0].Job.Should().Be("Crew Member 1");
            crew[0].Movie.Should().NotBeNull();
            crew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            crew[0].Movie.Year.Should().Be(2015);
            crew[0].Movie.Ids.Should().NotBeNull();
            crew[0].Movie.Ids.Trakt.Should().Be(94024U);
            crew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            crew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            crew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            crew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            crew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            crew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            crew[0].Movie.Runtime.Should().Be(136);
            crew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            crew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            crew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            crew[0].Movie.Rating.Should().Be(8.31988f);
            crew[0].Movie.Votes.Should().Be(9338);
            crew[0].Movie.LanguageCode.Should().Be("en");
            crew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            crew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            crew[0].Movie.Certification.Should().Be("PG-13");

            crew[1].Should().NotBeNull();
            crew[1].Job.Should().Be("Crew Member 2");
            crew[1].Movie.Should().NotBeNull();
            crew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            crew[1].Movie.Year.Should().Be(2015);
            crew[1].Movie.Ids.Should().NotBeNull();
            crew[1].Movie.Ids.Trakt.Should().Be(94024U);
            crew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            crew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            crew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            crew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            crew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            crew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            crew[1].Movie.Runtime.Should().Be(136);
            crew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            crew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            crew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            crew[1].Movie.Rating.Should().Be(8.31988f);
            crew[1].Movie.Votes.Should().Be(9338);
            crew[1].Movie.LanguageCode.Should().Be("en");
            crew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            crew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            crew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);

            var costumeAndMakeupCrew = creditsCrew.CostumeAndMakeup.ToArray();

            costumeAndMakeupCrew[0].Should().NotBeNull();
            costumeAndMakeupCrew[0].Job.Should().Be("Costume Designer");
            costumeAndMakeupCrew[0].Movie.Should().NotBeNull();
            costumeAndMakeupCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            costumeAndMakeupCrew[0].Movie.Year.Should().Be(2015);
            costumeAndMakeupCrew[0].Movie.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            costumeAndMakeupCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            costumeAndMakeupCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            costumeAndMakeupCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            costumeAndMakeupCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            costumeAndMakeupCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            costumeAndMakeupCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            costumeAndMakeupCrew[0].Movie.Runtime.Should().Be(136);
            costumeAndMakeupCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            costumeAndMakeupCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            costumeAndMakeupCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            costumeAndMakeupCrew[0].Movie.Rating.Should().Be(8.31988f);
            costumeAndMakeupCrew[0].Movie.Votes.Should().Be(9338);
            costumeAndMakeupCrew[0].Movie.LanguageCode.Should().Be("en");
            costumeAndMakeupCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            costumeAndMakeupCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            costumeAndMakeupCrew[0].Movie.Certification.Should().Be("PG-13");

            costumeAndMakeupCrew[1].Should().NotBeNull();
            costumeAndMakeupCrew[1].Job.Should().Be("Make Up Artist");
            costumeAndMakeupCrew[1].Movie.Should().NotBeNull();
            costumeAndMakeupCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            costumeAndMakeupCrew[1].Movie.Year.Should().Be(2015);
            costumeAndMakeupCrew[1].Movie.Ids.Should().NotBeNull();
            costumeAndMakeupCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            costumeAndMakeupCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            costumeAndMakeupCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            costumeAndMakeupCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            costumeAndMakeupCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            costumeAndMakeupCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            costumeAndMakeupCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            costumeAndMakeupCrew[1].Movie.Runtime.Should().Be(136);
            costumeAndMakeupCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            costumeAndMakeupCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            costumeAndMakeupCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            costumeAndMakeupCrew[1].Movie.Rating.Should().Be(8.31988f);
            costumeAndMakeupCrew[1].Movie.Votes.Should().Be(9338);
            costumeAndMakeupCrew[1].Movie.LanguageCode.Should().Be("en");
            costumeAndMakeupCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            costumeAndMakeupCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            costumeAndMakeupCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Directing.Should().NotBeNull().And.HaveCount(2);

            var directingCrew = creditsCrew.Directing.ToArray();

            directingCrew[0].Should().NotBeNull();
            directingCrew[0].Job.Should().Be("Director 1");
            directingCrew[0].Movie.Should().NotBeNull();
            directingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            directingCrew[0].Movie.Year.Should().Be(2015);
            directingCrew[0].Movie.Ids.Should().NotBeNull();
            directingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            directingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            directingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            directingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            directingCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            directingCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            directingCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            directingCrew[0].Movie.Runtime.Should().Be(136);
            directingCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            directingCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            directingCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            directingCrew[0].Movie.Rating.Should().Be(8.31988f);
            directingCrew[0].Movie.Votes.Should().Be(9338);
            directingCrew[0].Movie.LanguageCode.Should().Be("en");
            directingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            directingCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            directingCrew[0].Movie.Certification.Should().Be("PG-13");

            directingCrew[1].Should().NotBeNull();
            directingCrew[1].Job.Should().Be("Director 2");
            directingCrew[1].Movie.Should().NotBeNull();
            directingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            directingCrew[1].Movie.Year.Should().Be(2015);
            directingCrew[1].Movie.Ids.Should().NotBeNull();
            directingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            directingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            directingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            directingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            directingCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            directingCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            directingCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            directingCrew[1].Movie.Runtime.Should().Be(136);
            directingCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            directingCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            directingCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            directingCrew[1].Movie.Rating.Should().Be(8.31988f);
            directingCrew[1].Movie.Votes.Should().Be(9338);
            directingCrew[1].Movie.LanguageCode.Should().Be("en");
            directingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            directingCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            directingCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Writing.Should().NotBeNull().And.HaveCount(2);

            var writingCrew = creditsCrew.Writing.ToArray();

            writingCrew[0].Should().NotBeNull();
            writingCrew[0].Job.Should().Be("Writer 1");
            writingCrew[0].Movie.Should().NotBeNull();
            writingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            writingCrew[0].Movie.Year.Should().Be(2015);
            writingCrew[0].Movie.Ids.Should().NotBeNull();
            writingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            writingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            writingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            writingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            writingCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            writingCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            writingCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            writingCrew[0].Movie.Runtime.Should().Be(136);
            writingCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            writingCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            writingCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            writingCrew[0].Movie.Rating.Should().Be(8.31988f);
            writingCrew[0].Movie.Votes.Should().Be(9338);
            writingCrew[0].Movie.LanguageCode.Should().Be("en");
            writingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            writingCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            writingCrew[0].Movie.Certification.Should().Be("PG-13");

            writingCrew[1].Should().NotBeNull();
            writingCrew[1].Job.Should().Be("Writer 2");
            writingCrew[1].Movie.Should().NotBeNull();
            writingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            writingCrew[1].Movie.Year.Should().Be(2015);
            writingCrew[1].Movie.Ids.Should().NotBeNull();
            writingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            writingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            writingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            writingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            writingCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            writingCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            writingCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            writingCrew[1].Movie.Runtime.Should().Be(136);
            writingCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            writingCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            writingCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            writingCrew[1].Movie.Rating.Should().Be(8.31988f);
            writingCrew[1].Movie.Votes.Should().Be(9338);
            writingCrew[1].Movie.LanguageCode.Should().Be("en");
            writingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            writingCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            writingCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Sound.Should().NotBeNull().And.HaveCount(2);

            var soundCrew = creditsCrew.Sound.ToArray();

            soundCrew[0].Should().NotBeNull();
            soundCrew[0].Job.Should().Be("Sound Designer 1");
            soundCrew[0].Movie.Should().NotBeNull();
            soundCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            soundCrew[0].Movie.Year.Should().Be(2015);
            soundCrew[0].Movie.Ids.Should().NotBeNull();
            soundCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            soundCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            soundCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            soundCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            soundCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            soundCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            soundCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            soundCrew[0].Movie.Runtime.Should().Be(136);
            soundCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            soundCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            soundCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            soundCrew[0].Movie.Rating.Should().Be(8.31988f);
            soundCrew[0].Movie.Votes.Should().Be(9338);
            soundCrew[0].Movie.LanguageCode.Should().Be("en");
            soundCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            soundCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            soundCrew[0].Movie.Certification.Should().Be("PG-13");

            soundCrew[1].Should().NotBeNull();
            soundCrew[1].Job.Should().Be("Sound Designer 2");
            soundCrew[1].Movie.Should().NotBeNull();
            soundCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            soundCrew[1].Movie.Year.Should().Be(2015);
            soundCrew[1].Movie.Ids.Should().NotBeNull();
            soundCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            soundCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            soundCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            soundCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            soundCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            soundCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            soundCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            soundCrew[1].Movie.Runtime.Should().Be(136);
            soundCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            soundCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            soundCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            soundCrew[1].Movie.Rating.Should().Be(8.31988f);
            soundCrew[1].Movie.Votes.Should().Be(9338);
            soundCrew[1].Movie.LanguageCode.Should().Be("en");
            soundCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            soundCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            soundCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Camera.Should().NotBeNull().And.HaveCount(2);

            var cameraCrew = creditsCrew.Camera.ToArray();

            cameraCrew[0].Should().NotBeNull();
            cameraCrew[0].Job.Should().Be("Camera Man 1");
            cameraCrew[0].Movie.Should().NotBeNull();
            cameraCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            cameraCrew[0].Movie.Year.Should().Be(2015);
            cameraCrew[0].Movie.Ids.Should().NotBeNull();
            cameraCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            cameraCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            cameraCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            cameraCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            cameraCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            cameraCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            cameraCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            cameraCrew[0].Movie.Runtime.Should().Be(136);
            cameraCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            cameraCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            cameraCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            cameraCrew[0].Movie.Rating.Should().Be(8.31988f);
            cameraCrew[0].Movie.Votes.Should().Be(9338);
            cameraCrew[0].Movie.LanguageCode.Should().Be("en");
            cameraCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            cameraCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            cameraCrew[0].Movie.Certification.Should().Be("PG-13");

            cameraCrew[1].Should().NotBeNull();
            cameraCrew[1].Job.Should().Be("Camera Man 2");
            cameraCrew[1].Movie.Should().NotBeNull();
            cameraCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            cameraCrew[1].Movie.Year.Should().Be(2015);
            cameraCrew[1].Movie.Ids.Should().NotBeNull();
            cameraCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            cameraCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            cameraCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            cameraCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            cameraCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            cameraCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            cameraCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            cameraCrew[1].Movie.Runtime.Should().Be(136);
            cameraCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            cameraCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            cameraCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            cameraCrew[1].Movie.Rating.Should().Be(8.31988f);
            cameraCrew[1].Movie.Votes.Should().Be(9338);
            cameraCrew[1].Movie.LanguageCode.Should().Be("en");
            cameraCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            cameraCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            cameraCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Lighting.Should().NotBeNull().And.HaveCount(2);

            var lightingCrew = creditsCrew.Lighting.ToArray();

            lightingCrew[0].Should().NotBeNull();
            lightingCrew[0].Job.Should().Be("Light Technician 1");
            lightingCrew[0].Movie.Should().NotBeNull();
            lightingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            lightingCrew[0].Movie.Year.Should().Be(2015);
            lightingCrew[0].Movie.Ids.Should().NotBeNull();
            lightingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            lightingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            lightingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            lightingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            lightingCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            lightingCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            lightingCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            lightingCrew[0].Movie.Runtime.Should().Be(136);
            lightingCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            lightingCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            lightingCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            lightingCrew[0].Movie.Rating.Should().Be(8.31988f);
            lightingCrew[0].Movie.Votes.Should().Be(9338);
            lightingCrew[0].Movie.LanguageCode.Should().Be("en");
            lightingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            lightingCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            lightingCrew[0].Movie.Certification.Should().Be("PG-13");

            lightingCrew[1].Should().NotBeNull();
            lightingCrew[1].Job.Should().Be("Light Technician 2");
            lightingCrew[1].Movie.Should().NotBeNull();
            lightingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            lightingCrew[1].Movie.Year.Should().Be(2015);
            lightingCrew[1].Movie.Ids.Should().NotBeNull();
            lightingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            lightingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            lightingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            lightingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            lightingCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            lightingCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            lightingCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            lightingCrew[1].Movie.Runtime.Should().Be(136);
            lightingCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            lightingCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            lightingCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            lightingCrew[1].Movie.Rating.Should().Be(8.31988f);
            lightingCrew[1].Movie.Votes.Should().Be(9338);
            lightingCrew[1].Movie.LanguageCode.Should().Be("en");
            lightingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            lightingCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            lightingCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);

            var vfxCrew = creditsCrew.VisualEffects.ToArray();

            vfxCrew[0].Should().NotBeNull();
            vfxCrew[0].Job.Should().Be("VFX Artist 1");
            vfxCrew[0].Movie.Should().NotBeNull();
            vfxCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            vfxCrew[0].Movie.Year.Should().Be(2015);
            vfxCrew[0].Movie.Ids.Should().NotBeNull();
            vfxCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            vfxCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            vfxCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            vfxCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            vfxCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            vfxCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            vfxCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            vfxCrew[0].Movie.Runtime.Should().Be(136);
            vfxCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            vfxCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            vfxCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            vfxCrew[0].Movie.Rating.Should().Be(8.31988f);
            vfxCrew[0].Movie.Votes.Should().Be(9338);
            vfxCrew[0].Movie.LanguageCode.Should().Be("en");
            vfxCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            vfxCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            vfxCrew[0].Movie.Certification.Should().Be("PG-13");

            vfxCrew[1].Should().NotBeNull();
            vfxCrew[1].Job.Should().Be("VFX Artist 2");
            vfxCrew[1].Movie.Should().NotBeNull();
            vfxCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            vfxCrew[1].Movie.Year.Should().Be(2015);
            vfxCrew[1].Movie.Ids.Should().NotBeNull();
            vfxCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            vfxCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            vfxCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            vfxCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            vfxCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            vfxCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            vfxCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            vfxCrew[1].Movie.Runtime.Should().Be(136);
            vfxCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            vfxCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            vfxCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            vfxCrew[1].Movie.Rating.Should().Be(8.31988f);
            vfxCrew[1].Movie.Votes.Should().Be(9338);
            vfxCrew[1].Movie.LanguageCode.Should().Be("en");
            vfxCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            vfxCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            vfxCrew[1].Movie.Certification.Should().Be("PG-13");

            creditsCrew.Editing.Should().NotBeNull().And.HaveCount(2);

            var editingCrew = creditsCrew.Editing.ToArray();

            editingCrew[0].Should().NotBeNull();
            editingCrew[0].Job.Should().Be("Editor 1");
            editingCrew[0].Movie.Should().NotBeNull();
            editingCrew[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            editingCrew[0].Movie.Year.Should().Be(2015);
            editingCrew[0].Movie.Ids.Should().NotBeNull();
            editingCrew[0].Movie.Ids.Trakt.Should().Be(94024U);
            editingCrew[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            editingCrew[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            editingCrew[0].Movie.Ids.Tmdb.Should().Be(140607U);
            editingCrew[0].Movie.Tagline.Should().Be("Every generation has a story.");
            editingCrew[0].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            editingCrew[0].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            editingCrew[0].Movie.Runtime.Should().Be(136);
            editingCrew[0].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            editingCrew[0].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            editingCrew[0].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            editingCrew[0].Movie.Rating.Should().Be(8.31988f);
            editingCrew[0].Movie.Votes.Should().Be(9338);
            editingCrew[0].Movie.LanguageCode.Should().Be("en");
            editingCrew[0].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            editingCrew[0].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            editingCrew[0].Movie.Certification.Should().Be("PG-13");

            editingCrew[1].Should().NotBeNull();
            editingCrew[1].Job.Should().Be("Editor 2");
            editingCrew[1].Movie.Should().NotBeNull();
            editingCrew[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            editingCrew[1].Movie.Year.Should().Be(2015);
            editingCrew[1].Movie.Ids.Should().NotBeNull();
            editingCrew[1].Movie.Ids.Trakt.Should().Be(94024U);
            editingCrew[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            editingCrew[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            editingCrew[1].Movie.Ids.Tmdb.Should().Be(140607U);
            editingCrew[1].Movie.Tagline.Should().Be("Every generation has a story.");
            editingCrew[1].Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            editingCrew[1].Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            editingCrew[1].Movie.Runtime.Should().Be(136);
            editingCrew[1].Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            editingCrew[1].Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            editingCrew[1].Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            editingCrew[1].Movie.Rating.Should().Be(8.31988f);
            editingCrew[1].Movie.Votes.Should().Be(9338);
            editingCrew[1].Movie.LanguageCode.Should().Be("en");
            editingCrew[1].Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            editingCrew[1].Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            editingCrew[1].Movie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""production"": [
                  {
                    ""job"": ""Producer 1"",
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
                  },
                  {
                    ""job"": ""Producer 2"",
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
                  }
                ],
                ""art"": [
                  {
                    ""job"": ""Art Director 1"",
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
                  },
                  {
                    ""job"": ""Art Director 2"",
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
                  }
                ],
                ""crew"": [
                  {
                    ""job"": ""Crew Member 1"",
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
                  },
                  {
                    ""job"": ""Crew Member 2"",
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
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""job"": ""Costume Designer"",
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
                  },
                  {
                    ""job"": ""Make Up Artist"",
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
                  }
                ],
                ""directing"": [
                  {
                    ""job"": ""Director 1"",
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
                  },
                  {
                    ""job"": ""Director 2"",
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
                  }
                ],
                ""writing"": [
                  {
                    ""job"": ""Writer 1"",
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
                  },
                  {
                    ""job"": ""Writer 2"",
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
                  }
                ],
                ""sound"": [
                  {
                    ""job"": ""Sound Designer 1"",
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
                  },
                  {
                    ""job"": ""Sound Designer 2"",
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
                  }
                ],
                ""camera"": [
                  {
                    ""job"": ""Camera Man 1"",
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
                  },
                  {
                    ""job"": ""Camera Man 2"",
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
                  }
                ],
                ""lighting"": [
                  {
                    ""job"": ""Light Technician 1"",
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
                  },
                  {
                    ""job"": ""Light Technician 2"",
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
                  }
                ],
                ""visual effects"": [
                  {
                    ""job"": ""VFX Artist 1"",
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
                  },
                  {
                    ""job"": ""VFX Artist 2"",
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
                  }
                ],
                ""editing"": [
                  {
                    ""job"": ""Editor 1"",
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
                  },
                  {
                    ""job"": ""Editor 2"",
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
                  }
                ]
              }";

        private const string FULL_JSON =
            @"{
                ""production"": [
                  {
                    ""job"": ""Producer 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Producer 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""art"": [
                  {
                    ""job"": ""Art Director 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Art Director 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""crew"": [
                  {
                    ""job"": ""Crew Member 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Crew Member 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""costume & make-up"": [
                  {
                    ""job"": ""Costume Designer"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Make Up Artist"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""directing"": [
                  {
                    ""job"": ""Director 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Director 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""writing"": [
                  {
                    ""job"": ""Writer 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Writer 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""sound"": [
                  {
                    ""job"": ""Sound Designer 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Sound Designer 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""camera"": [
                  {
                    ""job"": ""Camera Man 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Camera Man 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""lighting"": [
                  {
                    ""job"": ""Light Technician 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Light Technician 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""visual effects"": [
                  {
                    ""job"": ""VFX Artist 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""VFX Artist 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ],
                ""editing"": [
                  {
                    ""job"": ""Editor 1"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  },
                  {
                    ""job"": ""Editor 2"",
                    ""movie"": {
                      ""title"": ""Star Wars: The Force Awakens"",
                      ""year"": 2015,
                      ""ids"": {
                        ""trakt"": 94024,
                        ""slug"": ""star-wars-the-force-awakens-2015"",
                        ""imdb"": ""tt2488496"",
                        ""tmdb"": 140607
                      },
                      ""tagline"": ""Every generation has a story."",
                      ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                      ""released"": ""2015-12-18"",
                      ""runtime"": 136,
                      ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                      ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                      ""rating"": 8.31988,
                      ""votes"": 9338,
                      ""updated_at"": ""2016-03-31T09:01:59Z"",
                      ""language"": ""en"",
                      ""available_translations"": [
                        ""en"",
                        ""de"",
                        ""en"",
                        ""it""
                      ],
                      ""genres"": [
                        ""action"",
                        ""adventure"",
                        ""fantasy"",
                        ""science-fiction""
                      ],
                      ""certification"": ""PG-13""
                    }
                  }
                ]
              }";
    }
}
