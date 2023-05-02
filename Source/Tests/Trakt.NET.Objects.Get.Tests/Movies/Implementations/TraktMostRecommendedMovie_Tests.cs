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
    public class TraktMostRecommendedMovie_Tests
    {
        [Fact]
        public void Test_TraktMostRecommendedMovie_Default_Constructor()
        {
            var recommendedMovie = new TraktMostRecommendedMovie();

            recommendedMovie.UserCount.Should().BeNull();
            recommendedMovie.Movie.Should().BeNull();

            recommendedMovie.Title.Should().BeNull();
            recommendedMovie.Year.Should().BeNull();
            recommendedMovie.Ids.Should().BeNull();
            recommendedMovie.Tagline.Should().BeNull();
            recommendedMovie.Overview.Should().BeNull();
            recommendedMovie.Released.Should().BeNull();
            recommendedMovie.Runtime.Should().BeNull();
            recommendedMovie.UpdatedAt.Should().BeNull();
            recommendedMovie.Trailer.Should().BeNull();
            recommendedMovie.Homepage.Should().BeNull();
            recommendedMovie.Rating.Should().BeNull();
            recommendedMovie.Votes.Should().BeNull();
            recommendedMovie.LanguageCode.Should().BeNull();
            recommendedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            recommendedMovie.Genres.Should().BeNull();
            recommendedMovie.Certification.Should().BeNull();
            recommendedMovie.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostRecommendedMovie_From_Json()
        {
            var jsonReader = new MostRecommendedMovieObjectJsonReader();
            var recommendedMovie = await jsonReader.ReadObjectAsync(JSON) as TraktMostRecommendedMovie;

            recommendedMovie.Should().NotBeNull();
            recommendedMovie.UserCount.Should().Be(76254);

            recommendedMovie.Movie.Should().NotBeNull();
            recommendedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            recommendedMovie.Movie.Year.Should().Be(2015);
            recommendedMovie.Movie.Ids.Should().NotBeNull();
            recommendedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            recommendedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recommendedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            recommendedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            recommendedMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            recommendedMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            recommendedMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            recommendedMovie.Movie.Runtime.Should().Be(136);
            recommendedMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            recommendedMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            recommendedMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            recommendedMovie.Movie.Rating.Should().Be(8.31988f);
            recommendedMovie.Movie.Votes.Should().Be(9338);
            recommendedMovie.Movie.LanguageCode.Should().Be("en");
            recommendedMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            recommendedMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            recommendedMovie.Movie.Certification.Should().Be("PG-13");
            recommendedMovie.Movie.CountryCode.Should().Be("us");

            recommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            recommendedMovie.Year.Should().Be(2015);
            recommendedMovie.Ids.Should().NotBeNull();
            recommendedMovie.Ids.Trakt.Should().Be(94024U);
            recommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            recommendedMovie.Ids.Tmdb.Should().Be(140607U);
            recommendedMovie.Tagline.Should().Be("Every generation has a story.");
            recommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            recommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            recommendedMovie.Runtime.Should().Be(136);
            recommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            recommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            recommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            recommendedMovie.Rating.Should().Be(8.31988f);
            recommendedMovie.Votes.Should().Be(9338);
            recommendedMovie.LanguageCode.Should().Be("en");
            recommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            recommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            recommendedMovie.Certification.Should().Be("PG-13");
            recommendedMovie.CountryCode.Should().Be("us");
        }

        private const string JSON =
            @"{
                ""user_count"": 76254,
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
