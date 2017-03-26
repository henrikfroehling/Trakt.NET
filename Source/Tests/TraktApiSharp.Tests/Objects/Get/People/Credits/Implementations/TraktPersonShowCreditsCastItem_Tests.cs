namespace TraktApiSharp.Tests.Objects.Get.People.Credits.Implementations
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.Implementations;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonShowCreditsCastItem_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsCastItem_Implements_ITraktPersonShowCreditsCastItem_Interface()
        {
            typeof(TraktPersonShowCreditsCastItem).GetInterfaces().Should().Contain(typeof(ITraktPersonShowCreditsCastItem));
        }

        [Fact]
        public void Test_TraktPersonShowCreditsCastItem_Default_Constructor()
        {
            var creditsCastItem = new TraktPersonShowCreditsCastItem();

            creditsCastItem.Character.Should().BeNullOrEmpty();
            creditsCastItem.Show.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonShowCreditsCastItem_From_Minimal_Json()
        {
            var creditsCastItem = JsonConvert.DeserializeObject<TraktPersonShowCreditsCastItem>(MINIMAL_JSON);

            creditsCastItem.Should().NotBeNull();
            creditsCastItem.Character.Should().Be("Joe Brody");
            creditsCastItem.Show.Should().NotBeNull();
            creditsCastItem.Show.Title.Should().Be("Game of Thrones");
            creditsCastItem.Show.Year.Should().Be(2011);
            creditsCastItem.Show.Airs.Should().BeNull();
            creditsCastItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCastItem.Show.Ids.Should().NotBeNull();
            creditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
            creditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
            creditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
            creditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            creditsCastItem.Show.Genres.Should().BeNull();
            creditsCastItem.Show.Seasons.Should().BeNull();
            creditsCastItem.Show.Overview.Should().BeNullOrEmpty();
            creditsCastItem.Show.FirstAired.Should().NotHaveValue();
            creditsCastItem.Show.Runtime.Should().NotHaveValue();
            creditsCastItem.Show.Certification.Should().BeNullOrEmpty();
            creditsCastItem.Show.Network.Should().BeNullOrEmpty();
            creditsCastItem.Show.CountryCode.Should().BeNullOrEmpty();
            creditsCastItem.Show.UpdatedAt.Should().NotHaveValue();
            creditsCastItem.Show.Trailer.Should().BeNullOrEmpty();
            creditsCastItem.Show.Homepage.Should().BeNullOrEmpty();
            creditsCastItem.Show.Status.Should().BeNull();
            creditsCastItem.Show.Rating.Should().NotHaveValue();
            creditsCastItem.Show.Votes.Should().NotHaveValue();
            creditsCastItem.Show.LanguageCode.Should().BeNullOrEmpty();
            creditsCastItem.Show.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktPersonShowCreditsCastItem_From_Full_Json()
        {
            var creditsCastItem = JsonConvert.DeserializeObject<TraktPersonShowCreditsCastItem>(FULL_JSON);

            creditsCastItem.Should().NotBeNull();
            creditsCastItem.Character.Should().Be("Joe Brody");
            creditsCastItem.Show.Should().NotBeNull();
            creditsCastItem.Show.Title.Should().Be("Game of Thrones");
            creditsCastItem.Show.Year.Should().Be(2011);
            creditsCastItem.Show.Airs.Should().NotBeNull();
            creditsCastItem.Show.Airs.Day.Should().Be("Sunday");
            creditsCastItem.Show.Airs.Time.Should().Be("21:00");
            creditsCastItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            creditsCastItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            creditsCastItem.Show.Ids.Should().NotBeNull();
            creditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
            creditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
            creditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
            creditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            creditsCastItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            creditsCastItem.Show.Seasons.Should().BeNull();
            creditsCastItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            creditsCastItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            creditsCastItem.Show.Runtime.Should().Be(60);
            creditsCastItem.Show.Certification.Should().Be("TV-MA");
            creditsCastItem.Show.Network.Should().Be("HBO");
            creditsCastItem.Show.CountryCode.Should().Be("us");
            creditsCastItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            creditsCastItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            creditsCastItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            creditsCastItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            creditsCastItem.Show.Rating.Should().Be(9.38327f);
            creditsCastItem.Show.Votes.Should().Be(44773);
            creditsCastItem.Show.LanguageCode.Should().Be("en");
            creditsCastItem.Show.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""character"": ""Joe Brody"",
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
                ""character"": ""Joe Brody"",
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
