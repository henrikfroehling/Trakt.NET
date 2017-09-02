namespace TraktApiSharp.Tests.Objects.Get.Movies.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktTrendingMovie_Tests
    {
        [Fact]
        public void Test_TraktTrendingMovie_Implements_ITraktTrendingMovie_Interface()
        {
            typeof(TraktTrendingMovie).GetInterfaces().Should().Contain(typeof(ITraktTrendingMovie));
        }

        [Fact]
        public void Test_TraktTrendingMovie_Default_Constructor()
        {
            var trendingMovie = new TraktTrendingMovie();

            trendingMovie.Watchers.Should().NotHaveValue();

            trendingMovie.Movie.Should().BeNull();
            trendingMovie.Title.Should().BeNullOrEmpty();
            trendingMovie.Year.Should().NotHaveValue();
            trendingMovie.Ids.Should().BeNull();
            trendingMovie.Tagline.Should().BeNullOrEmpty();
            trendingMovie.Overview.Should().BeNullOrEmpty();
            trendingMovie.Released.Should().NotHaveValue();
            trendingMovie.Runtime.Should().NotHaveValue();
            trendingMovie.UpdatedAt.Should().NotHaveValue();
            trendingMovie.Trailer.Should().BeNullOrEmpty();
            trendingMovie.Homepage.Should().BeNullOrEmpty();
            trendingMovie.Rating.Should().NotHaveValue();
            trendingMovie.Votes.Should().NotHaveValue();
            trendingMovie.LanguageCode.Should().BeNullOrEmpty();
            trendingMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            trendingMovie.Genres.Should().BeNull();
            trendingMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktTrendingMovie_From_Minimal_Json()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();
            var trendingMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktTrendingMovie;

            trendingMovie.Should().NotBeNull();
            trendingMovie.Watchers.Should().Be(35);

            trendingMovie.Movie.Should().NotBeNull();
            trendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            trendingMovie.Movie.Year.Should().Be(2015);
            trendingMovie.Movie.Ids.Should().NotBeNull();
            trendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
            trendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            trendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            trendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            trendingMovie.Movie.Tagline.Should().BeNullOrEmpty();
            trendingMovie.Movie.Overview.Should().BeNullOrEmpty();
            trendingMovie.Movie.Released.Should().NotHaveValue();
            trendingMovie.Movie.Runtime.Should().NotHaveValue();
            trendingMovie.Movie.UpdatedAt.Should().NotHaveValue();
            trendingMovie.Movie.Trailer.Should().BeNullOrEmpty();
            trendingMovie.Movie.Homepage.Should().BeNullOrEmpty();
            trendingMovie.Movie.Rating.Should().NotHaveValue();
            trendingMovie.Movie.Votes.Should().NotHaveValue();
            trendingMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            trendingMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            trendingMovie.Movie.Genres.Should().BeNull();
            trendingMovie.Movie.Certification.Should().BeNullOrEmpty();

            trendingMovie.Title.Should().Be("Star Wars: The Force Awakens");
            trendingMovie.Year.Should().Be(2015);
            trendingMovie.Ids.Should().NotBeNull();
            trendingMovie.Ids.Trakt.Should().Be(94024U);
            trendingMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            trendingMovie.Ids.Imdb.Should().Be("tt2488496");
            trendingMovie.Ids.Tmdb.Should().Be(140607U);
            trendingMovie.Tagline.Should().BeNullOrEmpty();
            trendingMovie.Overview.Should().BeNullOrEmpty();
            trendingMovie.Released.Should().NotHaveValue();
            trendingMovie.Runtime.Should().NotHaveValue();
            trendingMovie.UpdatedAt.Should().NotHaveValue();
            trendingMovie.Trailer.Should().BeNullOrEmpty();
            trendingMovie.Homepage.Should().BeNullOrEmpty();
            trendingMovie.Rating.Should().NotHaveValue();
            trendingMovie.Votes.Should().NotHaveValue();
            trendingMovie.LanguageCode.Should().BeNullOrEmpty();
            trendingMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            trendingMovie.Genres.Should().BeNull();
            trendingMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktTrendingMovie_From_Full_Json()
        {
            var jsonReader = new TrendingMovieObjectJsonReader();
            var trendingMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktTrendingMovie;

            trendingMovie.Should().NotBeNull();
            trendingMovie.Watchers.Should().Be(35);

            trendingMovie.Movie.Should().NotBeNull();
            trendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            trendingMovie.Movie.Year.Should().Be(2015);
            trendingMovie.Movie.Ids.Should().NotBeNull();
            trendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
            trendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            trendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            trendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            trendingMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            trendingMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            trendingMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            trendingMovie.Movie.Runtime.Should().Be(136);
            trendingMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            trendingMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            trendingMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            trendingMovie.Movie.Rating.Should().Be(8.31988f);
            trendingMovie.Movie.Votes.Should().Be(9338);
            trendingMovie.Movie.LanguageCode.Should().Be("en");
            trendingMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            trendingMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            trendingMovie.Movie.Certification.Should().Be("PG-13");

            trendingMovie.Title.Should().Be("Star Wars: The Force Awakens");
            trendingMovie.Year.Should().Be(2015);
            trendingMovie.Ids.Should().NotBeNull();
            trendingMovie.Ids.Trakt.Should().Be(94024U);
            trendingMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            trendingMovie.Ids.Imdb.Should().Be("tt2488496");
            trendingMovie.Ids.Tmdb.Should().Be(140607U);
            trendingMovie.Tagline.Should().Be("Every generation has a story.");
            trendingMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            trendingMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            trendingMovie.Runtime.Should().Be(136);
            trendingMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            trendingMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            trendingMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            trendingMovie.Rating.Should().Be(8.31988f);
            trendingMovie.Votes.Should().Be(9338);
            trendingMovie.LanguageCode.Should().Be("en");
            trendingMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            trendingMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            trendingMovie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""watchers"": 35,
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
                ""watchers"": 35,
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
