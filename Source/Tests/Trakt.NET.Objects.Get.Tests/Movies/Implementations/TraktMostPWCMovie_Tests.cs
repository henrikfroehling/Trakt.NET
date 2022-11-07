namespace TraktNet.Objects.Get.Tests.Movies.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.Implementations")]
    public class TraktMostPWCMovie_Tests
    {
        [Fact]
        public void Test_TraktMostPWCMovie_Default_Constructor()
        {
            var mostPWCMovie = new TraktMostPWCMovie();

            mostPWCMovie.WatcherCount.Should().NotHaveValue();
            mostPWCMovie.PlayCount.Should().NotHaveValue();
            mostPWCMovie.CollectedCount.Should().NotHaveValue();

            mostPWCMovie.Movie.Should().BeNull();
            mostPWCMovie.Title.Should().BeNullOrEmpty();
            mostPWCMovie.Year.Should().NotHaveValue();
            mostPWCMovie.Ids.Should().BeNull();
            mostPWCMovie.Tagline.Should().BeNullOrEmpty();
            mostPWCMovie.Overview.Should().BeNullOrEmpty();
            mostPWCMovie.Released.Should().NotHaveValue();
            mostPWCMovie.Runtime.Should().NotHaveValue();
            mostPWCMovie.UpdatedAt.Should().NotHaveValue();
            mostPWCMovie.Trailer.Should().BeNullOrEmpty();
            mostPWCMovie.Homepage.Should().BeNullOrEmpty();
            mostPWCMovie.Rating.Should().NotHaveValue();
            mostPWCMovie.Votes.Should().NotHaveValue();
            mostPWCMovie.LanguageCode.Should().BeNullOrEmpty();
            mostPWCMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            mostPWCMovie.Genres.Should().BeNull();
            mostPWCMovie.Certification.Should().BeNullOrEmpty();
            mostPWCMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovie_From_Minimal_Json()
        {
            var jsonReader = new MostPWCMovieObjectJsonReader();
            var mostPWCMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktMostPWCMovie;

            mostPWCMovie.Should().NotBeNull();
            mostPWCMovie.WatcherCount.Should().Be(4992);
            mostPWCMovie.PlayCount.Should().Be(7100);
            mostPWCMovie.CollectedCount.Should().Be(1348);

            mostPWCMovie.Movie.Should().NotBeNull();
            mostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            mostPWCMovie.Movie.Year.Should().Be(2015);
            mostPWCMovie.Movie.Ids.Should().NotBeNull();
            mostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            mostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            mostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            mostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            mostPWCMovie.Movie.Tagline.Should().BeNullOrEmpty();
            mostPWCMovie.Movie.Overview.Should().BeNullOrEmpty();
            mostPWCMovie.Movie.Released.Should().NotHaveValue();
            mostPWCMovie.Movie.Runtime.Should().NotHaveValue();
            mostPWCMovie.Movie.UpdatedAt.Should().NotHaveValue();
            mostPWCMovie.Movie.Trailer.Should().BeNullOrEmpty();
            mostPWCMovie.Movie.Homepage.Should().BeNullOrEmpty();
            mostPWCMovie.Movie.Rating.Should().NotHaveValue();
            mostPWCMovie.Movie.Votes.Should().NotHaveValue();
            mostPWCMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            mostPWCMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            mostPWCMovie.Movie.Genres.Should().BeNull();
            mostPWCMovie.Movie.Certification.Should().BeNullOrEmpty();
            mostPWCMovie.Movie.CountryCode.Should().BeNullOrEmpty();

            mostPWCMovie.Title.Should().Be("Star Wars: The Force Awakens");
            mostPWCMovie.Year.Should().Be(2015);
            mostPWCMovie.Ids.Should().NotBeNull();
            mostPWCMovie.Ids.Trakt.Should().Be(94024U);
            mostPWCMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            mostPWCMovie.Ids.Imdb.Should().Be("tt2488496");
            mostPWCMovie.Ids.Tmdb.Should().Be(140607U);
            mostPWCMovie.Tagline.Should().BeNullOrEmpty();
            mostPWCMovie.Overview.Should().BeNullOrEmpty();
            mostPWCMovie.Released.Should().NotHaveValue();
            mostPWCMovie.Runtime.Should().NotHaveValue();
            mostPWCMovie.UpdatedAt.Should().NotHaveValue();
            mostPWCMovie.Trailer.Should().BeNullOrEmpty();
            mostPWCMovie.Homepage.Should().BeNullOrEmpty();
            mostPWCMovie.Rating.Should().NotHaveValue();
            mostPWCMovie.Votes.Should().NotHaveValue();
            mostPWCMovie.LanguageCode.Should().BeNullOrEmpty();
            mostPWCMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            mostPWCMovie.Genres.Should().BeNull();
            mostPWCMovie.Certification.Should().BeNullOrEmpty();
            mostPWCMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMostPWCMovie_From_Full_Json()
        {
            var jsonReader = new MostPWCMovieObjectJsonReader();
            var mostPWCMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktMostPWCMovie;

            mostPWCMovie.Should().NotBeNull();
            mostPWCMovie.WatcherCount.Should().Be(4992);
            mostPWCMovie.PlayCount.Should().Be(7100);
            mostPWCMovie.CollectedCount.Should().Be(1348);

            mostPWCMovie.Movie.Should().NotBeNull();
            mostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            mostPWCMovie.Movie.Year.Should().Be(2015);
            mostPWCMovie.Movie.Ids.Should().NotBeNull();
            mostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            mostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            mostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            mostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            mostPWCMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            mostPWCMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            mostPWCMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            mostPWCMovie.Movie.Runtime.Should().Be(136);
            mostPWCMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            mostPWCMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            mostPWCMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            mostPWCMovie.Movie.Rating.Should().Be(8.31988f);
            mostPWCMovie.Movie.Votes.Should().Be(9338);
            mostPWCMovie.Movie.LanguageCode.Should().Be("en");
            mostPWCMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            mostPWCMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            mostPWCMovie.Movie.Certification.Should().Be("PG-13");
            mostPWCMovie.Movie.CountryCode.Should().Be("us");

            mostPWCMovie.Title.Should().Be("Star Wars: The Force Awakens");
            mostPWCMovie.Year.Should().Be(2015);
            mostPWCMovie.Ids.Should().NotBeNull();
            mostPWCMovie.Ids.Trakt.Should().Be(94024U);
            mostPWCMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            mostPWCMovie.Ids.Imdb.Should().Be("tt2488496");
            mostPWCMovie.Ids.Tmdb.Should().Be(140607U);
            mostPWCMovie.Tagline.Should().Be("Every generation has a story.");
            mostPWCMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            mostPWCMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            mostPWCMovie.Runtime.Should().Be(136);
            mostPWCMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            mostPWCMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            mostPWCMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            mostPWCMovie.Rating.Should().Be(8.31988f);
            mostPWCMovie.Votes.Should().Be(9338);
            mostPWCMovie.LanguageCode.Should().Be("en");
            mostPWCMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            mostPWCMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            mostPWCMovie.Certification.Should().Be("PG-13");
            mostPWCMovie.CountryCode.Should().Be("us");
        }

        private const string MINIMAL_JSON =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
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
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
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
