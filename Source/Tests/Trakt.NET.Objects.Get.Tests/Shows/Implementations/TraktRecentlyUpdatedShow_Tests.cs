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
    public class TraktRecentlyUpdatedShow_Tests
    {
        [Fact]
        public void Test_TraktRecentlyUpdatedShow_Default_Constructor()
        {
            var recentlyUpdatedShow = new TraktRecentlyUpdatedShow();

            recentlyUpdatedShow.RecentlyUpdatedAt.Should().NotHaveValue();

            recentlyUpdatedShow.Show.Should().BeNull();
            recentlyUpdatedShow.Title.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Year.Should().NotHaveValue();
            recentlyUpdatedShow.Airs.Should().BeNull();
            recentlyUpdatedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            recentlyUpdatedShow.Ids.Should().BeNull();
            recentlyUpdatedShow.Genres.Should().BeNull();
            recentlyUpdatedShow.Seasons.Should().BeNull();
            recentlyUpdatedShow.Overview.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Tagline.Should().BeNullOrEmpty();
            recentlyUpdatedShow.FirstAired.Should().NotHaveValue();
            recentlyUpdatedShow.Runtime.Should().NotHaveValue();
            recentlyUpdatedShow.Certification.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Network.Should().BeNullOrEmpty();
            recentlyUpdatedShow.CountryCode.Should().BeNullOrEmpty();
            recentlyUpdatedShow.UpdatedAt.Should().NotHaveValue();
            recentlyUpdatedShow.Trailer.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Homepage.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Status.Should().BeNull();
            recentlyUpdatedShow.Rating.Should().NotHaveValue();
            recentlyUpdatedShow.Votes.Should().NotHaveValue();
            recentlyUpdatedShow.LanguageCode.Should().BeNullOrEmpty();
            recentlyUpdatedShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedShow_From_Minimal_Json()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();
            var recentlyUpdatedShow = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktRecentlyUpdatedShow;

            recentlyUpdatedShow.Should().NotBeNull();
            recentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());

            recentlyUpdatedShow.Show.Should().NotBeNull();
            recentlyUpdatedShow.Show.Title.Should().Be("Game of Thrones");
            recentlyUpdatedShow.Show.Year.Should().Be(2011);
            recentlyUpdatedShow.Show.Airs.Should().BeNull();
            recentlyUpdatedShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            recentlyUpdatedShow.Show.Ids.Should().NotBeNull();
            recentlyUpdatedShow.Show.Ids.Trakt.Should().Be(1390U);
            recentlyUpdatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            recentlyUpdatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            recentlyUpdatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            recentlyUpdatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            recentlyUpdatedShow.Show.Ids.TvRage.Should().Be(24493U);
            recentlyUpdatedShow.Show.Genres.Should().BeNull();
            recentlyUpdatedShow.Show.Seasons.Should().BeNull();
            recentlyUpdatedShow.Show.Overview.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.Tagline.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.FirstAired.Should().NotHaveValue();
            recentlyUpdatedShow.Show.Runtime.Should().NotHaveValue();
            recentlyUpdatedShow.Show.Certification.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.Network.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.CountryCode.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.UpdatedAt.Should().NotHaveValue();
            recentlyUpdatedShow.Show.Trailer.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.Homepage.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.Status.Should().BeNull();
            recentlyUpdatedShow.Show.Rating.Should().NotHaveValue();
            recentlyUpdatedShow.Show.Votes.Should().NotHaveValue();
            recentlyUpdatedShow.Show.LanguageCode.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Show.AiredEpisodes.Should().NotHaveValue();

            recentlyUpdatedShow.Title.Should().Be("Game of Thrones");
            recentlyUpdatedShow.Year.Should().Be(2011);
            recentlyUpdatedShow.Airs.Should().BeNull();
            recentlyUpdatedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            recentlyUpdatedShow.Ids.Should().NotBeNull();
            recentlyUpdatedShow.Ids.Trakt.Should().Be(1390U);
            recentlyUpdatedShow.Ids.Slug.Should().Be("game-of-thrones");
            recentlyUpdatedShow.Ids.Tvdb.Should().Be(121361U);
            recentlyUpdatedShow.Ids.Imdb.Should().Be("tt0944947");
            recentlyUpdatedShow.Ids.Tmdb.Should().Be(1399U);
            recentlyUpdatedShow.Ids.TvRage.Should().Be(24493U);
            recentlyUpdatedShow.Genres.Should().BeNull();
            recentlyUpdatedShow.Seasons.Should().BeNull();
            recentlyUpdatedShow.Overview.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Tagline.Should().BeNullOrEmpty();
            recentlyUpdatedShow.FirstAired.Should().NotHaveValue();
            recentlyUpdatedShow.Runtime.Should().NotHaveValue();
            recentlyUpdatedShow.Certification.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Network.Should().BeNullOrEmpty();
            recentlyUpdatedShow.CountryCode.Should().BeNullOrEmpty();
            recentlyUpdatedShow.UpdatedAt.Should().NotHaveValue();
            recentlyUpdatedShow.Trailer.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Homepage.Should().BeNullOrEmpty();
            recentlyUpdatedShow.Status.Should().BeNull();
            recentlyUpdatedShow.Rating.Should().NotHaveValue();
            recentlyUpdatedShow.Votes.Should().NotHaveValue();
            recentlyUpdatedShow.LanguageCode.Should().BeNullOrEmpty();
            recentlyUpdatedShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedShow_From_Full_Json()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();
            var recentlyUpdatedShow = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktRecentlyUpdatedShow;

            recentlyUpdatedShow.Should().NotBeNull();
            recentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());

            recentlyUpdatedShow.Show.Should().NotBeNull();
            recentlyUpdatedShow.Show.Title.Should().Be("Game of Thrones");
            recentlyUpdatedShow.Show.Year.Should().Be(2011);
            recentlyUpdatedShow.Show.Airs.Should().NotBeNull();
            recentlyUpdatedShow.Show.Airs.Day.Should().Be("Sunday");
            recentlyUpdatedShow.Show.Airs.Time.Should().Be("21:00");
            recentlyUpdatedShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            recentlyUpdatedShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            recentlyUpdatedShow.Show.Ids.Should().NotBeNull();
            recentlyUpdatedShow.Show.Ids.Trakt.Should().Be(1390U);
            recentlyUpdatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            recentlyUpdatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            recentlyUpdatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            recentlyUpdatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            recentlyUpdatedShow.Show.Ids.TvRage.Should().Be(24493U);
            recentlyUpdatedShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            recentlyUpdatedShow.Show.Seasons.Should().BeNull();
            recentlyUpdatedShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            recentlyUpdatedShow.Show.Tagline.Should().Be("Winter Is Coming");
            recentlyUpdatedShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            recentlyUpdatedShow.Show.Runtime.Should().Be(60);
            recentlyUpdatedShow.Show.Certification.Should().Be("TV-MA");
            recentlyUpdatedShow.Show.Network.Should().Be("HBO");
            recentlyUpdatedShow.Show.CountryCode.Should().Be("us");
            recentlyUpdatedShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            recentlyUpdatedShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            recentlyUpdatedShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            recentlyUpdatedShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            recentlyUpdatedShow.Show.Rating.Should().Be(9.38327f);
            recentlyUpdatedShow.Show.Votes.Should().Be(44773);
            recentlyUpdatedShow.Show.LanguageCode.Should().Be("en");
            recentlyUpdatedShow.Show.AiredEpisodes.Should().Be(50);

            recentlyUpdatedShow.Title.Should().Be("Game of Thrones");
            recentlyUpdatedShow.Year.Should().Be(2011);
            recentlyUpdatedShow.Airs.Should().NotBeNull();
            recentlyUpdatedShow.Airs.Day.Should().Be("Sunday");
            recentlyUpdatedShow.Airs.Time.Should().Be("21:00");
            recentlyUpdatedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            recentlyUpdatedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            recentlyUpdatedShow.Ids.Should().NotBeNull();
            recentlyUpdatedShow.Ids.Trakt.Should().Be(1390U);
            recentlyUpdatedShow.Ids.Slug.Should().Be("game-of-thrones");
            recentlyUpdatedShow.Ids.Tvdb.Should().Be(121361U);
            recentlyUpdatedShow.Ids.Imdb.Should().Be("tt0944947");
            recentlyUpdatedShow.Ids.Tmdb.Should().Be(1399U);
            recentlyUpdatedShow.Ids.TvRage.Should().Be(24493U);
            recentlyUpdatedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            recentlyUpdatedShow.Seasons.Should().BeNull();
            recentlyUpdatedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            recentlyUpdatedShow.Tagline.Should().Be("Winter Is Coming");
            recentlyUpdatedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            recentlyUpdatedShow.Runtime.Should().Be(60);
            recentlyUpdatedShow.Certification.Should().Be("TV-MA");
            recentlyUpdatedShow.Network.Should().Be("HBO");
            recentlyUpdatedShow.CountryCode.Should().Be("us");
            recentlyUpdatedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            recentlyUpdatedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            recentlyUpdatedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            recentlyUpdatedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            recentlyUpdatedShow.Rating.Should().Be(9.38327f);
            recentlyUpdatedShow.Votes.Should().Be(44773);
            recentlyUpdatedShow.LanguageCode.Should().Be("en");
            recentlyUpdatedShow.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                  ""updated_at"": ""2016-03-31T01:29:13Z"",
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
