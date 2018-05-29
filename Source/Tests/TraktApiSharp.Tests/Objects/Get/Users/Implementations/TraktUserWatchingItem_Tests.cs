namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserWatchingItem_Tests
    {
        [Fact]
        public void Test_TraktUserWatchingItem_Default_Constructor()
        {
            var watchingItem = new TraktUserWatchingItem();

            watchingItem.StartedAt.Should().BeNull();
            watchingItem.ExpiresAt.Should().BeNull();
            watchingItem.Action.Should().BeNull();
            watchingItem.Type.Should().BeNull();
            watchingItem.Movie.Should().BeNull();
            watchingItem.Show.Should().BeNull();
            watchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();
            var watchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktUserWatchingItem;

            watchingItem.Should().NotBeNull();
            watchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            watchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            watchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            watchingItem.Type.Should().Be(TraktSyncType.Movie);
            watchingItem.Movie.Should().NotBeNull();
            watchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            watchingItem.Movie.Year.Should().Be(2015);
            watchingItem.Movie.Ids.Should().NotBeNull();
            watchingItem.Movie.Ids.Trakt.Should().Be(94024U);
            watchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            watchingItem.Movie.Ids.Tmdb.Should().Be(140607U);
            watchingItem.Movie.Tagline.Should().BeNullOrEmpty();
            watchingItem.Movie.Overview.Should().BeNullOrEmpty();
            watchingItem.Movie.Released.Should().NotHaveValue();
            watchingItem.Movie.Runtime.Should().NotHaveValue();
            watchingItem.Movie.UpdatedAt.Should().NotHaveValue();
            watchingItem.Movie.Trailer.Should().BeNullOrEmpty();
            watchingItem.Movie.Homepage.Should().BeNullOrEmpty();
            watchingItem.Movie.Rating.Should().NotHaveValue();
            watchingItem.Movie.Votes.Should().NotHaveValue();
            watchingItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            watchingItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            watchingItem.Movie.Genres.Should().BeNull();
            watchingItem.Movie.Certification.Should().BeNullOrEmpty();
            watchingItem.Show.Should().BeNull();
            watchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItem_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();
            var watchingItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_MINIMAL_JSON) as TraktUserWatchingItem;

            watchingItem.Should().NotBeNull();
            watchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            watchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            watchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            watchingItem.Type.Should().Be(TraktSyncType.Episode);
            watchingItem.Movie.Should().BeNull();
            watchingItem.Show.Should().NotBeNull();
            watchingItem.Show.Title.Should().Be("Game of Thrones");
            watchingItem.Show.Year.Should().Be(2011);
            watchingItem.Show.Airs.Should().BeNull();
            watchingItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            watchingItem.Show.Ids.Should().NotBeNull();
            watchingItem.Show.Ids.Trakt.Should().Be(1390U);
            watchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchingItem.Show.Ids.Tvdb.Should().Be(121361U);
            watchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            watchingItem.Show.Ids.Tmdb.Should().Be(1399U);
            watchingItem.Show.Ids.TvRage.Should().Be(24493U);
            watchingItem.Show.Genres.Should().BeNull();
            watchingItem.Show.Seasons.Should().BeNull();
            watchingItem.Show.Overview.Should().BeNullOrEmpty();
            watchingItem.Show.FirstAired.Should().NotHaveValue();
            watchingItem.Show.Runtime.Should().NotHaveValue();
            watchingItem.Show.Certification.Should().BeNullOrEmpty();
            watchingItem.Show.Network.Should().BeNullOrEmpty();
            watchingItem.Show.CountryCode.Should().BeNullOrEmpty();
            watchingItem.Show.UpdatedAt.Should().NotHaveValue();
            watchingItem.Show.Trailer.Should().BeNullOrEmpty();
            watchingItem.Show.Homepage.Should().BeNullOrEmpty();
            watchingItem.Show.Status.Should().BeNull();
            watchingItem.Show.Rating.Should().NotHaveValue();
            watchingItem.Show.Votes.Should().NotHaveValue();
            watchingItem.Show.LanguageCode.Should().BeNullOrEmpty();
            watchingItem.Show.AiredEpisodes.Should().NotHaveValue();
            watchingItem.Episode.Should().NotBeNull();
            watchingItem.Episode.SeasonNumber.Should().Be(1);
            watchingItem.Episode.Number.Should().Be(1);
            watchingItem.Episode.Title.Should().Be("Winter Is Coming");
            watchingItem.Episode.Ids.Should().NotBeNull();
            watchingItem.Episode.Ids.Trakt.Should().Be(73640U);
            watchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            watchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            watchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
            watchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            watchingItem.Episode.NumberAbsolute.Should().NotHaveValue();
            watchingItem.Episode.Overview.Should().BeNullOrEmpty();
            watchingItem.Episode.Runtime.Should().NotHaveValue();
            watchingItem.Episode.Rating.Should().NotHaveValue();
            watchingItem.Episode.Votes.Should().NotHaveValue();
            watchingItem.Episode.FirstAired.Should().NotHaveValue();
            watchingItem.Episode.UpdatedAt.Should().NotHaveValue();
            watchingItem.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            watchingItem.Episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();
            var watchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktUserWatchingItem;

            watchingItem.Should().NotBeNull();
            watchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            watchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            watchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            watchingItem.Type.Should().Be(TraktSyncType.Movie);
            watchingItem.Movie.Should().NotBeNull();
            watchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            watchingItem.Movie.Year.Should().Be(2015);
            watchingItem.Movie.Ids.Should().NotBeNull();
            watchingItem.Movie.Ids.Trakt.Should().Be(94024U);
            watchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            watchingItem.Movie.Ids.Tmdb.Should().Be(140607U);
            watchingItem.Movie.Tagline.Should().Be("Every generation has a story.");
            watchingItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            watchingItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            watchingItem.Movie.Runtime.Should().Be(136);
            watchingItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            watchingItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchingItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            watchingItem.Movie.Rating.Should().Be(8.31988f);
            watchingItem.Movie.Votes.Should().Be(9338);
            watchingItem.Movie.LanguageCode.Should().Be("en");
            watchingItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            watchingItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            watchingItem.Movie.Certification.Should().Be("PG-13");
            watchingItem.Show.Should().BeNull();
            watchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserWatchingItem_With_Type_Episode_From_Full_Json()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();
            var watchingItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_FULL_JSON) as TraktUserWatchingItem;

            watchingItem.Should().NotBeNull();
            watchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            watchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            watchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            watchingItem.Type.Should().Be(TraktSyncType.Episode);
            watchingItem.Movie.Should().BeNull();
            watchingItem.Show.Should().NotBeNull();
            watchingItem.Show.Title.Should().Be("Game of Thrones");
            watchingItem.Show.Year.Should().Be(2011);
            watchingItem.Show.Airs.Should().NotBeNull();
            watchingItem.Show.Airs.Day.Should().Be("Sunday");
            watchingItem.Show.Airs.Time.Should().Be("21:00");
            watchingItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            watchingItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            watchingItem.Show.Ids.Should().NotBeNull();
            watchingItem.Show.Ids.Trakt.Should().Be(1390U);
            watchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchingItem.Show.Ids.Tvdb.Should().Be(121361U);
            watchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            watchingItem.Show.Ids.Tmdb.Should().Be(1399U);
            watchingItem.Show.Ids.TvRage.Should().Be(24493U);
            watchingItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            watchingItem.Show.Seasons.Should().BeNull();
            watchingItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchingItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            watchingItem.Show.Runtime.Should().Be(60);
            watchingItem.Show.Certification.Should().Be("TV-MA");
            watchingItem.Show.Network.Should().Be("HBO");
            watchingItem.Show.CountryCode.Should().Be("us");
            watchingItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            watchingItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchingItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            watchingItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            watchingItem.Show.Rating.Should().Be(9.38327f);
            watchingItem.Show.Votes.Should().Be(44773);
            watchingItem.Show.LanguageCode.Should().Be("en");
            watchingItem.Show.AiredEpisodes.Should().Be(50);
            watchingItem.Episode.Should().NotBeNull();
            watchingItem.Episode.SeasonNumber.Should().Be(1);
            watchingItem.Episode.Number.Should().Be(1);
            watchingItem.Episode.Title.Should().Be("Winter Is Coming");
            watchingItem.Episode.Ids.Should().NotBeNull();
            watchingItem.Episode.Ids.Trakt.Should().Be(73640U);
            watchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            watchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            watchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
            watchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            watchingItem.Episode.NumberAbsolute.Should().Be(50);
            watchingItem.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            watchingItem.Episode.Runtime.Should().Be(55);
            watchingItem.Episode.Rating.Should().Be(9.0f);
            watchingItem.Episode.Votes.Should().Be(111);
            watchingItem.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            watchingItem.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            watchingItem.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            watchingItem.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = watchingItem.Episode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        private const string TYPE_MOVIE_MINIMAL_JSON =
            @"{
                ""started_at"": ""2014-10-23T06:44:02.000Z"",
                ""expires_at"": ""2014-10-23T08:36:02.000Z"",
                ""action"": ""checkin"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_EPISODE_MINIMAL_JSON =
            @"{
                ""started_at"": ""2014-10-23T06:44:02.000Z"",
                ""expires_at"": ""2014-10-23T08:36:02.000Z"",
                ""action"": ""checkin"",
                ""type"": ""episode"",
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
                },
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

        private const string TYPE_MOVIE_FULL_JSON =
            @"{
                ""started_at"": ""2014-10-23T06:44:02.000Z"",
                ""expires_at"": ""2014-10-23T08:36:02.000Z"",
                ""action"": ""checkin"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  },
                  ""tagline"": ""Every generation has a story."",
                  ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                  ""released"": ""2015-12-18"",
                  ""runtime"": 136,
                  ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                  ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                  ""rating"": 8.31988,
                  ""votes"": 9338,
                  ""updated_at"": ""2016-03-31T09:01:59Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""de"",
                    ""en"",
                    ""it""
                  ],
                  ""genres"": [
                    ""action"",
                    ""adventure"",
                    ""fantasy"",
                    ""science-fiction""
                  ],
                  ""certification"": ""PG-13""
                }
              }";

        private const string TYPE_EPISODE_FULL_JSON =
            @"{
                ""started_at"": ""2014-10-23T06:44:02.000Z"",
                ""expires_at"": ""2014-10-23T08:36:02.000Z"",
                ""action"": ""checkin"",
                ""type"": ""episode"",
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
                },
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
