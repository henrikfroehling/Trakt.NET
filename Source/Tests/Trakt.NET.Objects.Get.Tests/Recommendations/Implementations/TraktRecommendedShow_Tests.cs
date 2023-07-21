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
    public class TraktRecommendedShow_Tests
    {
        [Fact]
        public void Test_TraktRecommendedShow_Default_Constructor()
        {
            var recommendedShow = new TraktRecommendedShow();

            recommendedShow.Title.Should().BeNullOrEmpty();
            recommendedShow.Year.Should().NotHaveValue();
            recommendedShow.Airs.Should().BeNull();
            recommendedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            recommendedShow.Ids.Should().BeNull();
            recommendedShow.Genres.Should().BeNull();
            recommendedShow.Seasons.Should().BeNull();
            recommendedShow.Overview.Should().BeNullOrEmpty();
            recommendedShow.FirstAired.Should().NotHaveValue();
            recommendedShow.Runtime.Should().NotHaveValue();
            recommendedShow.Certification.Should().BeNullOrEmpty();
            recommendedShow.Network.Should().BeNullOrEmpty();
            recommendedShow.CountryCode.Should().BeNullOrEmpty();
            recommendedShow.UpdatedAt.Should().NotHaveValue();
            recommendedShow.Trailer.Should().BeNullOrEmpty();
            recommendedShow.Homepage.Should().BeNullOrEmpty();
            recommendedShow.Status.Should().BeNull();
            recommendedShow.Rating.Should().NotHaveValue();
            recommendedShow.Votes.Should().NotHaveValue();
            recommendedShow.LanguageCode.Should().BeNullOrEmpty();
            recommendedShow.AiredEpisodes.Should().NotHaveValue();
            recommendedShow.FavoritedBy.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecommendedShow_From_Json()
        {
            var jsonReader = new RecommendedShowObjectJsonReader();
            var recommendedShow = await jsonReader.ReadObjectAsync(JSON) as TraktRecommendedShow;

            recommendedShow.Should().NotBeNull();
            recommendedShow.Title.Should().Be("Game of Thrones");
            recommendedShow.Year.Should().Be(2011);
            recommendedShow.Airs.Should().NotBeNull();
            recommendedShow.Airs.Day.Should().Be("Sunday");
            recommendedShow.Airs.Time.Should().Be("21:00");
            recommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            recommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            recommendedShow.Ids.Should().NotBeNull();
            recommendedShow.Ids.Trakt.Should().Be(1390U);
            recommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            recommendedShow.Ids.Tvdb.Should().Be(121361U);
            recommendedShow.Ids.Imdb.Should().Be("tt0944947");
            recommendedShow.Ids.Tmdb.Should().Be(1399U);
            recommendedShow.Ids.TvRage.Should().Be(24493U);
            recommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            recommendedShow.Seasons.Should().BeNull();
            recommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            recommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            recommendedShow.Runtime.Should().Be(60);
            recommendedShow.Certification.Should().Be("TV-MA");
            recommendedShow.Network.Should().Be("HBO");
            recommendedShow.CountryCode.Should().Be("us");
            recommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            recommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            recommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            recommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            recommendedShow.Rating.Should().Be(9.38327f);
            recommendedShow.Votes.Should().Be(44773);
            recommendedShow.LanguageCode.Should().Be("en");
            recommendedShow.AiredEpisodes.Should().Be(50);

            recommendedShow.FavoritedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktFavoritedBy favoritedBy = recommendedShow.FavoritedBy.First();

            favoritedBy.Should().NotBeNull();
            favoritedBy.User.Should().NotBeNull();
            favoritedBy.User.Username.Should().Be("sean");
            favoritedBy.User.IsPrivate.Should().BeFalse();
            favoritedBy.User.Name.Should().Be("Sean Rudford");
            favoritedBy.User.IsVIP.Should().BeTrue();
            favoritedBy.User.IsVIP_EP.Should().BeTrue();
            favoritedBy.User.Ids.Should().NotBeNull();
            favoritedBy.User.Ids.Slug.Should().Be("sean");
            favoritedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            favoritedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            favoritedBy.User.Location.Should().Be("SF");
            favoritedBy.User.About.Should().Be("I have all your cassette tapes.");
            favoritedBy.User.Gender.Should().Be("male");
            favoritedBy.User.Age.Should().Be(35);
            favoritedBy.User.Images.Should().NotBeNull();
            favoritedBy.User.Images.Avatar.Should().NotBeNull();
            favoritedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            favoritedBy.User.IsVIP_OG.Should().BeTrue();
            favoritedBy.User.VIP_Years.Should().Be(5);
            favoritedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            favoritedBy.Notes.Should().Be("Favorited because ...");
        }

        private const string JSON =
            @"{
                ""title"": ""Game of Thrones"",
                ""year"": 2011,
                ""ids"": {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                ""overview"": ""Seven noble families fight for control of the mythical land of Westeros."",
                ""first_aired"": ""2011-04-17T07:00:00Z"",
                ""airs"": {
                  ""day"": ""Sunday"",
                  ""time"": ""21:00"",
                  ""timezone"": ""America/New_York""
                },
                ""runtime"": 60,
                ""certification"": ""TV-MA"",
                ""network"": ""HBO"",
                ""country"": ""us"",
                ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                ""status"": ""returning series"",
                ""rating"": 9.38327,
                ""votes"": 44773,
                ""updated_at"": ""2016-04-06T10:39:11Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""fr"",
                  ""it"",
                  ""de""
                ],
                ""genres"": [
                  ""drama"",
                  ""fantasy"",
                  ""science-fiction"",
                  ""action"",
                  ""adventure""
                ],
                ""aired_episodes"": 50,
                ""favorited_by"": [
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
                    ""notes"": ""Favorited because ...""
                  }
                ]
              }";
    }
}
