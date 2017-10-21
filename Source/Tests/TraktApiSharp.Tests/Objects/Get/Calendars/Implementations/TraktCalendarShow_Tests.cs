namespace TraktApiSharp.Tests.Objects.Get.Calendars.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Calendars.Implementations;
    using TraktApiSharp.Objects.Get.Calendars.JsonReader;
    using Xunit;

    [Category("Objects.Get.Calendars.Implementations")]
    public class TraktCalendarShow_Tests
    {
        [Fact]
        public void Test_TraktCalendarShow_Default_Constructor()
        {
            var calendarShow = new TraktCalendarShow();

            calendarShow.FirstAiredInCalendar.Should().NotHaveValue();
            calendarShow.Show.Should().BeNull();
            calendarShow.Episode.Should().BeNull();

            calendarShow.Title.Should().BeNullOrEmpty();
            calendarShow.Year.Should().NotHaveValue();
            calendarShow.Airs.Should().BeNull();
            calendarShow.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarShow.Ids.Should().BeNull();
            calendarShow.Genres.Should().BeNull();
            calendarShow.Seasons.Should().BeNull();
            calendarShow.Overview.Should().BeNullOrEmpty();
            calendarShow.FirstAired.Should().NotHaveValue();
            calendarShow.Runtime.Should().NotHaveValue();
            calendarShow.Certification.Should().BeNullOrEmpty();
            calendarShow.Network.Should().BeNullOrEmpty();
            calendarShow.CountryCode.Should().BeNullOrEmpty();
            calendarShow.UpdatedAt.Should().NotHaveValue();
            calendarShow.Trailer.Should().BeNullOrEmpty();
            calendarShow.Homepage.Should().BeNullOrEmpty();
            calendarShow.Status.Should().BeNull();
            calendarShow.Rating.Should().NotHaveValue();
            calendarShow.Votes.Should().NotHaveValue();
            calendarShow.LanguageCode.Should().BeNullOrEmpty();
            calendarShow.AiredEpisodes.Should().NotHaveValue();

            calendarShow.SeasonNumber.Should().NotHaveValue();
            calendarShow.EpisodeNumber.Should().NotHaveValue();
            calendarShow.Title.Should().BeNullOrEmpty();
            calendarShow.Ids.Should().BeNull();
            calendarShow.AbsoluteEpisodeNumber.Should().NotHaveValue();
            calendarShow.Overview.Should().BeNullOrEmpty();
            calendarShow.Runtime.Should().NotHaveValue();
            calendarShow.Rating.Should().NotHaveValue();
            calendarShow.Votes.Should().NotHaveValue();
            calendarShow.FirstAired.Should().NotHaveValue();
            calendarShow.UpdatedAt.Should().NotHaveValue();
            calendarShow.AvailableEpisodeTranslationLanguageCodes.Should().BeNull();
            calendarShow.EpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCalendarShow_From_Minimal_Json()
        {
            var jsonReader = new CalendarShowObjectJsonReader();
            var calendarShow = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktCalendarShow;

            calendarShow.Should().NotBeNull();
            calendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            calendarShow.Show.Should().NotBeNull();
            calendarShow.Show.Title.Should().Be("Game of Thrones");
            calendarShow.Show.Year.Should().Be(2011);
            calendarShow.Show.Airs.Should().BeNull();
            calendarShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarShow.Show.Ids.Should().NotBeNull();
            calendarShow.Show.Ids.Trakt.Should().Be(1390U);
            calendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            calendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            calendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            calendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            calendarShow.Show.Ids.TvRage.Should().Be(24493U);
            calendarShow.Show.Genres.Should().BeNull();
            calendarShow.Show.Seasons.Should().BeNull();
            calendarShow.Show.Overview.Should().BeNullOrEmpty();
            calendarShow.Show.FirstAired.Should().NotHaveValue();
            calendarShow.Show.Runtime.Should().NotHaveValue();
            calendarShow.Show.Certification.Should().BeNullOrEmpty();
            calendarShow.Show.Network.Should().BeNullOrEmpty();
            calendarShow.Show.CountryCode.Should().BeNullOrEmpty();
            calendarShow.Show.UpdatedAt.Should().NotHaveValue();
            calendarShow.Show.Trailer.Should().BeNullOrEmpty();
            calendarShow.Show.Homepage.Should().BeNullOrEmpty();
            calendarShow.Show.Status.Should().BeNull();
            calendarShow.Show.Rating.Should().NotHaveValue();
            calendarShow.Show.Votes.Should().NotHaveValue();
            calendarShow.Show.LanguageCode.Should().BeNullOrEmpty();
            calendarShow.Show.AiredEpisodes.Should().NotHaveValue();

            calendarShow.Title.Should().Be("Game of Thrones");
            calendarShow.Year.Should().Be(2011);
            calendarShow.Airs.Should().BeNull();
            calendarShow.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarShow.Ids.Should().NotBeNull();
            calendarShow.Ids.Trakt.Should().Be(1390U);
            calendarShow.Ids.Slug.Should().Be("game-of-thrones");
            calendarShow.Ids.Tvdb.Should().Be(121361U);
            calendarShow.Ids.Imdb.Should().Be("tt0944947");
            calendarShow.Ids.Tmdb.Should().Be(1399U);
            calendarShow.Ids.TvRage.Should().Be(24493U);
            calendarShow.Genres.Should().BeNull();
            calendarShow.Seasons.Should().BeNull();
            calendarShow.Overview.Should().BeNullOrEmpty();
            calendarShow.FirstAired.Should().NotHaveValue();
            calendarShow.Runtime.Should().NotHaveValue();
            calendarShow.Certification.Should().BeNullOrEmpty();
            calendarShow.Network.Should().BeNullOrEmpty();
            calendarShow.CountryCode.Should().BeNullOrEmpty();
            calendarShow.UpdatedAt.Should().NotHaveValue();
            calendarShow.Trailer.Should().BeNullOrEmpty();
            calendarShow.Homepage.Should().BeNullOrEmpty();
            calendarShow.Status.Should().BeNull();
            calendarShow.Rating.Should().NotHaveValue();
            calendarShow.Votes.Should().NotHaveValue();
            calendarShow.LanguageCode.Should().BeNullOrEmpty();
            calendarShow.AiredEpisodes.Should().NotHaveValue();

            calendarShow.Episode.Should().NotBeNull();
            calendarShow.Episode.SeasonNumber.Should().Be(1);
            calendarShow.Episode.Number.Should().Be(1);
            calendarShow.Episode.Title.Should().Be("Winter Is Coming");
            calendarShow.Episode.Ids.Should().NotBeNull();
            calendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            calendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            calendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            calendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            calendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            calendarShow.Episode.NumberAbsolute.Should().NotHaveValue();
            calendarShow.Episode.Overview.Should().BeNullOrEmpty();
            calendarShow.Episode.Runtime.Should().NotHaveValue();
            calendarShow.Episode.Rating.Should().NotHaveValue();
            calendarShow.Episode.Votes.Should().NotHaveValue();
            calendarShow.Episode.FirstAired.Should().NotHaveValue();
            calendarShow.Episode.UpdatedAt.Should().NotHaveValue();
            calendarShow.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            calendarShow.Episode.Translations.Should().BeNull();

            calendarShow.Should().NotBeNull();
            calendarShow.SeasonNumber.Should().Be(1);
            calendarShow.EpisodeNumber.Should().Be(1);
            calendarShow.EpisodeTitle.Should().Be("Winter Is Coming");
            calendarShow.EpisodeIds.Should().NotBeNull();
            calendarShow.EpisodeIds.Trakt.Should().Be(73640U);
            calendarShow.EpisodeIds.Tvdb.Should().Be(3254641U);
            calendarShow.EpisodeIds.Imdb.Should().Be("tt1480055");
            calendarShow.EpisodeIds.Tmdb.Should().Be(63056U);
            calendarShow.EpisodeIds.TvRage.Should().Be(1065008299U);
            calendarShow.AbsoluteEpisodeNumber.Should().NotHaveValue();
            calendarShow.EpisodeOverview.Should().BeNullOrEmpty();
            calendarShow.EpisodeRuntime.Should().NotHaveValue();
            calendarShow.EpisodeRating.Should().NotHaveValue();
            calendarShow.EpisodeVotes.Should().NotHaveValue();
            calendarShow.EpisodeAiredFirstAt.Should().NotHaveValue();
            calendarShow.EpisodeUpdatedAt.Should().NotHaveValue();
            calendarShow.AvailableEpisodeTranslationLanguageCodes.Should().BeNull();
            calendarShow.EpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCalendarShow_From_Full_Json()
        {
            var jsonReader = new CalendarShowObjectJsonReader();
            var calendarShow = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktCalendarShow;

            calendarShow.Should().NotBeNull();
            calendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            calendarShow.Show.Should().NotBeNull();
            calendarShow.Show.Title.Should().Be("Game of Thrones");
            calendarShow.Show.Year.Should().Be(2011);
            calendarShow.Show.Airs.Should().NotBeNull();
            calendarShow.Show.Airs.Day.Should().Be("Sunday");
            calendarShow.Show.Airs.Time.Should().Be("21:00");
            calendarShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            calendarShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            calendarShow.Show.Ids.Should().NotBeNull();
            calendarShow.Show.Ids.Trakt.Should().Be(1390U);
            calendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            calendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            calendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            calendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            calendarShow.Show.Ids.TvRage.Should().Be(24493U);
            calendarShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            calendarShow.Show.Seasons.Should().BeNull();
            calendarShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            calendarShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            calendarShow.Show.Runtime.Should().Be(60);
            calendarShow.Show.Certification.Should().Be("TV-MA");
            calendarShow.Show.Network.Should().Be("HBO");
            calendarShow.Show.CountryCode.Should().Be("us");
            calendarShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            calendarShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            calendarShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            calendarShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            calendarShow.Show.Rating.Should().Be(9.38327f);
            calendarShow.Show.Votes.Should().Be(44773);
            calendarShow.Show.LanguageCode.Should().Be("en");
            calendarShow.Show.AiredEpisodes.Should().Be(50);

            calendarShow.Title.Should().Be("Game of Thrones");
            calendarShow.Year.Should().Be(2011);
            calendarShow.Airs.Should().NotBeNull();
            calendarShow.Airs.Day.Should().Be("Sunday");
            calendarShow.Airs.Time.Should().Be("21:00");
            calendarShow.Airs.TimeZoneId.Should().Be("America/New_York");
            calendarShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            calendarShow.Ids.Should().NotBeNull();
            calendarShow.Ids.Trakt.Should().Be(1390U);
            calendarShow.Ids.Slug.Should().Be("game-of-thrones");
            calendarShow.Ids.Tvdb.Should().Be(121361U);
            calendarShow.Ids.Imdb.Should().Be("tt0944947");
            calendarShow.Ids.Tmdb.Should().Be(1399U);
            calendarShow.Ids.TvRage.Should().Be(24493U);
            calendarShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            calendarShow.Seasons.Should().BeNull();
            calendarShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            calendarShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            calendarShow.Runtime.Should().Be(60);
            calendarShow.Certification.Should().Be("TV-MA");
            calendarShow.Network.Should().Be("HBO");
            calendarShow.CountryCode.Should().Be("us");
            calendarShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            calendarShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            calendarShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            calendarShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            calendarShow.Rating.Should().Be(9.38327f);
            calendarShow.Votes.Should().Be(44773);
            calendarShow.LanguageCode.Should().Be("en");
            calendarShow.AiredEpisodes.Should().Be(50);

            calendarShow.Episode.Should().NotBeNull();
            calendarShow.Episode.SeasonNumber.Should().Be(1);
            calendarShow.Episode.Number.Should().Be(1);
            calendarShow.Episode.Title.Should().Be("Winter Is Coming");
            calendarShow.Episode.Ids.Should().NotBeNull();
            calendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            calendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            calendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            calendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            calendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
            calendarShow.Episode.NumberAbsolute.Should().Be(50);
            calendarShow.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            calendarShow.Episode.Runtime.Should().Be(55);
            calendarShow.Episode.Rating.Should().Be(9.0f);
            calendarShow.Episode.Votes.Should().Be(111);
            calendarShow.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            calendarShow.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            calendarShow.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            calendarShow.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = calendarShow.Episode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");

            calendarShow.Should().NotBeNull();
            calendarShow.SeasonNumber.Should().Be(1);
            calendarShow.EpisodeNumber.Should().Be(1);
            calendarShow.EpisodeTitle.Should().Be("Winter Is Coming");
            calendarShow.EpisodeIds.Should().NotBeNull();
            calendarShow.EpisodeIds.Trakt.Should().Be(73640U);
            calendarShow.EpisodeIds.Tvdb.Should().Be(3254641U);
            calendarShow.EpisodeIds.Imdb.Should().Be("tt1480055");
            calendarShow.EpisodeIds.Tmdb.Should().Be(63056U);
            calendarShow.EpisodeIds.TvRage.Should().Be(1065008299U);
            calendarShow.AbsoluteEpisodeNumber.Should().Be(50);
            calendarShow.EpisodeOverview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            calendarShow.EpisodeRuntime.Should().Be(55);
            calendarShow.EpisodeRating.Should().Be(9.0f);
            calendarShow.EpisodeVotes.Should().Be(111);
            calendarShow.EpisodeAiredFirstAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            calendarShow.EpisodeUpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            calendarShow.AvailableEpisodeTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            calendarShow.EpisodeTranslations.Should().NotBeNull().And.HaveCount(2);

            translations = calendarShow.EpisodeTranslations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        private const string MINIMAL_JSON =
            @"{
                ""first_aired"": ""2014-07-14T01:00:00.000Z"",
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
                },
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                }
              }";

        private const string FULL_JSON =
            @"{
                ""first_aired"": ""2014-07-14T01:00:00.000Z"",
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
                },
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  },
                  ""number_abs"": 50,
                  ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                  ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                  ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                  ""rating"": 9,
                  ""votes"": 111,
                  ""available_translations"": [
                    ""en"",
                    ""es""
                  ],
                  ""runtime"": 55,
                  ""translations"": [
                    {
                      ""title"": ""Winter Is Coming"",
                      ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                      ""language"": ""en""
                    },
                    {
                      ""title"": ""Se acerca el invierno"",
                      ""overview"": ""El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",
                      ""language"": ""es""
                    }
                  ]
                }
              }";
    }
}
