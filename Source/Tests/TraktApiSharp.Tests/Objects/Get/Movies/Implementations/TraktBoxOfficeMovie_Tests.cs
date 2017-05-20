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
    public class TraktBoxOfficeMovie_Tests
    {
        [Fact]
        public void Test_TraktBoxOfficeMovie_Implements_ITraktBoxOfficeMovie_Interface()
        {
            typeof(TraktBoxOfficeMovie).GetInterfaces().Should().Contain(typeof(ITraktBoxOfficeMovie));
        }

        [Fact]
        public void Test_TraktBoxOfficeMovie_Default_Constructor()
        {
            var boxOfficeMovie = new TraktBoxOfficeMovie();

            boxOfficeMovie.Revenue.Should().NotHaveValue();

            boxOfficeMovie.Movie.Should().BeNull();
            boxOfficeMovie.Title.Should().BeNullOrEmpty();
            boxOfficeMovie.Year.Should().NotHaveValue();
            boxOfficeMovie.Ids.Should().BeNull();
            boxOfficeMovie.Tagline.Should().BeNullOrEmpty();
            boxOfficeMovie.Overview.Should().BeNullOrEmpty();
            boxOfficeMovie.Released.Should().NotHaveValue();
            boxOfficeMovie.Runtime.Should().NotHaveValue();
            boxOfficeMovie.UpdatedAt.Should().NotHaveValue();
            boxOfficeMovie.Trailer.Should().BeNullOrEmpty();
            boxOfficeMovie.Homepage.Should().BeNullOrEmpty();
            boxOfficeMovie.Rating.Should().NotHaveValue();
            boxOfficeMovie.Votes.Should().NotHaveValue();
            boxOfficeMovie.LanguageCode.Should().BeNullOrEmpty();
            boxOfficeMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            boxOfficeMovie.Genres.Should().BeNull();
            boxOfficeMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktBoxOfficeMovie_From_Minimal_Json()
        {
            var jsonReader = new TraktBoxOfficeMovieObjectJsonReader();
            var boxOfficeMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktBoxOfficeMovie;

            boxOfficeMovie.Should().NotBeNull();
            boxOfficeMovie.Revenue.Should().Be(166007347);

            boxOfficeMovie.Movie.Should().NotBeNull();
            boxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            boxOfficeMovie.Movie.Year.Should().Be(2015);
            boxOfficeMovie.Movie.Ids.Should().NotBeNull();
            boxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            boxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            boxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            boxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            boxOfficeMovie.Movie.Tagline.Should().BeNullOrEmpty();
            boxOfficeMovie.Movie.Overview.Should().BeNullOrEmpty();
            boxOfficeMovie.Movie.Released.Should().NotHaveValue();
            boxOfficeMovie.Movie.Runtime.Should().NotHaveValue();
            boxOfficeMovie.Movie.UpdatedAt.Should().NotHaveValue();
            boxOfficeMovie.Movie.Trailer.Should().BeNullOrEmpty();
            boxOfficeMovie.Movie.Homepage.Should().BeNullOrEmpty();
            boxOfficeMovie.Movie.Rating.Should().NotHaveValue();
            boxOfficeMovie.Movie.Votes.Should().NotHaveValue();
            boxOfficeMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            boxOfficeMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            boxOfficeMovie.Movie.Genres.Should().BeNull();
            boxOfficeMovie.Movie.Certification.Should().BeNullOrEmpty();

            boxOfficeMovie.Title.Should().Be("Star Wars: The Force Awakens");
            boxOfficeMovie.Year.Should().Be(2015);
            boxOfficeMovie.Ids.Should().NotBeNull();
            boxOfficeMovie.Ids.Trakt.Should().Be(94024U);
            boxOfficeMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            boxOfficeMovie.Ids.Imdb.Should().Be("tt2488496");
            boxOfficeMovie.Ids.Tmdb.Should().Be(140607U);
            boxOfficeMovie.Tagline.Should().BeNullOrEmpty();
            boxOfficeMovie.Overview.Should().BeNullOrEmpty();
            boxOfficeMovie.Released.Should().NotHaveValue();
            boxOfficeMovie.Runtime.Should().NotHaveValue();
            boxOfficeMovie.UpdatedAt.Should().NotHaveValue();
            boxOfficeMovie.Trailer.Should().BeNullOrEmpty();
            boxOfficeMovie.Homepage.Should().BeNullOrEmpty();
            boxOfficeMovie.Rating.Should().NotHaveValue();
            boxOfficeMovie.Votes.Should().NotHaveValue();
            boxOfficeMovie.LanguageCode.Should().BeNullOrEmpty();
            boxOfficeMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            boxOfficeMovie.Genres.Should().BeNull();
            boxOfficeMovie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktBoxOfficeMovie_From_Full_Json()
        {
            var jsonReader = new TraktBoxOfficeMovieObjectJsonReader();
            var boxOfficeMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktBoxOfficeMovie;

            boxOfficeMovie.Should().NotBeNull();
            boxOfficeMovie.Revenue.Should().Be(166007347);

            boxOfficeMovie.Movie.Should().NotBeNull();
            boxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            boxOfficeMovie.Movie.Year.Should().Be(2015);
            boxOfficeMovie.Movie.Ids.Should().NotBeNull();
            boxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            boxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            boxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            boxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            boxOfficeMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            boxOfficeMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            boxOfficeMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            boxOfficeMovie.Movie.Runtime.Should().Be(136);
            boxOfficeMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            boxOfficeMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            boxOfficeMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            boxOfficeMovie.Movie.Rating.Should().Be(8.31988f);
            boxOfficeMovie.Movie.Votes.Should().Be(9338);
            boxOfficeMovie.Movie.LanguageCode.Should().Be("en");
            boxOfficeMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            boxOfficeMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            boxOfficeMovie.Movie.Certification.Should().Be("PG-13");

            boxOfficeMovie.Title.Should().Be("Star Wars: The Force Awakens");
            boxOfficeMovie.Year.Should().Be(2015);
            boxOfficeMovie.Ids.Should().NotBeNull();
            boxOfficeMovie.Ids.Trakt.Should().Be(94024U);
            boxOfficeMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            boxOfficeMovie.Ids.Imdb.Should().Be("tt2488496");
            boxOfficeMovie.Ids.Tmdb.Should().Be(140607U);
            boxOfficeMovie.Tagline.Should().Be("Every generation has a story.");
            boxOfficeMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            boxOfficeMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            boxOfficeMovie.Runtime.Should().Be(136);
            boxOfficeMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            boxOfficeMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            boxOfficeMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            boxOfficeMovie.Rating.Should().Be(8.31988f);
            boxOfficeMovie.Votes.Should().Be(9338);
            boxOfficeMovie.LanguageCode.Should().Be("en");
            boxOfficeMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            boxOfficeMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            boxOfficeMovie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""revenue"": 166007347,
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
                ""revenue"": 166007347,
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
