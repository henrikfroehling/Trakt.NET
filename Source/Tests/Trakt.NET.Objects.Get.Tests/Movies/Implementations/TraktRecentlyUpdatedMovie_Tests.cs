namespace TraktNet.Objects.Get.Tests.Movies.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktRecentlyUpdatedMovie_Tests
    {
        [Fact]
        public void Test_TraktRecentlyUpdatedMovie_Default_Constructor()
        {
            var recentlyUpdatedMovie = new TraktRecentlyUpdatedMovie();

            recentlyUpdatedMovie.RecentlyUpdatedAt.Should().NotHaveValue();

            recentlyUpdatedMovie.Movie.Should().BeNull();
            recentlyUpdatedMovie.Title.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Year.Should().NotHaveValue();
            recentlyUpdatedMovie.Ids.Should().BeNull();
            recentlyUpdatedMovie.Tagline.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Overview.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Released.Should().NotHaveValue();
            recentlyUpdatedMovie.Runtime.Should().NotHaveValue();
            recentlyUpdatedMovie.UpdatedAt.Should().NotHaveValue();
            recentlyUpdatedMovie.Trailer.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Homepage.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Rating.Should().NotHaveValue();
            recentlyUpdatedMovie.Votes.Should().NotHaveValue();
            recentlyUpdatedMovie.LanguageCode.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            recentlyUpdatedMovie.Genres.Should().BeNull();
            recentlyUpdatedMovie.Certification.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovie_From_Minimal_Json()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();
            var recentlyUpdatedMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktRecentlyUpdatedMovie;

            recentlyUpdatedMovie.Should().NotBeNull();
            recentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());

            recentlyUpdatedMovie.Movie.Should().NotBeNull();
            recentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            recentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            recentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            recentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            recentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            recentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            recentlyUpdatedMovie.Movie.Tagline.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Movie.Overview.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Movie.Released.Should().NotHaveValue();
            recentlyUpdatedMovie.Movie.Runtime.Should().NotHaveValue();
            recentlyUpdatedMovie.Movie.UpdatedAt.Should().NotHaveValue();
            recentlyUpdatedMovie.Movie.Trailer.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Movie.Homepage.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Movie.Rating.Should().NotHaveValue();
            recentlyUpdatedMovie.Movie.Votes.Should().NotHaveValue();
            recentlyUpdatedMovie.Movie.LanguageCode.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            recentlyUpdatedMovie.Movie.Genres.Should().BeNull();
            recentlyUpdatedMovie.Movie.Certification.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Movie.CountryCode.Should().BeNullOrEmpty();

            recentlyUpdatedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            recentlyUpdatedMovie.Year.Should().Be(2015);
            recentlyUpdatedMovie.Ids.Should().NotBeNull();
            recentlyUpdatedMovie.Ids.Trakt.Should().Be(94024U);
            recentlyUpdatedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recentlyUpdatedMovie.Ids.Imdb.Should().Be("tt2488496");
            recentlyUpdatedMovie.Ids.Tmdb.Should().Be(140607U);
            recentlyUpdatedMovie.Tagline.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Overview.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Released.Should().NotHaveValue();
            recentlyUpdatedMovie.Runtime.Should().NotHaveValue();
            recentlyUpdatedMovie.UpdatedAt.Should().NotHaveValue();
            recentlyUpdatedMovie.Trailer.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Homepage.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.Rating.Should().NotHaveValue();
            recentlyUpdatedMovie.Votes.Should().NotHaveValue();
            recentlyUpdatedMovie.LanguageCode.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            recentlyUpdatedMovie.Genres.Should().BeNull();
            recentlyUpdatedMovie.Certification.Should().BeNullOrEmpty();
            recentlyUpdatedMovie.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovie_From_Full_Json()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();
            var recentlyUpdatedMovie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktRecentlyUpdatedMovie;

            recentlyUpdatedMovie.Should().NotBeNull();
            recentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());

            recentlyUpdatedMovie.Movie.Should().NotBeNull();
            recentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            recentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            recentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            recentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            recentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            recentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            recentlyUpdatedMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            recentlyUpdatedMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            recentlyUpdatedMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            recentlyUpdatedMovie.Movie.Runtime.Should().Be(136);
            recentlyUpdatedMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            recentlyUpdatedMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            recentlyUpdatedMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            recentlyUpdatedMovie.Movie.Rating.Should().Be(8.31988f);
            recentlyUpdatedMovie.Movie.Votes.Should().Be(9338);
            recentlyUpdatedMovie.Movie.LanguageCode.Should().Be("en");
            recentlyUpdatedMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            recentlyUpdatedMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            recentlyUpdatedMovie.Movie.Certification.Should().Be("PG-13");
            recentlyUpdatedMovie.Movie.CountryCode.Should().Be("us");

            recentlyUpdatedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            recentlyUpdatedMovie.Year.Should().Be(2015);
            recentlyUpdatedMovie.Ids.Should().NotBeNull();
            recentlyUpdatedMovie.Ids.Trakt.Should().Be(94024U);
            recentlyUpdatedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recentlyUpdatedMovie.Ids.Imdb.Should().Be("tt2488496");
            recentlyUpdatedMovie.Ids.Tmdb.Should().Be(140607U);
            recentlyUpdatedMovie.Tagline.Should().Be("Every generation has a story.");
            recentlyUpdatedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            recentlyUpdatedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            recentlyUpdatedMovie.Runtime.Should().Be(136);
            recentlyUpdatedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            recentlyUpdatedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            recentlyUpdatedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            recentlyUpdatedMovie.Rating.Should().Be(8.31988f);
            recentlyUpdatedMovie.Votes.Should().Be(9338);
            recentlyUpdatedMovie.LanguageCode.Should().Be("en");
            recentlyUpdatedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            recentlyUpdatedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            recentlyUpdatedMovie.Certification.Should().Be("PG-13");
            recentlyUpdatedMovie.CountryCode.Should().Be("us");
        }

        private const string MINIMAL_JSON =
            @"{
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                  ""updated_at"": ""2016-03-31T01:29:13Z"",
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
