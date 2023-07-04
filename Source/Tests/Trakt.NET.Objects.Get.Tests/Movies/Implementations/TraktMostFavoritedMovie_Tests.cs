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
    public class TraktMostFavoritedMovie_Tests
    {
        [Fact]
        public void Test_TraktMostFavoritedMovie_Default_Constructor()
        {
            var favoritedMovie = new TraktMostFavoritedMovie();

            favoritedMovie.UserCount.Should().BeNull();
            favoritedMovie.Movie.Should().BeNull();

            favoritedMovie.Title.Should().BeNull();
            favoritedMovie.Year.Should().BeNull();
            favoritedMovie.Ids.Should().BeNull();
            favoritedMovie.Tagline.Should().BeNull();
            favoritedMovie.Overview.Should().BeNull();
            favoritedMovie.Released.Should().BeNull();
            favoritedMovie.Runtime.Should().BeNull();
            favoritedMovie.UpdatedAt.Should().BeNull();
            favoritedMovie.Trailer.Should().BeNull();
            favoritedMovie.Homepage.Should().BeNull();
            favoritedMovie.Rating.Should().BeNull();
            favoritedMovie.Votes.Should().BeNull();
            favoritedMovie.LanguageCode.Should().BeNull();
            favoritedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            favoritedMovie.Genres.Should().BeNull();
            favoritedMovie.Certification.Should().BeNull();
            favoritedMovie.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostFavoritedMovie_From_Json()
        {
            var jsonReader = new MostFavoritedMovieObjectJsonReader();
            var favoritedMovie = await jsonReader.ReadObjectAsync(JSON) as TraktMostFavoritedMovie;

            favoritedMovie.Should().NotBeNull();
            favoritedMovie.UserCount.Should().Be(76254);

            favoritedMovie.Movie.Should().NotBeNull();
            favoritedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            favoritedMovie.Movie.Year.Should().Be(2015);
            favoritedMovie.Movie.Ids.Should().NotBeNull();
            favoritedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            favoritedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            favoritedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            favoritedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            favoritedMovie.Movie.Tagline.Should().Be("Every generation has a story.");
            favoritedMovie.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            favoritedMovie.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            favoritedMovie.Movie.Runtime.Should().Be(136);
            favoritedMovie.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            favoritedMovie.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            favoritedMovie.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            favoritedMovie.Movie.Rating.Should().Be(8.31988f);
            favoritedMovie.Movie.Votes.Should().Be(9338);
            favoritedMovie.Movie.LanguageCode.Should().Be("en");
            favoritedMovie.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            favoritedMovie.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            favoritedMovie.Movie.Certification.Should().Be("PG-13");
            favoritedMovie.Movie.CountryCode.Should().Be("us");

            favoritedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            favoritedMovie.Year.Should().Be(2015);
            favoritedMovie.Ids.Should().NotBeNull();
            favoritedMovie.Ids.Trakt.Should().Be(94024U);
            favoritedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            favoritedMovie.Ids.Imdb.Should().Be("tt2488496");
            favoritedMovie.Ids.Tmdb.Should().Be(140607U);
            favoritedMovie.Tagline.Should().Be("Every generation has a story.");
            favoritedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            favoritedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            favoritedMovie.Runtime.Should().Be(136);
            favoritedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            favoritedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            favoritedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            favoritedMovie.Rating.Should().Be(8.31988f);
            favoritedMovie.Votes.Should().Be(9338);
            favoritedMovie.LanguageCode.Should().Be("en");
            favoritedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            favoritedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            favoritedMovie.Certification.Should().Be("PG-13");
            favoritedMovie.CountryCode.Should().Be("us");
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
