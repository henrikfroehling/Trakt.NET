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
    public class TraktMostFavoritedShow_Tests
    {
        [Fact]
        public void Test_TraktMostFavoritedShow_Default_Constructor()
        {
            var favoritedShow = new TraktMostFavoritedShow();

            favoritedShow.UserCount.Should().BeNull();
            favoritedShow.Show.Should().BeNull();

            favoritedShow.Title.Should().BeNull();
            favoritedShow.Year.Should().BeNull();
            favoritedShow.Airs.Should().BeNull();
            favoritedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            favoritedShow.Ids.Should().BeNull();
            favoritedShow.Genres.Should().BeNull();
            favoritedShow.Seasons.Should().BeNull();
            favoritedShow.Overview.Should().BeNull();
            favoritedShow.FirstAired.Should().BeNull();
            favoritedShow.Runtime.Should().BeNull();
            favoritedShow.Certification.Should().BeNull();
            favoritedShow.Network.Should().BeNull();
            favoritedShow.CountryCode.Should().BeNull();
            favoritedShow.UpdatedAt.Should().BeNull();
            favoritedShow.Trailer.Should().BeNull();
            favoritedShow.Homepage.Should().BeNull();
            favoritedShow.Status.Should().BeNull();
            favoritedShow.Rating.Should().BeNull();
            favoritedShow.Votes.Should().BeNull();
            favoritedShow.LanguageCode.Should().BeNull();
            favoritedShow.AiredEpisodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMostFavoritedShow_From_Json()
        {
            var jsonReader = new MostFavoritedShowObjectJsonReader();
            var favoritedShow = await jsonReader.ReadObjectAsync(JSON) as TraktMostFavoritedShow;

            favoritedShow.Should().NotBeNull();
            favoritedShow.UserCount.Should().Be(155291);

            favoritedShow.Show.Should().NotBeNull();
            favoritedShow.Show.Title.Should().Be("Game of Thrones");
            favoritedShow.Show.Year.Should().Be(2011);
            favoritedShow.Show.Airs.Should().NotBeNull();
            favoritedShow.Show.Airs.Day.Should().Be("Sunday");
            favoritedShow.Show.Airs.Time.Should().Be("21:00");
            favoritedShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            favoritedShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            favoritedShow.Show.Ids.Should().NotBeNull();
            favoritedShow.Show.Ids.Trakt.Should().Be(1390U);
            favoritedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            favoritedShow.Show.Ids.Tvdb.Should().Be(121361U);
            favoritedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            favoritedShow.Show.Ids.Tmdb.Should().Be(1399U);
            favoritedShow.Show.Ids.TvRage.Should().Be(24493U);
            favoritedShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            favoritedShow.Show.Seasons.Should().BeNull();
            favoritedShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            favoritedShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            favoritedShow.Show.Runtime.Should().Be(60);
            favoritedShow.Show.Certification.Should().Be("TV-MA");
            favoritedShow.Show.Network.Should().Be("HBO");
            favoritedShow.Show.CountryCode.Should().Be("us");
            favoritedShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            favoritedShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            favoritedShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            favoritedShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            favoritedShow.Show.Rating.Should().Be(9.38327f);
            favoritedShow.Show.Votes.Should().Be(44773);
            favoritedShow.Show.LanguageCode.Should().Be("en");
            favoritedShow.Show.AiredEpisodes.Should().Be(50);

            favoritedShow.Title.Should().Be("Game of Thrones");
            favoritedShow.Year.Should().Be(2011);
            favoritedShow.Airs.Should().NotBeNull();
            favoritedShow.Airs.Day.Should().Be("Sunday");
            favoritedShow.Airs.Time.Should().Be("21:00");
            favoritedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            favoritedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            favoritedShow.Ids.Should().NotBeNull();
            favoritedShow.Ids.Trakt.Should().Be(1390U);
            favoritedShow.Ids.Slug.Should().Be("game-of-thrones");
            favoritedShow.Ids.Tvdb.Should().Be(121361U);
            favoritedShow.Ids.Imdb.Should().Be("tt0944947");
            favoritedShow.Ids.Tmdb.Should().Be(1399U);
            favoritedShow.Ids.TvRage.Should().Be(24493U);
            favoritedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            favoritedShow.Seasons.Should().BeNull();
            favoritedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            favoritedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            favoritedShow.Runtime.Should().Be(60);
            favoritedShow.Certification.Should().Be("TV-MA");
            favoritedShow.Network.Should().Be("HBO");
            favoritedShow.CountryCode.Should().Be("us");
            favoritedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            favoritedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            favoritedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            favoritedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            favoritedShow.Rating.Should().Be(9.38327f);
            favoritedShow.Votes.Should().Be(44773);
            favoritedShow.LanguageCode.Should().Be("en");
            favoritedShow.AiredEpisodes.Should().Be(50);
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
