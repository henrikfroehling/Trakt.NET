namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktMostPWCShow_Tests
    {
        [Fact]
        public void Test_TraktMostPWCShow_Implements_ITraktMostPWCShow_Interface()
        {
            typeof(TraktMostPWCShow).GetInterfaces().Should().Contain(typeof(ITraktMostPWCShow));
        }

        [Fact]
        public void Test_TraktMostPWCShow_Default_Constructor()
        {
            var mostPWCShow = new TraktMostPWCShow();

            mostPWCShow.WatcherCount.Should().NotHaveValue();
            mostPWCShow.PlayCount.Should().NotHaveValue();
            mostPWCShow.CollectedCount.Should().NotHaveValue();
            mostPWCShow.CollectorCount.Should().NotHaveValue();

            mostPWCShow.Show.Should().BeNull();
            mostPWCShow.Title.Should().BeNullOrEmpty();
            mostPWCShow.Year.Should().NotHaveValue();
            mostPWCShow.Airs.Should().BeNull();
            mostPWCShow.AvailableTranslationLanguageCodes.Should().BeNull();
            mostPWCShow.Ids.Should().BeNull();
            mostPWCShow.Genres.Should().BeNull();
            mostPWCShow.Seasons.Should().BeNull();
            mostPWCShow.Overview.Should().BeNullOrEmpty();
            mostPWCShow.FirstAired.Should().NotHaveValue();
            mostPWCShow.Runtime.Should().NotHaveValue();
            mostPWCShow.Certification.Should().BeNullOrEmpty();
            mostPWCShow.Network.Should().BeNullOrEmpty();
            mostPWCShow.CountryCode.Should().BeNullOrEmpty();
            mostPWCShow.UpdatedAt.Should().NotHaveValue();
            mostPWCShow.Trailer.Should().BeNullOrEmpty();
            mostPWCShow.Homepage.Should().BeNullOrEmpty();
            mostPWCShow.Status.Should().BeNull();
            mostPWCShow.Rating.Should().NotHaveValue();
            mostPWCShow.Votes.Should().NotHaveValue();
            mostPWCShow.LanguageCode.Should().BeNullOrEmpty();
            mostPWCShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktMostPWCShow_From_Minimal_Json()
        {
            var jsonReader = new TraktMostPWCShowObjectJsonReader();
            var mostPWCShow = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktMostPWCShow;

            mostPWCShow.Should().NotBeNull();
            mostPWCShow.WatcherCount.Should().Be(4992);
            mostPWCShow.PlayCount.Should().Be(7100);
            mostPWCShow.CollectedCount.Should().Be(1348);
            mostPWCShow.CollectorCount.Should().Be(7964);

            mostPWCShow.Show.Should().NotBeNull();
            mostPWCShow.Show.Title.Should().Be("Game of Thrones");
            mostPWCShow.Show.Year.Should().Be(2011);
            mostPWCShow.Show.Airs.Should().BeNull();
            mostPWCShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            mostPWCShow.Show.Ids.Should().NotBeNull();
            mostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
            mostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            mostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
            mostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
            mostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
            mostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            mostPWCShow.Show.Genres.Should().BeNull();
            mostPWCShow.Show.Seasons.Should().BeNull();
            mostPWCShow.Show.Overview.Should().BeNullOrEmpty();
            mostPWCShow.Show.FirstAired.Should().NotHaveValue();
            mostPWCShow.Show.Runtime.Should().NotHaveValue();
            mostPWCShow.Show.Certification.Should().BeNullOrEmpty();
            mostPWCShow.Show.Network.Should().BeNullOrEmpty();
            mostPWCShow.Show.CountryCode.Should().BeNullOrEmpty();
            mostPWCShow.Show.UpdatedAt.Should().NotHaveValue();
            mostPWCShow.Show.Trailer.Should().BeNullOrEmpty();
            mostPWCShow.Show.Homepage.Should().BeNullOrEmpty();
            mostPWCShow.Show.Status.Should().BeNull();
            mostPWCShow.Show.Rating.Should().NotHaveValue();
            mostPWCShow.Show.Votes.Should().NotHaveValue();
            mostPWCShow.Show.LanguageCode.Should().BeNullOrEmpty();
            mostPWCShow.Show.AiredEpisodes.Should().NotHaveValue();

            mostPWCShow.Title.Should().Be("Game of Thrones");
            mostPWCShow.Year.Should().Be(2011);
            mostPWCShow.Airs.Should().BeNull();
            mostPWCShow.AvailableTranslationLanguageCodes.Should().BeNull();
            mostPWCShow.Ids.Should().NotBeNull();
            mostPWCShow.Ids.Trakt.Should().Be(1390U);
            mostPWCShow.Ids.Slug.Should().Be("game-of-thrones");
            mostPWCShow.Ids.Tvdb.Should().Be(121361U);
            mostPWCShow.Ids.Imdb.Should().Be("tt0944947");
            mostPWCShow.Ids.Tmdb.Should().Be(1399U);
            mostPWCShow.Ids.TvRage.Should().Be(24493U);
            mostPWCShow.Genres.Should().BeNull();
            mostPWCShow.Seasons.Should().BeNull();
            mostPWCShow.Overview.Should().BeNullOrEmpty();
            mostPWCShow.FirstAired.Should().NotHaveValue();
            mostPWCShow.Runtime.Should().NotHaveValue();
            mostPWCShow.Certification.Should().BeNullOrEmpty();
            mostPWCShow.Network.Should().BeNullOrEmpty();
            mostPWCShow.CountryCode.Should().BeNullOrEmpty();
            mostPWCShow.UpdatedAt.Should().NotHaveValue();
            mostPWCShow.Trailer.Should().BeNullOrEmpty();
            mostPWCShow.Homepage.Should().BeNullOrEmpty();
            mostPWCShow.Status.Should().BeNull();
            mostPWCShow.Rating.Should().NotHaveValue();
            mostPWCShow.Votes.Should().NotHaveValue();
            mostPWCShow.LanguageCode.Should().BeNullOrEmpty();
            mostPWCShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktMostPWCShow_From_Full_Json()
        {
            var jsonReader = new TraktMostPWCShowObjectJsonReader();
            var mostPWCShow = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktMostPWCShow;

            mostPWCShow.Should().NotBeNull();
            mostPWCShow.WatcherCount.Should().Be(4992);
            mostPWCShow.PlayCount.Should().Be(7100);
            mostPWCShow.CollectedCount.Should().Be(1348);
            mostPWCShow.CollectorCount.Should().Be(7964);

            mostPWCShow.Show.Should().NotBeNull();
            mostPWCShow.Show.Title.Should().Be("Game of Thrones");
            mostPWCShow.Show.Year.Should().Be(2011);
            mostPWCShow.Show.Airs.Should().NotBeNull();
            mostPWCShow.Show.Airs.Day.Should().Be("Sunday");
            mostPWCShow.Show.Airs.Time.Should().Be("21:00");
            mostPWCShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            mostPWCShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            mostPWCShow.Show.Ids.Should().NotBeNull();
            mostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
            mostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            mostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
            mostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
            mostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
            mostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            mostPWCShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            mostPWCShow.Show.Seasons.Should().BeNull();
            mostPWCShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            mostPWCShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            mostPWCShow.Show.Runtime.Should().Be(60);
            mostPWCShow.Show.Certification.Should().Be("TV-MA");
            mostPWCShow.Show.Network.Should().Be("HBO");
            mostPWCShow.Show.CountryCode.Should().Be("us");
            mostPWCShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            mostPWCShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            mostPWCShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            mostPWCShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            mostPWCShow.Show.Rating.Should().Be(9.38327f);
            mostPWCShow.Show.Votes.Should().Be(44773);
            mostPWCShow.Show.LanguageCode.Should().Be("en");
            mostPWCShow.Show.AiredEpisodes.Should().Be(50);

            mostPWCShow.Title.Should().Be("Game of Thrones");
            mostPWCShow.Year.Should().Be(2011);
            mostPWCShow.Airs.Should().NotBeNull();
            mostPWCShow.Airs.Day.Should().Be("Sunday");
            mostPWCShow.Airs.Time.Should().Be("21:00");
            mostPWCShow.Airs.TimeZoneId.Should().Be("America/New_York");
            mostPWCShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            mostPWCShow.Ids.Should().NotBeNull();
            mostPWCShow.Ids.Trakt.Should().Be(1390U);
            mostPWCShow.Ids.Slug.Should().Be("game-of-thrones");
            mostPWCShow.Ids.Tvdb.Should().Be(121361U);
            mostPWCShow.Ids.Imdb.Should().Be("tt0944947");
            mostPWCShow.Ids.Tmdb.Should().Be(1399U);
            mostPWCShow.Ids.TvRage.Should().Be(24493U);
            mostPWCShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            mostPWCShow.Seasons.Should().BeNull();
            mostPWCShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            mostPWCShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            mostPWCShow.Runtime.Should().Be(60);
            mostPWCShow.Certification.Should().Be("TV-MA");
            mostPWCShow.Network.Should().Be("HBO");
            mostPWCShow.CountryCode.Should().Be("us");
            mostPWCShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            mostPWCShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            mostPWCShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            mostPWCShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            mostPWCShow.Rating.Should().Be(9.38327f);
            mostPWCShow.Votes.Should().Be(44773);
            mostPWCShow.LanguageCode.Should().Be("en");
            mostPWCShow.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
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
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
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
