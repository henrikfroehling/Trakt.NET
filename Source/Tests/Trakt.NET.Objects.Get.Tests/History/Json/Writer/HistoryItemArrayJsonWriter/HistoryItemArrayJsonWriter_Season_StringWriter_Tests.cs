﻿namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
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

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Season_WriteArray_StringWriter_SingleObject()
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
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktHistoryItems);
                json.Should().Be(@"[{""id"":1982347," +
                                 $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""action"":""checkin"",""type"":""season""," +
                                 @"""season"":{""number"":1," +
                                 @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}]");
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Season_WriteArray_StringWriter_Complete()
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
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktHistoryItems);
                json.Should().Be(@"[{""id"":1982347," +
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
