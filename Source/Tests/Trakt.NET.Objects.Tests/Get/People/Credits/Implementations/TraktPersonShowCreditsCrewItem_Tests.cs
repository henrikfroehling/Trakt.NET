namespace TraktNet.Objects.Tests.Get.People.Credits.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.Implementations")]
    public class TraktPersonShowCreditsCrewItem_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsCrewItem_Default_Constructor()
        {
            var creditsCrewItem = new TraktPersonShowCreditsCrewItem();

            creditsCrewItem.Job.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPersonShowCreditsCrewItem_From_Minimal_Json()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();
            var creditsCrewItem = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktPersonShowCreditsCrewItem;

            creditsCrewItem.Should().NotBeNull();
            creditsCrewItem.Job.Should().Be("Director");
            creditsCrewItem.Show.Should().NotBeNull();
            creditsCrewItem.Show.Title.Should().Be("Game of Thrones");
            creditsCrewItem.Show.Year.Should().Be(2011);
            creditsCrewItem.Show.Airs.Should().BeNull();
            creditsCrewItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            creditsCrewItem.Show.Ids.Should().NotBeNull();
            creditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
            creditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
            creditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
            creditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
            creditsCrewItem.Show.Genres.Should().BeNull();
            creditsCrewItem.Show.Seasons.Should().BeNull();
            creditsCrewItem.Show.Overview.Should().BeNullOrEmpty();
            creditsCrewItem.Show.FirstAired.Should().NotHaveValue();
            creditsCrewItem.Show.Runtime.Should().NotHaveValue();
            creditsCrewItem.Show.Certification.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Network.Should().BeNullOrEmpty();
            creditsCrewItem.Show.CountryCode.Should().BeNullOrEmpty();
            creditsCrewItem.Show.UpdatedAt.Should().NotHaveValue();
            creditsCrewItem.Show.Trailer.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Homepage.Should().BeNullOrEmpty();
            creditsCrewItem.Show.Status.Should().BeNull();
            creditsCrewItem.Show.Rating.Should().NotHaveValue();
            creditsCrewItem.Show.Votes.Should().NotHaveValue();
            creditsCrewItem.Show.LanguageCode.Should().BeNullOrEmpty();
            creditsCrewItem.Show.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktPersonShowCreditsCrewItem_From_Full_Json()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();
            var creditsCrewItem = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktPersonShowCreditsCrewItem;

            creditsCrewItem.Should().NotBeNull();
            creditsCrewItem.Job.Should().Be("Director");
            creditsCrewItem.Show.Should().NotBeNull();
            creditsCrewItem.Show.Title.Should().Be("Game of Thrones");
            creditsCrewItem.Show.Year.Should().Be(2011);
            creditsCrewItem.Show.Airs.Should().NotBeNull();
            creditsCrewItem.Show.Airs.Day.Should().Be("Sunday");
            creditsCrewItem.Show.Airs.Time.Should().Be("21:00");
            creditsCrewItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            creditsCrewItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            creditsCrewItem.Show.Ids.Should().NotBeNull();
            creditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
            creditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            creditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
            creditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
            creditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
            creditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
            creditsCrewItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            creditsCrewItem.Show.Seasons.Should().BeNull();
            creditsCrewItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            creditsCrewItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            creditsCrewItem.Show.Runtime.Should().Be(60);
            creditsCrewItem.Show.Certification.Should().Be("TV-MA");
            creditsCrewItem.Show.Network.Should().Be("HBO");
            creditsCrewItem.Show.CountryCode.Should().Be("us");
            creditsCrewItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            creditsCrewItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            creditsCrewItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            creditsCrewItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            creditsCrewItem.Show.Rating.Should().Be(9.38327f);
            creditsCrewItem.Show.Votes.Should().Be(44773);
            creditsCrewItem.Show.LanguageCode.Should().Be("en");
            creditsCrewItem.Show.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
            @"{
                ""job"": ""Director"",
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
                ""job"": ""Director"",
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
