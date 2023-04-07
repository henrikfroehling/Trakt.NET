namespace TraktNet.Objects.Get.Tests.Recommendations.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.Implementations")]
    public class TraktRecommendedMovie_Tests
    {
        [Fact]
        public void Test_TraktRecommendedMovie_Default_Constructor()
        {
            var recommendedMovie = new TraktRecommendedMovie();

            recommendedMovie.Title.Should().BeNullOrEmpty();
            recommendedMovie.Year.Should().NotHaveValue();
            recommendedMovie.Ids.Should().BeNull();
            recommendedMovie.Tagline.Should().BeNullOrEmpty();
            recommendedMovie.Overview.Should().BeNullOrEmpty();
            recommendedMovie.Released.Should().NotHaveValue();
            recommendedMovie.Runtime.Should().NotHaveValue();
            recommendedMovie.UpdatedAt.Should().NotHaveValue();
            recommendedMovie.Trailer.Should().BeNullOrEmpty();
            recommendedMovie.Homepage.Should().BeNullOrEmpty();
            recommendedMovie.Rating.Should().NotHaveValue();
            recommendedMovie.Votes.Should().NotHaveValue();
            recommendedMovie.LanguageCode.Should().BeNullOrEmpty();
            recommendedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            recommendedMovie.Genres.Should().BeNull();
            recommendedMovie.Certification.Should().BeNullOrEmpty();
            recommendedMovie.CountryCode.Should().BeNullOrEmpty();
            recommendedMovie.Status.Should().BeNull();
            recommendedMovie.RecommendedBy.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecommendedMovie_From_Json()
        {
            var jsonReader = new RecommendedMovieObjectJsonReader();
            var recommendedMovie = await jsonReader.ReadObjectAsync(JSON) as TraktRecommendedMovie;

            recommendedMovie.Should().NotBeNull();
            recommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            recommendedMovie.Year.Should().Be(2015);
            recommendedMovie.Ids.Should().NotBeNull();
            recommendedMovie.Ids.Trakt.Should().Be(94024U);
            recommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            recommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            recommendedMovie.Ids.Tmdb.Should().Be(140607U);
            recommendedMovie.Tagline.Should().Be("Every generation has a story.");
            recommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
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
            recommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            recommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = recommendedMovie.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        private const string JSON =
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
                ""overview"": ""Thirty years after defeating the Galactic Empire,..."",
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
                ""country"": ""us"",
                ""status"": ""released"",
                ""recommended_by"": [
                  {
                    ""user"": {
                      ""username"": ""sean"",
                      ""private"": false,
                      ""name"": ""Sean Rudford"",
                      ""vip"": true,
                      ""vip_ep"": true,
                      ""ids"": {
                        ""slug"": ""sean"",
                        ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                      },
                      ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                      ""location"": ""SF"",
                      ""about"": ""I have all your cassette tapes."",
                      ""gender"": ""male"",
                      ""age"": 35,
                      ""images"": {
                        ""avatar"": {
                          ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                        }
                      },
                      ""vip_og"": true,
                      ""vip_years"": 5,
                      ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
                    },
                    ""notes"": ""Recommended because ...""
                  }
                ]
              }";
    }
}
