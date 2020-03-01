namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.History.Json.Writer;
    using TraktNet.Objects.Get.Seasons;
    using Xunit;

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktHistoryItem);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Only_ID_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Id = 1982347UL
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":1982347}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Only_WatchedAt_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                WatchedAt = WATCHED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be($"{{\"id\":0,\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Only_Action_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Action = TraktHistoryActionType.Checkin
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":0,""action"":""checkin""}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Season
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":0,""type"":""season""}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Only_Season_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":0,""season"":{""number"":1," +
                                 @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_StringWriter_Complete()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":1982347," +
                                 $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""action"":""checkin"",""type"":""season""," +
                                 @"""season"":{""number"":1," +
                                 @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}");
            }
        }
    }
}
