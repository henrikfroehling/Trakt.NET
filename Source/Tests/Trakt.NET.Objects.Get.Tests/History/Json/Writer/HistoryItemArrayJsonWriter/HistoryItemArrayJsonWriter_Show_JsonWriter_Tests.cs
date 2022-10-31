namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Show_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Show,
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
                                                    @"""action"":""checkin"",""type"":""show""," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}]");
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Show_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Show,
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
                    Type = TraktSyncItemType.Show,
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
                                                    @"""action"":""checkin"",""type"":""show""," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}," +
                                                    @"{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""show""," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}]");
            }
        }
    }
}
