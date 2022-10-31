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
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Season_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Season,
                    Season = new TraktSeason
                    {
                        Number = 1,
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430U,
                            Tvdb = 279121U,
                            Tmdb = 60523U,
                            TvRage = 36939U
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
                                                    @"""action"":""checkin"",""type"":""season""," +
                                                    @"""season"":{""number"":1," +
                                                    @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}]");
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Season_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Season,
                    Season = new TraktSeason
                    {
                        Number = 1,
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430U,
                            Tvdb = 279121U,
                            Tmdb = 60523U,
                            TvRage = 36939U
                        }
                    }
                },
                new TraktHistoryItem
                {
                    Id = 1982347UL,
                    WatchedAt = WATCHED_AT,
                    Action = TraktHistoryActionType.Checkin,
                    Type = TraktSyncItemType.Season,
                    Season = new TraktSeason
                    {
                        Number = 1,
                        Ids = new TraktSeasonIds
                        {
                            Trakt = 61430U,
                            Tvdb = 279121U,
                            Tmdb = 60523U,
                            TvRage = 36939U
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
                                                    @"""action"":""checkin"",""type"":""season""," +
                                                    @"""season"":{""number"":1," +
                                                    @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}," +
                                                    @"{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""season""," +
                                                    @"""season"":{""number"":1," +
                                                    @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}]");
            }
        }
    }
}
