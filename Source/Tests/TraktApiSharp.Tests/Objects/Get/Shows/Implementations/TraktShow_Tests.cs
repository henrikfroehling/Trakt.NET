namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShow_Tests
    {
        [Fact]
        public void Test_TraktShow_Default_Constructor()
        {
            var show = new TraktShow();

            show.Title.Should().BeNullOrEmpty();
            show.Year.Should().NotHaveValue();
            show.Airs.Should().BeNull();
            show.AvailableTranslationLanguageCodes.Should().BeNull();
            show.Ids.Should().BeNull();
            show.Genres.Should().BeNull();
            show.Seasons.Should().BeNull();
            show.Overview.Should().BeNullOrEmpty();
            show.FirstAired.Should().NotHaveValue();
            show.Runtime.Should().NotHaveValue();
            show.Certification.Should().BeNullOrEmpty();
            show.Network.Should().BeNullOrEmpty();
            show.CountryCode.Should().BeNullOrEmpty();
            show.UpdatedAt.Should().NotHaveValue();
            show.Trailer.Should().BeNullOrEmpty();
            show.Homepage.Should().BeNullOrEmpty();
            show.Status.Should().BeNull();
            show.Rating.Should().NotHaveValue();
            show.Votes.Should().NotHaveValue();
            show.LanguageCode.Should().BeNullOrEmpty();
            show.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktShow_From_Minimal_Json()
        {
            var jsonReader = new ShowObjectJsonReader();
            var show = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktShow;

            show.Should().NotBeNull();
            show.Title.Should().Be("Game of Thrones");
            show.Year.Should().Be(2011);
            show.Airs.Should().BeNull();
            show.AvailableTranslationLanguageCodes.Should().BeNull();
            show.Ids.Should().NotBeNull();
            show.Ids.Trakt.Should().Be(1390U);
            show.Ids.Slug.Should().Be("game-of-thrones");
            show.Ids.Tvdb.Should().Be(121361U);
            show.Ids.Imdb.Should().Be("tt0944947");
            show.Ids.Tmdb.Should().Be(1399U);
            show.Ids.TvRage.Should().Be(24493U);
            show.Genres.Should().BeNull();
            show.Seasons.Should().BeNull();
            show.Overview.Should().BeNullOrEmpty();
            show.FirstAired.Should().NotHaveValue();
            show.Runtime.Should().NotHaveValue();
            show.Certification.Should().BeNullOrEmpty();
            show.Network.Should().BeNullOrEmpty();
            show.CountryCode.Should().BeNullOrEmpty();
            show.UpdatedAt.Should().NotHaveValue();
            show.Trailer.Should().BeNullOrEmpty();
            show.Homepage.Should().BeNullOrEmpty();
            show.Status.Should().BeNull();
            show.Rating.Should().NotHaveValue();
            show.Votes.Should().NotHaveValue();
            show.LanguageCode.Should().BeNullOrEmpty();
            show.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktShow_From_Full_Json()
        {
            var jsonReader = new ShowObjectJsonReader();
            var show = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktShow;

            show.Should().NotBeNull();
            show.Title.Should().Be("Game of Thrones");
            show.Year.Should().Be(2011);
            show.Airs.Should().NotBeNull();
            show.Airs.Day.Should().Be("Sunday");
            show.Airs.Time.Should().Be("21:00");
            show.Airs.TimeZoneId.Should().Be("America/New_York");
            show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            show.Ids.Should().NotBeNull();
            show.Ids.Trakt.Should().Be(1390U);
            show.Ids.Slug.Should().Be("game-of-thrones");
            show.Ids.Tvdb.Should().Be(121361U);
            show.Ids.Imdb.Should().Be("tt0944947");
            show.Ids.Tmdb.Should().Be(1399U);
            show.Ids.TvRage.Should().Be(24493U);
            show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            show.Seasons.Should().BeNull();
            show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            show.Runtime.Should().Be(60);
            show.Certification.Should().Be("TV-MA");
            show.Network.Should().Be("HBO");
            show.CountryCode.Should().Be("us");
            show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            show.Rating.Should().Be(9.38327f);
            show.Votes.Should().Be(44773);
            show.LanguageCode.Should().Be("en");
            show.AiredEpisodes.Should().Be(50);
        }

        private const string MINIMAL_JSON =
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
                }
              }";

        private const string FULL_JSON =
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
              }";
    }
}
