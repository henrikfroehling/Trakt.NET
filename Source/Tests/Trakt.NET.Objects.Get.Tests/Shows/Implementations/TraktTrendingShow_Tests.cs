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
    public class TraktTrendingShow_Tests
    {
        [Fact]
        public void Test_TraktTrendingShow_Default_Constructor()
        {
            var trendingShow = new TraktTrendingShow();

            trendingShow.Watchers.Should().NotHaveValue();

            trendingShow.Show.Should().BeNull();
            trendingShow.Title.Should().BeNullOrEmpty();
            trendingShow.Year.Should().NotHaveValue();
            trendingShow.Airs.Should().BeNull();
            trendingShow.AvailableTranslationLanguageCodes.Should().BeNull();
            trendingShow.Ids.Should().BeNull();
            trendingShow.Genres.Should().BeNull();
            trendingShow.Seasons.Should().BeNull();
            trendingShow.Overview.Should().BeNullOrEmpty();
            trendingShow.Tagline.Should().BeNullOrEmpty();
            trendingShow.FirstAired.Should().NotHaveValue();
            trendingShow.Runtime.Should().NotHaveValue();
            trendingShow.Certification.Should().BeNullOrEmpty();
            trendingShow.Network.Should().BeNullOrEmpty();
            trendingShow.CountryCode.Should().BeNullOrEmpty();
            trendingShow.UpdatedAt.Should().NotHaveValue();
            trendingShow.Trailer.Should().BeNullOrEmpty();
            trendingShow.Homepage.Should().BeNullOrEmpty();
            trendingShow.Status.Should().BeNull();
            trendingShow.Rating.Should().NotHaveValue();
            trendingShow.Votes.Should().NotHaveValue();
            trendingShow.LanguageCode.Should().BeNullOrEmpty();
            trendingShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktTrendingShow_From_Minimal_Json()
        {
            var jsonReader = new TrendingShowObjectJsonReader();
            var trendingShow = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktTrendingShow;

            trendingShow.Should().NotBeNull();
            trendingShow.Watchers.Should().Be(35);

            trendingShow.Show.Should().NotBeNull();
            trendingShow.Show.Title.Should().Be("Game of Thrones");
            trendingShow.Show.Year.Should().Be(2011);
            trendingShow.Show.Airs.Should().BeNull();
            trendingShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            trendingShow.Show.Ids.Should().NotBeNull();
            trendingShow.Show.Ids.Trakt.Should().Be(1390U);
            trendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            trendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            trendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            trendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            trendingShow.Show.Ids.TvRage.Should().Be(24493U);
            trendingShow.Show.Genres.Should().BeNull();
            trendingShow.Show.Seasons.Should().BeNull();
            trendingShow.Show.Overview.Should().BeNullOrEmpty();
            trendingShow.Show.Tagline.Should().BeNullOrEmpty();
            trendingShow.Show.FirstAired.Should().NotHaveValue();
            trendingShow.Show.Runtime.Should().NotHaveValue();
            trendingShow.Show.Certification.Should().BeNullOrEmpty();
            trendingShow.Show.Network.Should().BeNullOrEmpty();
            trendingShow.Show.CountryCode.Should().BeNullOrEmpty();
            trendingShow.Show.UpdatedAt.Should().NotHaveValue();
            trendingShow.Show.Trailer.Should().BeNullOrEmpty();
            trendingShow.Show.Homepage.Should().BeNullOrEmpty();
            trendingShow.Show.Status.Should().BeNull();
            trendingShow.Show.Rating.Should().NotHaveValue();
            trendingShow.Show.Votes.Should().NotHaveValue();
            trendingShow.Show.LanguageCode.Should().BeNullOrEmpty();
            trendingShow.Show.AiredEpisodes.Should().NotHaveValue();

            trendingShow.Title.Should().Be("Game of Thrones");
            trendingShow.Year.Should().Be(2011);
            trendingShow.Airs.Should().BeNull();
            trendingShow.AvailableTranslationLanguageCodes.Should().BeNull();
            trendingShow.Ids.Should().NotBeNull();
            trendingShow.Ids.Trakt.Should().Be(1390U);
            trendingShow.Ids.Slug.Should().Be("game-of-thrones");
            trendingShow.Ids.Tvdb.Should().Be(121361U);
            trendingShow.Ids.Imdb.Should().Be("tt0944947");
            trendingShow.Ids.Tmdb.Should().Be(1399U);
            trendingShow.Ids.TvRage.Should().Be(24493U);
            trendingShow.Genres.Should().BeNull();
            trendingShow.Seasons.Should().BeNull();
            trendingShow.Overview.Should().BeNullOrEmpty();
            trendingShow.Tagline.Should().BeNullOrEmpty();
            trendingShow.FirstAired.Should().NotHaveValue();
            trendingShow.Runtime.Should().NotHaveValue();
            trendingShow.Certification.Should().BeNullOrEmpty();
            trendingShow.Network.Should().BeNullOrEmpty();
            trendingShow.CountryCode.Should().BeNullOrEmpty();
            trendingShow.UpdatedAt.Should().NotHaveValue();
            trendingShow.Trailer.Should().BeNullOrEmpty();
            trendingShow.Homepage.Should().BeNullOrEmpty();
            trendingShow.Status.Should().BeNull();
            trendingShow.Rating.Should().NotHaveValue();
            trendingShow.Votes.Should().NotHaveValue();
            trendingShow.LanguageCode.Should().BeNullOrEmpty();
            trendingShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktTrendingShow_From_Full_Json()
        {
            var jsonReader = new TrendingShowObjectJsonReader();
            var trendingShow = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktTrendingShow;

            trendingShow.Should().NotBeNull();
            trendingShow.Watchers.Should().Be(35);

            trendingShow.Show.Should().NotBeNull();
            trendingShow.Show.Title.Should().Be("Game of Thrones");
            trendingShow.Show.Year.Should().Be(2011);
            trendingShow.Show.Airs.Should().NotBeNull();
            trendingShow.Show.Airs.Day.Should().Be("Sunday");
            trendingShow.Show.Airs.Time.Should().Be("21:00");
            trendingShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            trendingShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            trendingShow.Show.Ids.Should().NotBeNull();
            trendingShow.Show.Ids.Trakt.Should().Be(1390U);
            trendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            trendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            trendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            trendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            trendingShow.Show.Ids.TvRage.Should().Be(24493U);
            trendingShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            trendingShow.Show.Seasons.Should().BeNull();
            trendingShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            trendingShow.Show.Tagline.Should().Be("Winter Is Coming");
            trendingShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            trendingShow.Show.Runtime.Should().Be(60);
            trendingShow.Show.Certification.Should().Be("TV-MA");
            trendingShow.Show.Network.Should().Be("HBO");
            trendingShow.Show.CountryCode.Should().Be("us");
            trendingShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            trendingShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            trendingShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            trendingShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            trendingShow.Show.Rating.Should().Be(9.38327f);
            trendingShow.Show.Votes.Should().Be(44773);
            trendingShow.Show.LanguageCode.Should().Be("en");
            trendingShow.Show.AiredEpisodes.Should().Be(50);

            trendingShow.Title.Should().Be("Game of Thrones");
            trendingShow.Year.Should().Be(2011);
            trendingShow.Airs.Should().NotBeNull();
            trendingShow.Airs.Day.Should().Be("Sunday");
            trendingShow.Airs.Time.Should().Be("21:00");
            trendingShow.Airs.TimeZoneId.Should().Be("America/New_York");
            trendingShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            trendingShow.Ids.Should().NotBeNull();
            trendingShow.Ids.Trakt.Should().Be(1390U);
            trendingShow.Ids.Slug.Should().Be("game-of-thrones");
            trendingShow.Ids.Tvdb.Should().Be(121361U);
            trendingShow.Ids.Imdb.Should().Be("tt0944947");
            trendingShow.Ids.Tmdb.Should().Be(1399U);
            trendingShow.Ids.TvRage.Should().Be(24493U);
            trendingShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            trendingShow.Seasons.Should().BeNull();
            trendingShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            trendingShow.Tagline.Should().Be("Winter Is Coming");
            trendingShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            trendingShow.Runtime.Should().Be(60);
            trendingShow.Certification.Should().Be("TV-MA");
            trendingShow.Network.Should().Be("HBO");
            trendingShow.CountryCode.Should().Be("us");
            trendingShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            trendingShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            trendingShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            trendingShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            trendingShow.Rating.Should().Be(9.38327f);
            trendingShow.Votes.Should().Be(44773);
            trendingShow.LanguageCode.Should().Be("en");
            trendingShow.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""watchers"": 35,
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
                  }
                }
              }";

        private const string FULL_JSON =
            @"{
                ""watchers"": 35,
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
                  ""tagline"": ""Winter Is Coming"",
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
