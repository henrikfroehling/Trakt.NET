namespace TraktNet.Objects.Get.Tests.People.Credits.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonMovieCredits_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCredits_Default_Constructor()
        {
            var credits = new TraktPersonMovieCredits();

            credits.Cast.Should().BeNull();
            credits.Crew.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonMovieCredits_From_Json()
        {
            var jsonReader = new PersonMovieCreditsObjectJsonReader();
            var credits = await jsonReader.ReadObjectAsync(JSON) as TraktPersonMovieCredits;

            credits.Should().NotBeNull();
            credits.Cast.Should().NotBeNull().And.HaveCount(2);
            credits.Crew.Should().NotBeNull();

            var creditsCast = credits.Cast.ToArray();

            creditsCast[0].Should().NotBeNull();
            creditsCast[0].Character.Should().Be("Rey");
            creditsCast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Ray");
            creditsCast[0].Movie.Should().NotBeNull();
            creditsCast[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCast[0].Movie.Year.Should().Be(2015);
            creditsCast[0].Movie.Ids.Should().NotBeNull();
            creditsCast[0].Movie.Ids.Trakt.Should().Be(94024U);
            creditsCast[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCast[0].Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCast[0].Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCast[0].Movie.Tagline.Should().BeNullOrEmpty();
            creditsCast[0].Movie.Overview.Should().BeNullOrEmpty();
            creditsCast[0].Movie.Released.Should().NotHaveValue();
            creditsCast[0].Movie.Runtime.Should().NotHaveValue();
            creditsCast[0].Movie.UpdatedAt.Should().NotHaveValue();
            creditsCast[0].Movie.Trailer.Should().BeNullOrEmpty();
            creditsCast[0].Movie.Homepage.Should().BeNullOrEmpty();
            creditsCast[0].Movie.Rating.Should().NotHaveValue();
            creditsCast[0].Movie.Votes.Should().NotHaveValue();
            creditsCast[0].Movie.LanguageCode.Should().BeNullOrEmpty();
            creditsCast[0].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCast[0].Movie.Genres.Should().BeNull();
            creditsCast[0].Movie.Certification.Should().BeNullOrEmpty();

            creditsCast[1].Should().NotBeNull();
            creditsCast[1].Character.Should().Be("Han Solo");
            creditsCast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Han Solo");
            creditsCast[1].Movie.Should().NotBeNull();
            creditsCast[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCast[1].Movie.Year.Should().Be(2015);
            creditsCast[1].Movie.Ids.Should().NotBeNull();
            creditsCast[1].Movie.Ids.Trakt.Should().Be(94024U);
            creditsCast[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCast[1].Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCast[1].Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCast[1].Movie.Tagline.Should().BeNullOrEmpty();
            creditsCast[1].Movie.Overview.Should().BeNullOrEmpty();
            creditsCast[1].Movie.Released.Should().NotHaveValue();
            creditsCast[1].Movie.Runtime.Should().NotHaveValue();
            creditsCast[1].Movie.UpdatedAt.Should().NotHaveValue();
            creditsCast[1].Movie.Trailer.Should().BeNullOrEmpty();
            creditsCast[1].Movie.Homepage.Should().BeNullOrEmpty();
            creditsCast[1].Movie.Rating.Should().NotHaveValue();
            creditsCast[1].Movie.Votes.Should().NotHaveValue();
            creditsCast[1].Movie.LanguageCode.Should().BeNullOrEmpty();
            creditsCast[1].Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCast[1].Movie.Genres.Should().BeNull();
            creditsCast[1].Movie.Certification.Should().BeNullOrEmpty();

            var creditsCrew = credits.Crew;

            creditsCrew.Production.Should().NotBeNull().And.HaveCount(2);

            var productionCrew = creditsCrew.Production.ToArray();

            productionCrew[0].Should().NotBeNull();
            productionCrew[0].Job.Should().Be("Producer 1");
            productionCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer 1");
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
            productionCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Producer 2");
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
            artCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Art Director 1");
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
            artCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Art Director 2");
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
            crew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Crew Member 1");
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
            crew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Crew Member 2");
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
            costumeAndMakeupCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Costume Designer");
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
            costumeAndMakeupCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Make Up Artist");
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
            directingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director 1");
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
            directingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director 2");
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
            writingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer 1");
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
            writingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer 2");
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
            soundCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Sound Designer 1");
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
            soundCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Sound Designer 2");
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
            cameraCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Camera Man 1");
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
            cameraCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Camera Man 2");
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
            lightingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Light Technician 1");
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
            lightingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Light Technician 2");
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
            vfxCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("VFX Artist 1");
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
            vfxCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("VFX Artist 2");
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
            editingCrew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor 1");
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
            editingCrew[1].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor 2");
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

        private const string JSON =
            @"{
                ""cast"": [
                  {
                     ""character"": ""Rey"",
                     ""characters"": [
                       ""Rey""
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
                  },
                  {
                     ""character"": ""Han Solo"",
                     ""characters"": [
                       ""Han Solo""
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
                  }
                ],
                ""crew"": {
                  ""production"": [
                    {
                      ""job"": ""Producer 1"",
                      ""jobs"": [
                        ""Producer 1""
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
                    },
                    {
                      ""job"": ""Producer 2"",
                      ""jobs"": [
                        ""Producer 2""
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
                    }
                  ],
                  ""art"": [
                    {
                      ""job"": ""Art Director 1"",
                      ""jobs"": [
                        ""Art Director 1""
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
                    },
                    {
                      ""job"": ""Art Director 2"",
                      ""jobs"": [
                        ""Art Director 2""
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
                    }
                  ],
                  ""crew"": [
                    {
                      ""job"": ""Crew Member 1"",
                      ""jobs"": [
                        ""Crew Member 1""
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
                    },
                    {
                      ""job"": ""Crew Member 2"",
                      ""jobs"": [
                        ""Crew Member 2""
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
                    }
                  ],
                  ""costume & make-up"": [
                    {
                      ""job"": ""Costume Designer"",
                      ""jobs"": [
                        ""Costume Designer""
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
                    },
                    {
                      ""job"": ""Make Up Artist"",
                      ""jobs"": [
                        ""Make Up Artist""
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
                    }
                  ],
                  ""directing"": [
                    {
                      ""job"": ""Director 1"",
                      ""jobs"": [
                        ""Director 1""
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
                    },
                    {
                      ""job"": ""Director 2"",
                      ""jobs"": [
                        ""Director 2""
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
                    }
                  ],
                  ""writing"": [
                    {
                      ""job"": ""Writer 1"",
                      ""jobs"": [
                        ""Writer 1""
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
                    },
                    {
                      ""job"": ""Writer 2"",
                      ""jobs"": [
                        ""Writer 2""
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
                    }
                  ],
                  ""sound"": [
                    {
                      ""job"": ""Sound Designer 1"",
                      ""jobs"": [
                        ""Sound Designer 1""
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
                    },
                    {
                      ""job"": ""Sound Designer 2"",
                      ""jobs"": [
                        ""Sound Designer 2""
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
                    }
                  ],
                  ""camera"": [
                    {
                      ""job"": ""Camera Man 1"",
                      ""jobs"": [
                        ""Camera Man 1""
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
                    },
                    {
                      ""job"": ""Camera Man 2"",
                      ""jobs"": [
                        ""Camera Man 2""
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
                    }
                  ],
                  ""lighting"": [
                    {
                      ""job"": ""Light Technician 1"",
                      ""jobs"": [
                        ""Light Technician 1""
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
                    },
                    {
                      ""job"": ""Light Technician 2"",
                      ""jobs"": [
                        ""Light Technician 2""
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
                    }
                  ],
                  ""visual effects"": [
                    {
                      ""job"": ""VFX Artist 1"",
                      ""jobs"": [
                        ""VFX Artist 1""
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
                    },
                    {
                      ""job"": ""VFX Artist 2"",
                      ""jobs"": [
                        ""VFX Artist 2""
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
                    }
                  ],
                  ""editing"": [
                    {
                      ""job"": ""Editor 1"",
                      ""jobs"": [
                        ""Editor 1""
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
                    },
                    {
                      ""job"": ""Editor 2"",
                      ""jobs"": [
                        ""Editor 2""
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
                    }
                  ]
                }
              }";
    }
}
