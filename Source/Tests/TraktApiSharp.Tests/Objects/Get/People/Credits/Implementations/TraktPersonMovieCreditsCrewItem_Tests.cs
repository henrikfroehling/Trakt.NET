namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits.Implementations;
    using TraktApiSharp.Objects.Get.People.Credits.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonMovieCreditsCrewItem_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCreditsCrewItem_Default_Constructor()
        {
            var creditsCrewItem = new TraktPersonMovieCreditsCrewItem();

            creditsCrewItem.Job.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonMovieCreditsCrewItem_From_Minimal_Json()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();
            var creditsCrewItem = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktPersonMovieCreditsCrewItem;

            creditsCrewItem.Should().NotBeNull();
            creditsCrewItem.Job.Should().Be("Director");
            creditsCrewItem.Movie.Should().NotBeNull();
            creditsCrewItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCrewItem.Movie.Year.Should().Be(2015);
            creditsCrewItem.Movie.Ids.Should().NotBeNull();
            creditsCrewItem.Movie.Ids.Trakt.Should().Be(94024U);
            creditsCrewItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCrewItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCrewItem.Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCrewItem.Movie.Tagline.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Overview.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Released.Should().NotHaveValue();
            creditsCrewItem.Movie.Runtime.Should().NotHaveValue();
            creditsCrewItem.Movie.UpdatedAt.Should().NotHaveValue();
            creditsCrewItem.Movie.Trailer.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Homepage.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.Rating.Should().NotHaveValue();
            creditsCrewItem.Movie.Votes.Should().NotHaveValue();
            creditsCrewItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            creditsCrewItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCrewItem.Movie.Genres.Should().BeNull();
            creditsCrewItem.Movie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktPersonMovieCreditsCrewItem_From_Full_Json()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();
            var creditsCrewItem = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktPersonMovieCreditsCrewItem;

            creditsCrewItem.Should().NotBeNull();
            creditsCrewItem.Job.Should().Be("Director");
            creditsCrewItem.Movie.Should().NotBeNull();
            creditsCrewItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCrewItem.Movie.Year.Should().Be(2015);
            creditsCrewItem.Movie.Ids.Should().NotBeNull();
            creditsCrewItem.Movie.Ids.Trakt.Should().Be(94024U);
            creditsCrewItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCrewItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCrewItem.Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCrewItem.Movie.Tagline.Should().Be("Every generation has a story.");
            creditsCrewItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            creditsCrewItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            creditsCrewItem.Movie.Runtime.Should().Be(136);
            creditsCrewItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            creditsCrewItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            creditsCrewItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            creditsCrewItem.Movie.Rating.Should().Be(8.31988f);
            creditsCrewItem.Movie.Votes.Should().Be(9338);
            creditsCrewItem.Movie.LanguageCode.Should().Be("en");
            creditsCrewItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            creditsCrewItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            creditsCrewItem.Movie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""job"": ""Director"",
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
                ""job"": ""Director"",
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
