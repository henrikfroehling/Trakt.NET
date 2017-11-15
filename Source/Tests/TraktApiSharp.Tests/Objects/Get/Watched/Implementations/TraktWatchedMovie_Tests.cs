namespace TraktApiSharp.Tests.Objects.Get.Watched.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.Implementations;
    using TraktApiSharp.Objects.Get.Watched.Json;
    using Xunit;

    [Category("Objects.Get.Watched.Implementations")]
    public class TraktWatchedMovie_Tests
    {
        [Fact]
        public void Test_TraktWatchedMovie_Default_Constructor()
        {
            var watchedMovie = new TraktWatchedMovie();

            watchedMovie.Plays.Should().NotHaveValue();
            watchedMovie.LastWatchedAt.Should().NotHaveValue();
            watchedMovie.Movie.Should().BeNull();
            watchedMovie.Title.Should().BeNullOrEmpty();
            watchedMovie.Year.Should().NotHaveValue();
            watchedMovie.Ids.Should().BeNull();
            watchedMovie.Tagline.Should().BeNullOrEmpty();
            watchedMovie.Overview.Should().BeNullOrEmpty();
            watchedMovie.Released.Should().NotHaveValue();
            watchedMovie.Runtime.Should().NotHaveValue();
            watchedMovie.UpdatedAt.Should().NotHaveValue();
            watchedMovie.Trailer.Should().BeNullOrEmpty();
            watchedMovie.Homepage.Should().BeNullOrEmpty();
            watchedMovie.Rating.Should().NotHaveValue();
            watchedMovie.Votes.Should().NotHaveValue();
            watchedMovie.LanguageCode.Should().BeNullOrEmpty();
            watchedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            watchedMovie.Genres.Should().BeNull();
            watchedMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktWatchedMovie_From_Minimal_Json()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();
            var watchedMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktWatchedMovie;

            watchedMovie.Should().NotBeNull();
            watchedMovie.Plays.Should().Be(10);
            watchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            watchedMovie.Movie.Should().NotBeNull();
            watchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            watchedMovie.Movie.Year.Should().Be(2015);
            watchedMovie.Movie.Ids.Should().NotBeNull();
            watchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            watchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            watchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            watchedMovie.Movie.Tagline.Should().BeNullOrEmpty();
            watchedMovie.Movie.Overview.Should().BeNullOrEmpty();
            watchedMovie.Movie.Released.Should().NotHaveValue();
            watchedMovie.Movie.Runtime.Should().NotHaveValue();
            watchedMovie.Movie.UpdatedAt.Should().NotHaveValue();
            watchedMovie.Movie.Trailer.Should().BeNullOrEmpty();
            watchedMovie.Movie.Homepage.Should().BeNullOrEmpty();
            watchedMovie.Movie.Rating.Should().NotHaveValue();
            watchedMovie.Movie.Votes.Should().NotHaveValue();
            watchedMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            watchedMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            watchedMovie.Movie.Genres.Should().BeNull();
            watchedMovie.Movie.Certification.Should().BeNullOrEmpty();

            watchedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            watchedMovie.Year.Should().Be(2015);
            watchedMovie.Ids.Should().NotBeNull();
            watchedMovie.Ids.Trakt.Should().Be(94024U);
            watchedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchedMovie.Ids.Imdb.Should().Be("tt2488496");
            watchedMovie.Ids.Tmdb.Should().Be(140607U);
            watchedMovie.Tagline.Should().BeNullOrEmpty();
            watchedMovie.Overview.Should().BeNullOrEmpty();
            watchedMovie.Released.Should().NotHaveValue();
            watchedMovie.Runtime.Should().NotHaveValue();
            watchedMovie.UpdatedAt.Should().NotHaveValue();
            watchedMovie.Trailer.Should().BeNullOrEmpty();
            watchedMovie.Homepage.Should().BeNullOrEmpty();
            watchedMovie.Rating.Should().NotHaveValue();
            watchedMovie.Votes.Should().NotHaveValue();
            watchedMovie.LanguageCode.Should().BeNullOrEmpty();
            watchedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            watchedMovie.Genres.Should().BeNull();
            watchedMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktWatchedMovie_From_Full_Json()
        {
            var jsonReader = new WatchedMovieObjectJsonReader();
            var watchedMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktWatchedMovie;

            watchedMovie.Should().NotBeNull();
            watchedMovie.Plays.Should().Be(10);
            watchedMovie.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            watchedMovie.Movie.Should().NotBeNull();
            watchedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            watchedMovie.Movie.Year.Should().Be(2015);
            watchedMovie.Movie.Ids.Should().NotBeNull();
            watchedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            watchedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            watchedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            watchedMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            watchedMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            watchedMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            watchedMovie.Movie.Runtime.Should().Be(136);
            watchedMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            watchedMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchedMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            watchedMovie.Movie.Rating.Should().Be(8.31988f);
            watchedMovie.Movie.Votes.Should().Be(9338);
            watchedMovie.Movie.LanguageCode.Should().Be("en");
            watchedMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            watchedMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            watchedMovie.Movie.Certification.Should().Be("PG-13");

            watchedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            watchedMovie.Year.Should().Be(2015);
            watchedMovie.Ids.Should().NotBeNull();
            watchedMovie.Ids.Trakt.Should().Be(94024U);
            watchedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchedMovie.Ids.Imdb.Should().Be("tt2488496");
            watchedMovie.Ids.Tmdb.Should().Be(140607U);
            watchedMovie.Tagline.Should().Be("Every generation has a story.");
            watchedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            watchedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            watchedMovie.Runtime.Should().Be(136);
            watchedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            watchedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            watchedMovie.Rating.Should().Be(8.31988f);
            watchedMovie.Votes.Should().Be(9338);
            watchedMovie.LanguageCode.Should().Be("en");
            watchedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            watchedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            watchedMovie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""plays"": 10,
                ""last_watched_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""plays"": 10,
                ""last_watched_at"": ""2014-09-01T09:10:11.000Z"",
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
              }";
    }
}
