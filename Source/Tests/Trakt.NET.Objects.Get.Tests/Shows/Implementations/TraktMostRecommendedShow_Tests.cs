namespace TraktNet.Objects.Get.Tests.Shows.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.Implementations")]
    public class TraktMostRecommendedShow_Tests
    {
        [Fact]
        public void Test_TraktMostRecommendedShow_Default_Constructor()
        {
            var recommendedShow = new TraktMostRecommendedShow();

            recommendedShow.UserCount.Should().BeNull();
            recommendedShow.Show.Should().BeNull();

            recommendedShow.Title.Should().BeNull();
            recommendedShow.Year.Should().BeNull();
            recommendedShow.Airs.Should().BeNull();
            recommendedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            recommendedShow.Ids.Should().BeNull();
            recommendedShow.Genres.Should().BeNull();
            recommendedShow.Seasons.Should().BeNull();
            recommendedShow.Overview.Should().BeNull();
            recommendedShow.FirstAired.Should().BeNull();
            recommendedShow.Runtime.Should().BeNull();
            recommendedShow.Certification.Should().BeNull();
            recommendedShow.Network.Should().BeNull();
            recommendedShow.CountryCode.Should().BeNull();
            recommendedShow.UpdatedAt.Should().BeNull();
            recommendedShow.Trailer.Should().BeNull();
            recommendedShow.Homepage.Should().BeNull();
            recommendedShow.Status.Should().BeNull();
            recommendedShow.Rating.Should().BeNull();
            recommendedShow.Votes.Should().BeNull();
            recommendedShow.LanguageCode.Should().BeNull();
            recommendedShow.AiredEpisodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostRecommendedShow_From_Json()
        {
            var jsonReader = new MostRecommendedShowObjectJsonReader();
            var recommendedShow = await jsonReader.ReadObjectAsync(JSON) as TraktMostRecommendedShow;

            recommendedShow.Should().NotBeNull();
            recommendedShow.UserCount.Should().Be(155291);

            recommendedShow.Show.Should().NotBeNull();
            recommendedShow.Show.Title.Should().Be("Game of Thrones");
            recommendedShow.Show.Year.Should().Be(2011);
            recommendedShow.Show.Airs.Should().NotBeNull();
            recommendedShow.Show.Airs.Day.Should().Be("Sunday");
            recommendedShow.Show.Airs.Time.Should().Be("21:00");
            recommendedShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            recommendedShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            recommendedShow.Show.Ids.Should().NotBeNull();
            recommendedShow.Show.Ids.Trakt.Should().Be(1390U);
            recommendedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            recommendedShow.Show.Ids.Tvdb.Should().Be(121361U);
            recommendedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            recommendedShow.Show.Ids.Tmdb.Should().Be(1399U);
            recommendedShow.Show.Ids.TvRage.Should().Be(24493U);
            recommendedShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            recommendedShow.Show.Seasons.Should().BeNull();
            recommendedShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            recommendedShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            recommendedShow.Show.Runtime.Should().Be(60);
            recommendedShow.Show.Certification.Should().Be("TV-MA");
            recommendedShow.Show.Network.Should().Be("HBO");
            recommendedShow.Show.CountryCode.Should().Be("us");
            recommendedShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            recommendedShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            recommendedShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            recommendedShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            recommendedShow.Show.Rating.Should().Be(9.38327f);
            recommendedShow.Show.Votes.Should().Be(44773);
            recommendedShow.Show.LanguageCode.Should().Be("en");
            recommendedShow.Show.AiredEpisodes.Should().Be(50);

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
            recommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
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
        }

        private const string JSON =
            @"{
                ""user_count"": 155291,
                ""show"": {
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
                  ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
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
                  ""aired_episodes"": 50
                }
              }";
    }
}
