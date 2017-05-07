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
    public class TraktMovie_Tests
    {
        [Fact]
        public void Test_TraktMovie_Implements_ITraktMovie_Interface()
        {
            typeof(TraktMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_TraktMovie_Default_Constructor()
        {
            var movie = new TraktMovie();

            movie.Title.Should().BeNullOrEmpty();
            movie.Year.Should().NotHaveValue();
            movie.Ids.Should().BeNull();
            movie.Tagline.Should().BeNullOrEmpty();
            movie.Overview.Should().BeNullOrEmpty();
            movie.Released.Should().NotHaveValue();
            movie.Runtime.Should().NotHaveValue();
            movie.UpdatedAt.Should().NotHaveValue();
            movie.Trailer.Should().BeNullOrEmpty();
            movie.Homepage.Should().BeNullOrEmpty();
            movie.Rating.Should().NotHaveValue();
            movie.Votes.Should().NotHaveValue();
            movie.LanguageCode.Should().BeNullOrEmpty();
            movie.AvailableTranslationLanguageCodes.Should().BeNull();
            movie.Genres.Should().BeNull();
            movie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMovie_From_Minimal_Json()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();
            var movie = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktMovie;

            movie.Should().NotBeNull();
            movie.Title.Should().Be("Star Wars: The Force Awakens");
            movie.Year.Should().Be(2015);
            movie.Ids.Should().NotBeNull();
            movie.Ids.Trakt.Should().Be(94024U);
            movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movie.Ids.Imdb.Should().Be("tt2488496");
            movie.Ids.Tmdb.Should().Be(140607U);
            movie.Tagline.Should().BeNullOrEmpty();
            movie.Overview.Should().BeNullOrEmpty();
            movie.Released.Should().NotHaveValue();
            movie.Runtime.Should().NotHaveValue();
            movie.UpdatedAt.Should().NotHaveValue();
            movie.Trailer.Should().BeNullOrEmpty();
            movie.Homepage.Should().BeNullOrEmpty();
            movie.Rating.Should().NotHaveValue();
            movie.Votes.Should().NotHaveValue();
            movie.LanguageCode.Should().BeNullOrEmpty();
            movie.AvailableTranslationLanguageCodes.Should().BeNull();
            movie.Genres.Should().BeNull();
            movie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMovie_From_Full_Json()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();
            var movie = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktMovie;

            movie.Should().NotBeNull();
            movie.Title.Should().Be("Star Wars: The Force Awakens");
            movie.Year.Should().Be(2015);
            movie.Ids.Should().NotBeNull();
            movie.Ids.Trakt.Should().Be(94024U);
            movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movie.Ids.Imdb.Should().Be("tt2488496");
            movie.Ids.Tmdb.Should().Be(140607U);
            movie.Tagline.Should().Be("Every generation has a story.");
            movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            movie.Runtime.Should().Be(136);
            movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            movie.Rating.Should().Be(8.31988f);
            movie.Votes.Should().Be(9338);
            movie.LanguageCode.Should().Be("en");
            movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            movie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string FULL_JSON =
            @"{
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
              }";
    }
}
