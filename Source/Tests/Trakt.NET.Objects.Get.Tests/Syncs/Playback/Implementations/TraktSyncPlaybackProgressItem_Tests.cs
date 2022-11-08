namespace TraktNet.Objects.Get.Tests.Syncs.Playback.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Syncs.Playback;
    using TraktNet.Objects.Get.Syncs.Playback.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Playback.Implementations")]
    public class TraktSyncPlaybackProgressItem_Tests
    {
        [Fact]
        public void Test_TraktSyncPlaybackProgressItem_Default_Constructor()
        {
            var playbackProgressItem = new TraktSyncPlaybackProgressItem();

            playbackProgressItem.Id.Should().Be(0U);
            playbackProgressItem.Progress.Should().NotHaveValue();
            playbackProgressItem.PausedAt.Should().NotHaveValue();
            playbackProgressItem.Type.Should().BeNull();
            playbackProgressItem.Movie.Should().BeNull();
            playbackProgressItem.Episode.Should().BeNull();
            playbackProgressItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncPlaybackProgressItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            var playbackProgressItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktSyncPlaybackProgressItem;

            playbackProgressItem.Should().NotBeNull();
            playbackProgressItem.Id.Should().Be(37U);
            playbackProgressItem.Progress.Should().Be(65.5f);
            playbackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            playbackProgressItem.Type.Should().Be(TraktSyncType.Movie);
            playbackProgressItem.Movie.Should().NotBeNull();
            playbackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            playbackProgressItem.Movie.Year.Should().Be(2015);
            playbackProgressItem.Movie.Ids.Should().NotBeNull();
            playbackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
            playbackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            playbackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            playbackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);
            playbackProgressItem.Movie.Tagline.Should().BeNullOrEmpty();
            playbackProgressItem.Movie.Overview.Should().BeNullOrEmpty();
            playbackProgressItem.Movie.Released.Should().NotHaveValue();
            playbackProgressItem.Movie.Runtime.Should().NotHaveValue();
            playbackProgressItem.Movie.UpdatedAt.Should().NotHaveValue();
            playbackProgressItem.Movie.Trailer.Should().BeNullOrEmpty();
            playbackProgressItem.Movie.Homepage.Should().BeNullOrEmpty();
            playbackProgressItem.Movie.Rating.Should().NotHaveValue();
            playbackProgressItem.Movie.Votes.Should().NotHaveValue();
            playbackProgressItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            playbackProgressItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            playbackProgressItem.Movie.Genres.Should().BeNull();
            playbackProgressItem.Movie.Certification.Should().BeNullOrEmpty();
            playbackProgressItem.Show.Should().BeNull();
            playbackProgressItem.Episode.Should().BeNull();
        }
        
        [Fact]
        public async Task Test_TraktSyncPlaybackProgressItem_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            var playbackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_MINIMAL_JSON) as TraktSyncPlaybackProgressItem;

            playbackProgressItem.Should().NotBeNull();
            playbackProgressItem.Id.Should().Be(37U);
            playbackProgressItem.Progress.Should().Be(65.5f);
            playbackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            playbackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            playbackProgressItem.Episode.Should().NotBeNull();
            playbackProgressItem.Episode.SeasonNumber.Should().Be(1);
            playbackProgressItem.Episode.Number.Should().Be(1);
            playbackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            playbackProgressItem.Episode.Ids.Should().NotBeNull();
            playbackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            playbackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            playbackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            playbackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            playbackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            playbackProgressItem.Episode.NumberAbsolute.Should().NotHaveValue();
            playbackProgressItem.Episode.Overview.Should().BeNullOrEmpty();
            playbackProgressItem.Episode.Runtime.Should().NotHaveValue();
            playbackProgressItem.Episode.Rating.Should().NotHaveValue();
            playbackProgressItem.Episode.Votes.Should().NotHaveValue();
            playbackProgressItem.Episode.FirstAired.Should().NotHaveValue();
            playbackProgressItem.Episode.UpdatedAt.Should().NotHaveValue();
            playbackProgressItem.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            playbackProgressItem.Episode.Translations.Should().BeNull();
            playbackProgressItem.Show.Should().NotBeNull();
            playbackProgressItem.Show.Title.Should().Be("Game of Thrones");
            playbackProgressItem.Show.Year.Should().Be(2011);
            playbackProgressItem.Show.Airs.Should().BeNull();
            playbackProgressItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            playbackProgressItem.Show.Ids.Should().NotBeNull();
            playbackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            playbackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            playbackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            playbackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            playbackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            playbackProgressItem.Show.Ids.TvRage.Should().Be(24493U);
            playbackProgressItem.Show.Genres.Should().BeNull();
            playbackProgressItem.Show.Seasons.Should().BeNull();
            playbackProgressItem.Show.Overview.Should().BeNullOrEmpty();
            playbackProgressItem.Show.FirstAired.Should().NotHaveValue();
            playbackProgressItem.Show.Runtime.Should().NotHaveValue();
            playbackProgressItem.Show.Certification.Should().BeNullOrEmpty();
            playbackProgressItem.Show.Network.Should().BeNullOrEmpty();
            playbackProgressItem.Show.CountryCode.Should().BeNullOrEmpty();
            playbackProgressItem.Show.UpdatedAt.Should().NotHaveValue();
            playbackProgressItem.Show.Trailer.Should().BeNullOrEmpty();
            playbackProgressItem.Show.Homepage.Should().BeNullOrEmpty();
            playbackProgressItem.Show.Status.Should().BeNull();
            playbackProgressItem.Show.Rating.Should().NotHaveValue();
            playbackProgressItem.Show.Votes.Should().NotHaveValue();
            playbackProgressItem.Show.LanguageCode.Should().BeNullOrEmpty();
            playbackProgressItem.Show.AiredEpisodes.Should().NotHaveValue();
            playbackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncPlaybackProgressItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            var playbackProgressItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktSyncPlaybackProgressItem;

            playbackProgressItem.Should().NotBeNull();
            playbackProgressItem.Id.Should().Be(37U);
            playbackProgressItem.Progress.Should().Be(65.5f);
            playbackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            playbackProgressItem.Type.Should().Be(TraktSyncType.Movie);
            playbackProgressItem.Movie.Should().NotBeNull();
            playbackProgressItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            playbackProgressItem.Movie.Year.Should().Be(2015);
            playbackProgressItem.Movie.Ids.Should().NotBeNull();
            playbackProgressItem.Movie.Ids.Trakt.Should().Be(94024U);
            playbackProgressItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            playbackProgressItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            playbackProgressItem.Movie.Ids.Tmdb.Should().Be(140607U);
            playbackProgressItem.Movie.Tagline.Should().Be("Every generation has a story.");
            playbackProgressItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            playbackProgressItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            playbackProgressItem.Movie.Runtime.Should().Be(136);
            playbackProgressItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            playbackProgressItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            playbackProgressItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            playbackProgressItem.Movie.Rating.Should().Be(8.31988f);
            playbackProgressItem.Movie.Votes.Should().Be(9338);
            playbackProgressItem.Movie.LanguageCode.Should().Be("en");
            playbackProgressItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            playbackProgressItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            playbackProgressItem.Movie.Certification.Should().Be("PG-13");
            playbackProgressItem.Show.Should().BeNull();
            playbackProgressItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncPlaybackProgressItem_With_Type_Episode_From_Full_Json()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();
            var playbackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_FULL_JSON) as TraktSyncPlaybackProgressItem;

            playbackProgressItem.Should().NotBeNull();
            playbackProgressItem.Id.Should().Be(37U);
            playbackProgressItem.Progress.Should().Be(65.5f);
            playbackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            playbackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            playbackProgressItem.Episode.Should().NotBeNull();
            playbackProgressItem.Episode.SeasonNumber.Should().Be(1);
            playbackProgressItem.Episode.Number.Should().Be(1);
            playbackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            playbackProgressItem.Episode.Ids.Should().NotBeNull();
            playbackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            playbackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            playbackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            playbackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            playbackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            playbackProgressItem.Episode.NumberAbsolute.Should().Be(50);
            playbackProgressItem.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            playbackProgressItem.Episode.Runtime.Should().Be(55);
            playbackProgressItem.Episode.Rating.Should().Be(9.0f);
            playbackProgressItem.Episode.Votes.Should().Be(111);
            playbackProgressItem.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            playbackProgressItem.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            playbackProgressItem.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            playbackProgressItem.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = playbackProgressItem.Episode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");

            playbackProgressItem.Show.Should().NotBeNull();
            playbackProgressItem.Show.Title.Should().Be("Game of Thrones");
            playbackProgressItem.Show.Year.Should().Be(2011);
            playbackProgressItem.Show.Airs.Should().NotBeNull();
            playbackProgressItem.Show.Airs.Day.Should().Be("Sunday");
            playbackProgressItem.Show.Airs.Time.Should().Be("21:00");
            playbackProgressItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            playbackProgressItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            playbackProgressItem.Show.Ids.Should().NotBeNull();
            playbackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            playbackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            playbackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            playbackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            playbackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            playbackProgressItem.Show.Ids.TvRage.Should().Be(24493U);
            playbackProgressItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            playbackProgressItem.Show.Seasons.Should().BeNull();
            playbackProgressItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            playbackProgressItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            playbackProgressItem.Show.Runtime.Should().Be(60);
            playbackProgressItem.Show.Certification.Should().Be("TV-MA");
            playbackProgressItem.Show.Network.Should().Be("HBO");
            playbackProgressItem.Show.CountryCode.Should().Be("us");
            playbackProgressItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            playbackProgressItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            playbackProgressItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            playbackProgressItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            playbackProgressItem.Show.Rating.Should().Be(9.38327f);
            playbackProgressItem.Show.Votes.Should().Be(44773);
            playbackProgressItem.Show.LanguageCode.Should().Be("en");
            playbackProgressItem.Show.AiredEpisodes.Should().Be(50);

            playbackProgressItem.Movie.Should().BeNull();
        }

        private const string TYPE_MOVIE_MINIMAL_JSON =
            @"{
                ""id"": 37,
                ""progress"": 65.5,
                ""paused_at"": ""2015-01-25T22:01:32.000Z"",
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
                ""id"": 37,
                ""progress"": 65.5,
                ""paused_at"": ""2015-01-25T22:01:32.000Z"",
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
                ""id"": 37,
                ""progress"": 65.5,
                ""paused_at"": ""2015-01-25T22:01:32.000Z"",
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
                ""id"": 37,
                ""progress"": 65.5,
                ""paused_at"": ""2015-01-25T22:01:32.000Z"",
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
