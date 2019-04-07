namespace TraktNet.Objects.Tests.Get.Movies.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktMostAnticipatedMovie_Tests
    {
        [Fact]
        public void Test_TraktMostAnticipatedMovie_Default_Constructor()
        {
            var anticipatedMovie = new TraktMostAnticipatedMovie();

            anticipatedMovie.ListCount.Should().NotHaveValue();

            anticipatedMovie.Movie.Should().BeNull();
            anticipatedMovie.Title.Should().BeNullOrEmpty();
            anticipatedMovie.Year.Should().NotHaveValue();
            anticipatedMovie.Ids.Should().BeNull();
            anticipatedMovie.Tagline.Should().BeNullOrEmpty();
            anticipatedMovie.Overview.Should().BeNullOrEmpty();
            anticipatedMovie.Released.Should().NotHaveValue();
            anticipatedMovie.Runtime.Should().NotHaveValue();
            anticipatedMovie.UpdatedAt.Should().NotHaveValue();
            anticipatedMovie.Trailer.Should().BeNullOrEmpty();
            anticipatedMovie.Homepage.Should().BeNullOrEmpty();
            anticipatedMovie.Rating.Should().NotHaveValue();
            anticipatedMovie.Votes.Should().NotHaveValue();
            anticipatedMovie.LanguageCode.Should().BeNullOrEmpty();
            anticipatedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            anticipatedMovie.Genres.Should().BeNull();
            anticipatedMovie.Certification.Should().BeNullOrEmpty();
            anticipatedMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMostAnticipatedMovie_From_Minimal_Json()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();
            var anticipatedMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktMostAnticipatedMovie;

            anticipatedMovie.Should().NotBeNull();
            anticipatedMovie.ListCount.Should().Be(12805);

            anticipatedMovie.Movie.Should().NotBeNull();
            anticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            anticipatedMovie.Movie.Year.Should().Be(2015);
            anticipatedMovie.Movie.Ids.Should().NotBeNull();
            anticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            anticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            anticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            anticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            anticipatedMovie.Movie.Tagline.Should().BeNullOrEmpty();
            anticipatedMovie.Movie.Overview.Should().BeNullOrEmpty();
            anticipatedMovie.Movie.Released.Should().NotHaveValue();
            anticipatedMovie.Movie.Runtime.Should().NotHaveValue();
            anticipatedMovie.Movie.UpdatedAt.Should().NotHaveValue();
            anticipatedMovie.Movie.Trailer.Should().BeNullOrEmpty();
            anticipatedMovie.Movie.Homepage.Should().BeNullOrEmpty();
            anticipatedMovie.Movie.Rating.Should().NotHaveValue();
            anticipatedMovie.Movie.Votes.Should().NotHaveValue();
            anticipatedMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            anticipatedMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            anticipatedMovie.Movie.Genres.Should().BeNull();
            anticipatedMovie.Movie.Certification.Should().BeNullOrEmpty();
            anticipatedMovie.Movie.CountryCode.Should().BeNullOrEmpty();

            anticipatedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            anticipatedMovie.Year.Should().Be(2015);
            anticipatedMovie.Ids.Should().NotBeNull();
            anticipatedMovie.Ids.Trakt.Should().Be(94024U);
            anticipatedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            anticipatedMovie.Ids.Imdb.Should().Be("tt2488496");
            anticipatedMovie.Ids.Tmdb.Should().Be(140607U);
            anticipatedMovie.Tagline.Should().BeNullOrEmpty();
            anticipatedMovie.Overview.Should().BeNullOrEmpty();
            anticipatedMovie.Released.Should().NotHaveValue();
            anticipatedMovie.Runtime.Should().NotHaveValue();
            anticipatedMovie.UpdatedAt.Should().NotHaveValue();
            anticipatedMovie.Trailer.Should().BeNullOrEmpty();
            anticipatedMovie.Homepage.Should().BeNullOrEmpty();
            anticipatedMovie.Rating.Should().NotHaveValue();
            anticipatedMovie.Votes.Should().NotHaveValue();
            anticipatedMovie.LanguageCode.Should().BeNullOrEmpty();
            anticipatedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            anticipatedMovie.Genres.Should().BeNull();
            anticipatedMovie.Certification.Should().BeNullOrEmpty();
            anticipatedMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMostAnticipatedMovie_From_Full_Json()
        {
            var jsonReader = new MostAnticipatedMovieObjectJsonReader();
            var anticipatedMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktMostAnticipatedMovie;

            anticipatedMovie.Should().NotBeNull();
            anticipatedMovie.ListCount.Should().Be(12805);

            anticipatedMovie.Movie.Should().NotBeNull();
            anticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            anticipatedMovie.Movie.Year.Should().Be(2015);
            anticipatedMovie.Movie.Ids.Should().NotBeNull();
            anticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            anticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            anticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            anticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            anticipatedMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            anticipatedMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            anticipatedMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            anticipatedMovie.Movie.Runtime.Should().Be(136);
            anticipatedMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            anticipatedMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            anticipatedMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            anticipatedMovie.Movie.Rating.Should().Be(8.31988f);
            anticipatedMovie.Movie.Votes.Should().Be(9338);
            anticipatedMovie.Movie.LanguageCode.Should().Be("en");
            anticipatedMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            anticipatedMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            anticipatedMovie.Movie.Certification.Should().Be("PG-13");
            anticipatedMovie.Movie.CountryCode.Should().Be("us");

            anticipatedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            anticipatedMovie.Year.Should().Be(2015);
            anticipatedMovie.Ids.Should().NotBeNull();
            anticipatedMovie.Ids.Trakt.Should().Be(94024U);
            anticipatedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            anticipatedMovie.Ids.Imdb.Should().Be("tt2488496");
            anticipatedMovie.Ids.Tmdb.Should().Be(140607U);
            anticipatedMovie.Tagline.Should().Be("Every generation has a story.");
            anticipatedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            anticipatedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            anticipatedMovie.Runtime.Should().Be(136);
            anticipatedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            anticipatedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            anticipatedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            anticipatedMovie.Rating.Should().Be(8.31988f);
            anticipatedMovie.Votes.Should().Be(9338);
            anticipatedMovie.LanguageCode.Should().Be("en");
            anticipatedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            anticipatedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            anticipatedMovie.Certification.Should().Be("PG-13");
            anticipatedMovie.CountryCode.Should().Be("us");
        }

        private const string MINIMAL_JSON =
            @"{
                ""list_count"": 12805,
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
                ""list_count"": 12805,
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
