namespace TraktApiSharp.Tests.Objects.Get.People.Credits
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using Xunit;

    [Category("Objects.Get.People.Credits")]
    public class TraktPersonMovieCreditsCastItem_Tests
    {
        [Fact]
        public void Test_TraktPersonMovieCreditsCastItem_Default_Constructor()
        {
            var creditsCastItem = new TraktPersonMovieCreditsCastItem();

            creditsCastItem.Character.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonMovieCreditsCastItem_From_Minimal_Json()
        {
            var creditsCastItem = JsonConvert.DeserializeObject<TraktPersonMovieCreditsCastItem>(MINIMAL_JSON);

            creditsCastItem.Should().NotBeNull();
            creditsCastItem.Character.Should().Be("Joe Brody");
            creditsCastItem.Movie.Should().NotBeNull();
            creditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCastItem.Movie.Year.Should().Be(2015);
            creditsCastItem.Movie.Ids.Should().NotBeNull();
            creditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
            creditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCastItem.Movie.Tagline.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Overview.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Released.Should().NotHaveValue();
            creditsCastItem.Movie.Runtime.Should().NotHaveValue();
            creditsCastItem.Movie.UpdatedAt.Should().NotHaveValue();
            creditsCastItem.Movie.Trailer.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Homepage.Should().BeNullOrEmpty();
            creditsCastItem.Movie.Rating.Should().NotHaveValue();
            creditsCastItem.Movie.Votes.Should().NotHaveValue();
            creditsCastItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            creditsCastItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCastItem.Movie.Genres.Should().BeNull();
            creditsCastItem.Movie.Certification.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktPersonMovieCreditsCastItem_From_Full_Json()
        {
            var creditsCastItem = JsonConvert.DeserializeObject<TraktPersonMovieCreditsCastItem>(FULL_JSON);

            creditsCastItem.Should().NotBeNull();
            creditsCastItem.Character.Should().Be("Joe Brody");
            creditsCastItem.Movie.Should().NotBeNull();
            creditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            creditsCastItem.Movie.Year.Should().Be(2015);
            creditsCastItem.Movie.Ids.Should().NotBeNull();
            creditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
            creditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            creditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            creditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
            creditsCastItem.Movie.Tagline.Should().Be("Every generation has a story.");
            creditsCastItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            creditsCastItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            creditsCastItem.Movie.Runtime.Should().Be(136);
            creditsCastItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            creditsCastItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            creditsCastItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            creditsCastItem.Movie.Rating.Should().Be(8.31988f);
            creditsCastItem.Movie.Votes.Should().Be(9338);
            creditsCastItem.Movie.LanguageCode.Should().Be("en");
            creditsCastItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            creditsCastItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            creditsCastItem.Movie.Certification.Should().Be("PG-13");
        }

        private const string MINIMAL_JSON =
            @"{
                ""character"": ""Joe Brody"",
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
                ""character"": ""Joe Brody"",
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
