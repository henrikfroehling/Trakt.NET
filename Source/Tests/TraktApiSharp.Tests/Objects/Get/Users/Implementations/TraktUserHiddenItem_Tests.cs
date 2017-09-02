namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserHiddenItem_Tests
    {
        [Fact]
        public void Test_TraktUserHiddenItem_Implements_ITraktUserHiddenItem_Interface()
        {
            typeof(TraktUserHiddenItem).GetInterfaces().Should().Contain(typeof(ITraktUserHiddenItem));
        }

        [Fact]
        public void Test_TraktUserHiddenItem_Default_Constructor()
        {
            var hiddenItem = new TraktUserHiddenItem();

            hiddenItem.HiddenAt.Should().BeNull();
            hiddenItem.Type.Should().BeNull();
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            hiddenItem.Movie.Should().NotBeNull();
            hiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            hiddenItem.Movie.Year.Should().Be(2015);
            hiddenItem.Movie.Ids.Should().NotBeNull();
            hiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            hiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            hiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            hiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);
            hiddenItem.Movie.Tagline.Should().BeNullOrEmpty();
            hiddenItem.Movie.Overview.Should().BeNullOrEmpty();
            hiddenItem.Movie.Released.Should().NotHaveValue();
            hiddenItem.Movie.Runtime.Should().NotHaveValue();
            hiddenItem.Movie.UpdatedAt.Should().NotHaveValue();
            hiddenItem.Movie.Trailer.Should().BeNullOrEmpty();
            hiddenItem.Movie.Homepage.Should().BeNullOrEmpty();
            hiddenItem.Movie.Rating.Should().NotHaveValue();
            hiddenItem.Movie.Votes.Should().NotHaveValue();
            hiddenItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            hiddenItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            hiddenItem.Movie.Genres.Should().BeNull();
            hiddenItem.Movie.Certification.Should().BeNullOrEmpty();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Show_From_Minimal_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_MINIMAL_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().NotBeNull();
            hiddenItem.Show.Title.Should().Be("Game of Thrones");
            hiddenItem.Show.Year.Should().Be(2011);
            hiddenItem.Show.Airs.Should().BeNull();
            hiddenItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            hiddenItem.Show.Ids.Should().NotBeNull();
            hiddenItem.Show.Ids.Trakt.Should().Be(1390U);
            hiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            hiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
            hiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
            hiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
            hiddenItem.Show.Ids.TvRage.Should().Be(24493U);
            hiddenItem.Show.Genres.Should().BeNull();
            hiddenItem.Show.Seasons.Should().BeNull();
            hiddenItem.Show.Overview.Should().BeNullOrEmpty();
            hiddenItem.Show.FirstAired.Should().NotHaveValue();
            hiddenItem.Show.Runtime.Should().NotHaveValue();
            hiddenItem.Show.Certification.Should().BeNullOrEmpty();
            hiddenItem.Show.Network.Should().BeNullOrEmpty();
            hiddenItem.Show.CountryCode.Should().BeNullOrEmpty();
            hiddenItem.Show.UpdatedAt.Should().NotHaveValue();
            hiddenItem.Show.Trailer.Should().BeNullOrEmpty();
            hiddenItem.Show.Homepage.Should().BeNullOrEmpty();
            hiddenItem.Show.Status.Should().BeNull();
            hiddenItem.Show.Rating.Should().NotHaveValue();
            hiddenItem.Show.Votes.Should().NotHaveValue();
            hiddenItem.Show.LanguageCode.Should().BeNullOrEmpty();
            hiddenItem.Show.AiredEpisodes.Should().NotHaveValue();
            hiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Season_From_Minimal_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_MINIMAL_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().NotBeNull();
            hiddenItem.Season.Number.Should().Be(1);
            hiddenItem.Season.Ids.Should().NotBeNull();
            hiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            hiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            hiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            hiddenItem.Season.Ids.TvRage.Should().Be(36939U);
            hiddenItem.Season.Rating.Should().NotHaveValue();
            hiddenItem.Season.Votes.Should().NotHaveValue();
            hiddenItem.Season.TotalEpisodesCount.Should().NotHaveValue();
            hiddenItem.Season.AiredEpisodesCount.Should().NotHaveValue();
            hiddenItem.Season.Overview.Should().BeNullOrEmpty();
            hiddenItem.Season.FirstAired.Should().NotHaveValue();
            hiddenItem.Season.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            hiddenItem.Movie.Should().NotBeNull();
            hiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            hiddenItem.Movie.Year.Should().Be(2015);
            hiddenItem.Movie.Ids.Should().NotBeNull();
            hiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            hiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            hiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            hiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);
            hiddenItem.Movie.Tagline.Should().Be("Every generation has a story.");
            hiddenItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            hiddenItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            hiddenItem.Movie.Runtime.Should().Be(136);
            hiddenItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            hiddenItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            hiddenItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            hiddenItem.Movie.Rating.Should().Be(8.31988f);
            hiddenItem.Movie.Votes.Should().Be(9338);
            hiddenItem.Movie.LanguageCode.Should().Be("en");
            hiddenItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            hiddenItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            hiddenItem.Movie.Certification.Should().Be("PG-13");
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Show_From_Full_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_FULL_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().NotBeNull();
            hiddenItem.Show.Title.Should().Be("Game of Thrones");
            hiddenItem.Show.Year.Should().Be(2011);
            hiddenItem.Show.Airs.Should().NotBeNull();
            hiddenItem.Show.Airs.Day.Should().Be("Sunday");
            hiddenItem.Show.Airs.Time.Should().Be("21:00");
            hiddenItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            hiddenItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            hiddenItem.Show.Ids.Should().NotBeNull();
            hiddenItem.Show.Ids.Trakt.Should().Be(1390U);
            hiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            hiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
            hiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
            hiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
            hiddenItem.Show.Ids.TvRage.Should().Be(24493U);
            hiddenItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            hiddenItem.Show.Seasons.Should().BeNull();
            hiddenItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            hiddenItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            hiddenItem.Show.Runtime.Should().Be(60);
            hiddenItem.Show.Certification.Should().Be("TV-MA");
            hiddenItem.Show.Network.Should().Be("HBO");
            hiddenItem.Show.CountryCode.Should().Be("us");
            hiddenItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            hiddenItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            hiddenItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            hiddenItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            hiddenItem.Show.Rating.Should().Be(9.38327f);
            hiddenItem.Show.Votes.Should().Be(44773);
            hiddenItem.Show.LanguageCode.Should().Be("en");
            hiddenItem.Show.AiredEpisodes.Should().Be(50);
            hiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserHiddenItem_With_Type_Season_From_Full_Json()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            var hiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_FULL_JSON) as TraktUserHiddenItem;

            hiddenItem.Should().NotBeNull();
            hiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            hiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            hiddenItem.Movie.Should().BeNull();
            hiddenItem.Show.Should().BeNull();
            hiddenItem.Season.Should().NotBeNull();
            hiddenItem.Season.Number.Should().Be(1);
            hiddenItem.Season.Ids.Should().NotBeNull();
            hiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            hiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            hiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            hiddenItem.Season.Ids.TvRage.Should().Be(36939U);
            hiddenItem.Season.Rating.Should().Be(8.57053f);
            hiddenItem.Season.Votes.Should().Be(794);
            hiddenItem.Season.TotalEpisodesCount.Should().Be(23);
            hiddenItem.Season.AiredEpisodesCount.Should().Be(23);
            hiddenItem.Season.Overview.Should().Be("Text text text");
            hiddenItem.Season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            hiddenItem.Season.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = hiddenItem.Season.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        private const string TYPE_MOVIE_MINIMAL_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
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

        private const string TYPE_SHOW_MINIMAL_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
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

        private const string TYPE_SEASON_MINIMAL_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_MOVIE_FULL_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
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

        private const string TYPE_SHOW_FULL_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
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

        private const string TYPE_SEASON_FULL_JSON =
            @"{
                ""hidden_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  },
                  ""rating"": 8.57053,
                  ""votes"": 794,
                  ""episode_count"": 23,
                  ""aired_episodes"": 23,
                  ""overview"": ""Text text text"",
                  ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                  ""episodes"": [
                    {
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
                    {
                      ""season"": 1,
                      ""number"": 2,
                      ""title"": ""The Kingsroad"",
                      ""ids"": {
                        ""trakt"": 74138,
                        ""tvdb"": 3436411,
                        ""imdb"": ""tt1668746"",
                        ""tmdb"": 63141,
                        ""tvrage"": 1325718577
                      }
                    }
                  ]
                }
              }";
    }
}
