namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        private static readonly DateTime WATCHED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Episode_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Episode,
                    Episode = new TraktEpisode
                    {
                        SeasonNumber = 1,
                        Number = 1,
                        Title = "Winter Is Coming",
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 73640U,
                            Tvdb = 3254641U,
                            Imdb = "tt1480055",
                            Tmdb = 63056U,
                            TvRage = 1065008299U
                        }
                    },
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktHistoryItems);
                stringWriter.ToString().Should().Be(@"[{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""episode""," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                                                    @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                                                    @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055"",""tmdb"":63056,""tvrage"":1065008299}}}]");
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Episode_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Episode,
                    Episode = new TraktEpisode
                    {
                        SeasonNumber = 1,
                        Number = 1,
                        Title = "Winter Is Coming",
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 73640U,
                            Tvdb = 3254641U,
                            Imdb = "tt1480055",
                            Tmdb = 63056U,
                            TvRage = 1065008299U
                        }
                    },
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        }
                    }
                },
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Episode,
                    Episode = new TraktEpisode
                    {
                        SeasonNumber = 1,
                        Number = 1,
                        Title = "Winter Is Coming",
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 73640U,
                            Tvdb = 3254641U,
                            Imdb = "tt1480055",
                            Tmdb = 63056U,
                            TvRage = 1065008299U
                        }
                    },
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktHistoryItems);
                stringWriter.ToString().Should().Be(@"[{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""episode""," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                                                    @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                                                    @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055"",""tmdb"":63056,""tvrage"":1065008299}}}," +
                                                    @"{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""episode""," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                                                    @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                                                    @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055"",""tmdb"":63056,""tvrage"":1065008299}}}]");
            }
        }
    }
}
