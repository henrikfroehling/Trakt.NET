namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktHistoryItem);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Only_ID_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Id = 1982347UL
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":1982347}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Only_WatchedAt_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                WatchedAt = WATCHED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be($"{{\"id\":0,\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Only_Action_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Action = TraktHistoryActionType.Checkin
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":0,""action"":""checkin""}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Season
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":0,""type"":""season""}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Only_Season_Property()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":0,""season"":{""number"":1," +
                                                    @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""season""," +
                                                    @"""season"":{""number"":1," +
                                                    @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}");
            }
        }
    }
}
