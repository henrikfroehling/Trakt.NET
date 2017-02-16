namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows")]
    public class TraktMostAnticipatedShow_Tests
    {
        [Fact]
        public void Test_TraktMostAnticipatedShow_Implements_ITraktMostAnticipatedShow_Interface()
        {
            typeof(TraktMostAnticipatedShow).GetInterfaces().Should().Contain(typeof(ITraktMostAnticipatedShow));
        }

        [Fact]
        public void Test_TraktMostAnticipatedShow_Default_Constructor()
        {
            var anticipatedShow = new TraktMostAnticipatedShow();

            anticipatedShow.ListCount.Should().NotHaveValue();

            anticipatedShow.Show.Should().BeNull();
            anticipatedShow.Title.Should().BeNullOrEmpty();
            anticipatedShow.Year.Should().NotHaveValue();
            anticipatedShow.Airs.Should().BeNull();
            anticipatedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            anticipatedShow.Ids.Should().BeNull();
            anticipatedShow.Genres.Should().BeNull();
            anticipatedShow.Seasons.Should().BeNull();
            anticipatedShow.Overview.Should().BeNullOrEmpty();
            anticipatedShow.FirstAired.Should().NotHaveValue();
            anticipatedShow.Runtime.Should().NotHaveValue();
            anticipatedShow.Certification.Should().BeNullOrEmpty();
            anticipatedShow.Network.Should().BeNullOrEmpty();
            anticipatedShow.CountryCode.Should().BeNullOrEmpty();
            anticipatedShow.UpdatedAt.Should().NotHaveValue();
            anticipatedShow.Trailer.Should().BeNullOrEmpty();
            anticipatedShow.Homepage.Should().BeNullOrEmpty();
            anticipatedShow.Status.Should().BeNull();
            anticipatedShow.Rating.Should().NotHaveValue();
            anticipatedShow.Votes.Should().NotHaveValue();
            anticipatedShow.LanguageCode.Should().BeNullOrEmpty();
            anticipatedShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktMostAnticipatedShow_From_Minimal_Json()
        {
            var anticipatedShow = JsonConvert.DeserializeObject<TraktMostAnticipatedShow>(MINIMAL_JSON);

            anticipatedShow.Should().NotBeNull();
            anticipatedShow.ListCount.Should().Be(12805);

            anticipatedShow.Show.Should().NotBeNull();
            anticipatedShow.Show.Title.Should().Be("Game of Thrones");
            anticipatedShow.Show.Year.Should().Be(2011);
            anticipatedShow.Show.Airs.Should().BeNull();
            anticipatedShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            anticipatedShow.Show.Ids.Should().NotBeNull();
            anticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            anticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            anticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            anticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            anticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            anticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            anticipatedShow.Show.Genres.Should().BeNull();
            anticipatedShow.Show.Seasons.Should().BeNull();
            anticipatedShow.Show.Overview.Should().BeNullOrEmpty();
            anticipatedShow.Show.FirstAired.Should().NotHaveValue();
            anticipatedShow.Show.Runtime.Should().NotHaveValue();
            anticipatedShow.Show.Certification.Should().BeNullOrEmpty();
            anticipatedShow.Show.Network.Should().BeNullOrEmpty();
            anticipatedShow.Show.CountryCode.Should().BeNullOrEmpty();
            anticipatedShow.Show.UpdatedAt.Should().NotHaveValue();
            anticipatedShow.Show.Trailer.Should().BeNullOrEmpty();
            anticipatedShow.Show.Homepage.Should().BeNullOrEmpty();
            anticipatedShow.Show.Status.Should().BeNull();
            anticipatedShow.Show.Rating.Should().NotHaveValue();
            anticipatedShow.Show.Votes.Should().NotHaveValue();
            anticipatedShow.Show.LanguageCode.Should().BeNullOrEmpty();
            anticipatedShow.Show.AiredEpisodes.Should().NotHaveValue();

            anticipatedShow.Title.Should().Be("Game of Thrones");
            anticipatedShow.Year.Should().Be(2011);
            anticipatedShow.Airs.Should().BeNull();
            anticipatedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            anticipatedShow.Ids.Should().NotBeNull();
            anticipatedShow.Ids.Trakt.Should().Be(1390U);
            anticipatedShow.Ids.Slug.Should().Be("game-of-thrones");
            anticipatedShow.Ids.Tvdb.Should().Be(121361U);
            anticipatedShow.Ids.Imdb.Should().Be("tt0944947");
            anticipatedShow.Ids.Tmdb.Should().Be(1399U);
            anticipatedShow.Ids.TvRage.Should().Be(24493U);
            anticipatedShow.Genres.Should().BeNull();
            anticipatedShow.Seasons.Should().BeNull();
            anticipatedShow.Overview.Should().BeNullOrEmpty();
            anticipatedShow.FirstAired.Should().NotHaveValue();
            anticipatedShow.Runtime.Should().NotHaveValue();
            anticipatedShow.Certification.Should().BeNullOrEmpty();
            anticipatedShow.Network.Should().BeNullOrEmpty();
            anticipatedShow.CountryCode.Should().BeNullOrEmpty();
            anticipatedShow.UpdatedAt.Should().NotHaveValue();
            anticipatedShow.Trailer.Should().BeNullOrEmpty();
            anticipatedShow.Homepage.Should().BeNullOrEmpty();
            anticipatedShow.Status.Should().BeNull();
            anticipatedShow.Rating.Should().NotHaveValue();
            anticipatedShow.Votes.Should().NotHaveValue();
            anticipatedShow.LanguageCode.Should().BeNullOrEmpty();
            anticipatedShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktMostAnticipatedShow_From_Full_Json()
        {
            var anticipatedShow = JsonConvert.DeserializeObject<TraktMostAnticipatedShow>(FULL_JSON);

            anticipatedShow.Should().NotBeNull();
            anticipatedShow.ListCount.Should().Be(12805);

            anticipatedShow.Show.Should().NotBeNull();
            anticipatedShow.Show.Title.Should().Be("Game of Thrones");
            anticipatedShow.Show.Year.Should().Be(2011);
            anticipatedShow.Show.Airs.Should().NotBeNull();
            anticipatedShow.Show.Airs.Day.Should().Be("Sunday");
            anticipatedShow.Show.Airs.Time.Should().Be("21:00");
            anticipatedShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            anticipatedShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            anticipatedShow.Show.Ids.Should().NotBeNull();
            anticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            anticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            anticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            anticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            anticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            anticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            anticipatedShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            anticipatedShow.Show.Seasons.Should().BeNull();
            anticipatedShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            anticipatedShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            anticipatedShow.Show.Runtime.Should().Be(60);
            anticipatedShow.Show.Certification.Should().Be("TV-MA");
            anticipatedShow.Show.Network.Should().Be("HBO");
            anticipatedShow.Show.CountryCode.Should().Be("us");
            anticipatedShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            anticipatedShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            anticipatedShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            anticipatedShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            anticipatedShow.Show.Rating.Should().Be(9.38327f);
            anticipatedShow.Show.Votes.Should().Be(44773);
            anticipatedShow.Show.LanguageCode.Should().Be("en");
            anticipatedShow.Show.AiredEpisodes.Should().Be(50);

            anticipatedShow.Title.Should().Be("Game of Thrones");
            anticipatedShow.Year.Should().Be(2011);
            anticipatedShow.Airs.Should().NotBeNull();
            anticipatedShow.Airs.Day.Should().Be("Sunday");
            anticipatedShow.Airs.Time.Should().Be("21:00");
            anticipatedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            anticipatedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            anticipatedShow.Ids.Should().NotBeNull();
            anticipatedShow.Ids.Trakt.Should().Be(1390U);
            anticipatedShow.Ids.Slug.Should().Be("game-of-thrones");
            anticipatedShow.Ids.Tvdb.Should().Be(121361U);
            anticipatedShow.Ids.Imdb.Should().Be("tt0944947");
            anticipatedShow.Ids.Tmdb.Should().Be(1399U);
            anticipatedShow.Ids.TvRage.Should().Be(24493U);
            anticipatedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            anticipatedShow.Seasons.Should().BeNull();
            anticipatedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            anticipatedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            anticipatedShow.Runtime.Should().Be(60);
            anticipatedShow.Certification.Should().Be("TV-MA");
            anticipatedShow.Network.Should().Be("HBO");
            anticipatedShow.CountryCode.Should().Be("us");
            anticipatedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            anticipatedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            anticipatedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            anticipatedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            anticipatedShow.Rating.Should().Be(9.38327f);
            anticipatedShow.Votes.Should().Be(44773);
            anticipatedShow.LanguageCode.Should().Be("en");
            anticipatedShow.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""list_count"": 12805,
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
                ""list_count"": 12805,
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
