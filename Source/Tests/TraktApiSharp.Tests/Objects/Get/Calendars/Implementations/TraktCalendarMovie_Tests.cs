namespace TraktApiSharp.Tests.Objects.Get.Calendars.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Calendars.Implementations")]
    public class TraktCalendarMovie_Tests
    {
        [Fact]
        public void Test_TraktCalendarMovie_Default_Constructor()
        {
            var calendarMovie = new TraktCalendarMovie();

            calendarMovie.CalendarRelease.Should().NotHaveValue();

            calendarMovie.Movie.Should().BeNull();
            calendarMovie.Title.Should().BeNullOrEmpty();
            calendarMovie.Year.Should().NotHaveValue();
            calendarMovie.Ids.Should().BeNull();
            calendarMovie.Tagline.Should().BeNullOrEmpty();
            calendarMovie.Overview.Should().BeNullOrEmpty();
            calendarMovie.Released.Should().NotHaveValue();
            calendarMovie.Runtime.Should().NotHaveValue();
            calendarMovie.UpdatedAt.Should().NotHaveValue();
            calendarMovie.Trailer.Should().BeNullOrEmpty();
            calendarMovie.Homepage.Should().BeNullOrEmpty();
            calendarMovie.Rating.Should().NotHaveValue();
            calendarMovie.Votes.Should().NotHaveValue();
            calendarMovie.LanguageCode.Should().BeNullOrEmpty();
            calendarMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarMovie.Genres.Should().BeNull();
            calendarMovie.Certification.Should().BeNullOrEmpty();
            calendarMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktCalendarMovie_From_Minimal_Json()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();
            var calendarMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktCalendarMovie;

            calendarMovie.Should().NotBeNull();
            calendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));

            calendarMovie.Movie.Should().NotBeNull();
            calendarMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            calendarMovie.Movie.Year.Should().Be(2015);
            calendarMovie.Movie.Ids.Should().NotBeNull();
            calendarMovie.Movie.Ids.Trakt.Should().Be(94024U);
            calendarMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            calendarMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            calendarMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            calendarMovie.Movie.Tagline.Should().BeNullOrEmpty();
            calendarMovie.Movie.Overview.Should().BeNullOrEmpty();
            calendarMovie.Movie.Released.Should().NotHaveValue();
            calendarMovie.Movie.Runtime.Should().NotHaveValue();
            calendarMovie.Movie.UpdatedAt.Should().NotHaveValue();
            calendarMovie.Movie.Trailer.Should().BeNullOrEmpty();
            calendarMovie.Movie.Homepage.Should().BeNullOrEmpty();
            calendarMovie.Movie.Rating.Should().NotHaveValue();
            calendarMovie.Movie.Votes.Should().NotHaveValue();
            calendarMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            calendarMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarMovie.Movie.Genres.Should().BeNull();
            calendarMovie.Movie.Certification.Should().BeNullOrEmpty();
            calendarMovie.Movie.CountryCode.Should().BeNullOrEmpty();

            calendarMovie.Title.Should().Be("Star Wars: The Force Awakens");
            calendarMovie.Year.Should().Be(2015);
            calendarMovie.Ids.Should().NotBeNull();
            calendarMovie.Ids.Trakt.Should().Be(94024U);
            calendarMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            calendarMovie.Ids.Imdb.Should().Be("tt2488496");
            calendarMovie.Ids.Tmdb.Should().Be(140607U);
            calendarMovie.Tagline.Should().BeNullOrEmpty();
            calendarMovie.Overview.Should().BeNullOrEmpty();
            calendarMovie.Released.Should().NotHaveValue();
            calendarMovie.Runtime.Should().NotHaveValue();
            calendarMovie.UpdatedAt.Should().NotHaveValue();
            calendarMovie.Trailer.Should().BeNullOrEmpty();
            calendarMovie.Homepage.Should().BeNullOrEmpty();
            calendarMovie.Rating.Should().NotHaveValue();
            calendarMovie.Votes.Should().NotHaveValue();
            calendarMovie.LanguageCode.Should().BeNullOrEmpty();
            calendarMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarMovie.Genres.Should().BeNull();
            calendarMovie.Certification.Should().BeNullOrEmpty();
            calendarMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktCalendarMovie_From_Full_Json()
        {
            var jsonReader = new CalendarMovieObjectJsonReader();
            var calendarMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktCalendarMovie;

            calendarMovie.Should().NotBeNull();
            calendarMovie.CalendarRelease.Should().Be(DateTime.Parse("2014-08-01"));

            calendarMovie.Movie.Should().NotBeNull();
            calendarMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            calendarMovie.Movie.Year.Should().Be(2015);
            calendarMovie.Movie.Ids.Should().NotBeNull();
            calendarMovie.Movie.Ids.Trakt.Should().Be(94024U);
            calendarMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            calendarMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            calendarMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            calendarMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            calendarMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            calendarMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            calendarMovie.Movie.Runtime.Should().Be(136);
            calendarMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            calendarMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            calendarMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            calendarMovie.Movie.Rating.Should().Be(8.31988f);
            calendarMovie.Movie.Votes.Should().Be(9338);
            calendarMovie.Movie.LanguageCode.Should().Be("en");
            calendarMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            calendarMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            calendarMovie.Movie.Certification.Should().Be("PG-13");
            calendarMovie.Movie.CountryCode.Should().Be("us");

            calendarMovie.Title.Should().Be("Star Wars: The Force Awakens");
            calendarMovie.Year.Should().Be(2015);
            calendarMovie.Ids.Should().NotBeNull();
            calendarMovie.Ids.Trakt.Should().Be(94024U);
            calendarMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            calendarMovie.Ids.Imdb.Should().Be("tt2488496");
            calendarMovie.Ids.Tmdb.Should().Be(140607U);
            calendarMovie.Tagline.Should().Be("Every generation has a story.");
            calendarMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            calendarMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            calendarMovie.Runtime.Should().Be(136);
            calendarMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            calendarMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            calendarMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            calendarMovie.Rating.Should().Be(8.31988f);
            calendarMovie.Votes.Should().Be(9338);
            calendarMovie.LanguageCode.Should().Be("en");
            calendarMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            calendarMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            calendarMovie.Certification.Should().Be("PG-13");
            calendarMovie.CountryCode.Should().Be("us");
        }

        private const string MINIMAL_JSON =
            @"{
                ""released"": ""2014-08-01"",
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

        private const string FULL_JSON =
            @"{
                ""released"": ""2014-08-01"",
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
                  ""certification"": ""PG-13"",
                  ""country"": ""us""
                }
              }";
    }
}
