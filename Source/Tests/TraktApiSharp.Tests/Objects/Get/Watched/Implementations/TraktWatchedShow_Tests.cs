namespace TraktApiSharp.Tests.Objects.Get.Watched.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watched.Implementations;
    using TraktApiSharp.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.Implementations")]
    public class TraktWatchedShow_Tests
    {
        [Fact]
        public void Test_TraktWatchedShow_Default_Constructor()
        {
            var watchedShow = new TraktWatchedShow();

            watchedShow.Plays.Should().NotHaveValue();
            watchedShow.LastWatchedAt.Should().NotHaveValue();
            watchedShow.Show.Should().BeNull();
            watchedShow.WatchedSeasons.Should().BeNull();

            watchedShow.Title.Should().BeNullOrEmpty();
            watchedShow.Year.Should().NotHaveValue();
            watchedShow.Airs.Should().BeNull();
            watchedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            watchedShow.Ids.Should().BeNull();
            watchedShow.Genres.Should().BeNull();
            watchedShow.Seasons.Should().BeNull();
            watchedShow.Overview.Should().BeNullOrEmpty();
            watchedShow.FirstAired.Should().NotHaveValue();
            watchedShow.Runtime.Should().NotHaveValue();
            watchedShow.Certification.Should().BeNullOrEmpty();
            watchedShow.Network.Should().BeNullOrEmpty();
            watchedShow.CountryCode.Should().BeNullOrEmpty();
            watchedShow.UpdatedAt.Should().NotHaveValue();
            watchedShow.Trailer.Should().BeNullOrEmpty();
            watchedShow.Homepage.Should().BeNullOrEmpty();
            watchedShow.Status.Should().BeNull();
            watchedShow.Rating.Should().NotHaveValue();
            watchedShow.Votes.Should().NotHaveValue();
            watchedShow.LanguageCode.Should().BeNullOrEmpty();
            watchedShow.AiredEpisodes.Should().NotHaveValue();
        }

        [Fact]
        public async Task Test_TraktWatchedShow_From_Minimal_Json()
        {
            var jsonReader = new WatchedShowObjectJsonReader();
            var watchedShow = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktWatchedShow;

            watchedShow.Should().NotBeNull();
            watchedShow.Plays.Should().Be(20);
            watchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            watchedShow.Show.Should().NotBeNull();
            watchedShow.Show.Title.Should().Be("Game of Thrones");
            watchedShow.Show.Year.Should().Be(2011);
            watchedShow.Show.Airs.Should().BeNull();
            watchedShow.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            watchedShow.Show.Ids.Should().NotBeNull();
            watchedShow.Show.Ids.Trakt.Should().Be(1390U);
            watchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            watchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            watchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            watchedShow.Show.Ids.TvRage.Should().Be(24493U);
            watchedShow.Show.Genres.Should().BeNull();
            watchedShow.Show.Seasons.Should().BeNull();
            watchedShow.Show.Overview.Should().BeNullOrEmpty();
            watchedShow.Show.FirstAired.Should().NotHaveValue();
            watchedShow.Show.Runtime.Should().NotHaveValue();
            watchedShow.Show.Certification.Should().BeNullOrEmpty();
            watchedShow.Show.Network.Should().BeNullOrEmpty();
            watchedShow.Show.CountryCode.Should().BeNullOrEmpty();
            watchedShow.Show.UpdatedAt.Should().NotHaveValue();
            watchedShow.Show.Trailer.Should().BeNullOrEmpty();
            watchedShow.Show.Homepage.Should().BeNullOrEmpty();
            watchedShow.Show.Status.Should().BeNull();
            watchedShow.Show.Rating.Should().NotHaveValue();
            watchedShow.Show.Votes.Should().NotHaveValue();
            watchedShow.Show.LanguageCode.Should().BeNullOrEmpty();
            watchedShow.Show.AiredEpisodes.Should().NotHaveValue();

            watchedShow.Title.Should().Be("Game of Thrones");
            watchedShow.Year.Should().Be(2011);
            watchedShow.Airs.Should().BeNull();
            watchedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            watchedShow.Ids.Should().NotBeNull();
            watchedShow.Ids.Trakt.Should().Be(1390U);
            watchedShow.Ids.Slug.Should().Be("game-of-thrones");
            watchedShow.Ids.Tvdb.Should().Be(121361U);
            watchedShow.Ids.Imdb.Should().Be("tt0944947");
            watchedShow.Ids.Tmdb.Should().Be(1399U);
            watchedShow.Ids.TvRage.Should().Be(24493U);
            watchedShow.Genres.Should().BeNull();
            watchedShow.Seasons.Should().BeNull();
            watchedShow.Overview.Should().BeNullOrEmpty();
            watchedShow.FirstAired.Should().NotHaveValue();
            watchedShow.Runtime.Should().NotHaveValue();
            watchedShow.Certification.Should().BeNullOrEmpty();
            watchedShow.Network.Should().BeNullOrEmpty();
            watchedShow.CountryCode.Should().BeNullOrEmpty();
            watchedShow.UpdatedAt.Should().NotHaveValue();
            watchedShow.Trailer.Should().BeNullOrEmpty();
            watchedShow.Homepage.Should().BeNullOrEmpty();
            watchedShow.Status.Should().BeNull();
            watchedShow.Rating.Should().NotHaveValue();
            watchedShow.Votes.Should().NotHaveValue();
            watchedShow.LanguageCode.Should().BeNullOrEmpty();
            watchedShow.AiredEpisodes.Should().NotHaveValue();

            watchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = watchedShow.WatchedSeasons.ToArray();

            // Season 1
            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1
            var episodesSeason1 = seasons[0].Episodes.ToArray();

            episodesSeason1[0].Should().NotBeNull();
            episodesSeason1[0].Number.Should().Be(1);
            episodesSeason1[0].Plays.Should().Be(5);
            episodesSeason1[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodesSeason1[1].Should().NotBeNull();
            episodesSeason1[1].Number.Should().Be(2);
            episodesSeason1[1].Plays.Should().Be(5);
            episodesSeason1[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            // Season 2
            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull();
            seasons[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2
            var episodesSeason2 = seasons[1].Episodes.ToArray();

            episodesSeason2[0].Should().NotBeNull();
            episodesSeason2[0].Number.Should().Be(1);
            episodesSeason2[0].Plays.Should().Be(5);
            episodesSeason2[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodesSeason2[1].Should().NotBeNull();
            episodesSeason2[1].Number.Should().Be(2);
            episodesSeason2[1].Plays.Should().Be(5);
            episodesSeason2[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktWatchedShow_From_Full_Json()
        {
            var jsonReader = new WatchedShowObjectJsonReader();
            var watchedShow = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktWatchedShow;

            watchedShow.Should().NotBeNull();
            watchedShow.Plays.Should().Be(20);
            watchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            watchedShow.Show.Should().NotBeNull();
            watchedShow.Show.Title.Should().Be("Game of Thrones");
            watchedShow.Show.Year.Should().Be(2011);
            watchedShow.Show.Airs.Should().NotBeNull();
            watchedShow.Show.Airs.Day.Should().Be("Sunday");
            watchedShow.Show.Airs.Time.Should().Be("21:00");
            watchedShow.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            watchedShow.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            watchedShow.Show.Ids.Should().NotBeNull();
            watchedShow.Show.Ids.Trakt.Should().Be(1390U);
            watchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            watchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            watchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            watchedShow.Show.Ids.TvRage.Should().Be(24493U);
            watchedShow.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            watchedShow.Show.Seasons.Should().BeNull();
            watchedShow.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchedShow.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            watchedShow.Show.Runtime.Should().Be(60);
            watchedShow.Show.Certification.Should().Be("TV-MA");
            watchedShow.Show.Network.Should().Be("HBO");
            watchedShow.Show.CountryCode.Should().Be("us");
            watchedShow.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            watchedShow.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchedShow.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            watchedShow.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            watchedShow.Show.Rating.Should().Be(9.38327f);
            watchedShow.Show.Votes.Should().Be(44773);
            watchedShow.Show.LanguageCode.Should().Be("en");
            watchedShow.Show.AiredEpisodes.Should().Be(50);

            watchedShow.Title.Should().Be("Game of Thrones");
            watchedShow.Year.Should().Be(2011);
            watchedShow.Airs.Should().NotBeNull();
            watchedShow.Airs.Day.Should().Be("Sunday");
            watchedShow.Airs.Time.Should().Be("21:00");
            watchedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            watchedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            watchedShow.Ids.Should().NotBeNull();
            watchedShow.Ids.Trakt.Should().Be(1390U);
            watchedShow.Ids.Slug.Should().Be("game-of-thrones");
            watchedShow.Ids.Tvdb.Should().Be(121361U);
            watchedShow.Ids.Imdb.Should().Be("tt0944947");
            watchedShow.Ids.Tmdb.Should().Be(1399U);
            watchedShow.Ids.TvRage.Should().Be(24493U);
            watchedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            watchedShow.Seasons.Should().BeNull();
            watchedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            watchedShow.Runtime.Should().Be(60);
            watchedShow.Certification.Should().Be("TV-MA");
            watchedShow.Network.Should().Be("HBO");
            watchedShow.CountryCode.Should().Be("us");
            watchedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            watchedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            watchedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            watchedShow.Rating.Should().Be(9.38327f);
            watchedShow.Votes.Should().Be(44773);
            watchedShow.LanguageCode.Should().Be("en");
            watchedShow.AiredEpisodes.Should().Be(50);

            watchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = watchedShow.WatchedSeasons.ToArray();

            // Season 1
            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1
            var episodesSeason1 = seasons[0].Episodes.ToArray();

            episodesSeason1[0].Should().NotBeNull();
            episodesSeason1[0].Number.Should().Be(1);
            episodesSeason1[0].Plays.Should().Be(5);
            episodesSeason1[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodesSeason1[1].Should().NotBeNull();
            episodesSeason1[1].Number.Should().Be(2);
            episodesSeason1[1].Plays.Should().Be(5);
            episodesSeason1[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            // Season 2
            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull();
            seasons[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2
            var episodesSeason2 = seasons[1].Episodes.ToArray();

            episodesSeason2[0].Should().NotBeNull();
            episodesSeason2[0].Number.Should().Be(1);
            episodesSeason2[0].Plays.Should().Be(5);
            episodesSeason2[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodesSeason2[1].Should().NotBeNull();
            episodesSeason2[1].Number.Should().Be(2);
            episodesSeason2[1].Plays.Should().Be(5);
            episodesSeason2[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        private const string MINIMAL_JSON =
            @"{
                ""plays"": 20,
                ""last_watched_at"": ""2014-07-14T01:00:00.000Z"",
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
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      },
                      {
                        ""number"": 2,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      },
                      {
                        ""number"": 2,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      }
                    ]
                  }
                ]
              }";

        private const string FULL_JSON =
            @"{
                ""plays"": 20,
                ""last_watched_at"": ""2014-07-14T01:00:00.000Z"",
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
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      },
                      {
                        ""number"": 2,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      },
                      {
                        ""number"": 2,
                        ""plays"": 5,
                        ""last_watched_at"": ""2014-09-01T09:10:11.000Z""
                      }
                    ]
                  }
                ]
              }";
    }
}
