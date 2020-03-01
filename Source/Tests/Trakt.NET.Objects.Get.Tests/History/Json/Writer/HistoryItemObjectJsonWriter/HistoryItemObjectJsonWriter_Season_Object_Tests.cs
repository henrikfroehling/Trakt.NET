namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using System;
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
        public void Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Only_ID_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Id = 1982347UL
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":1982347}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Only_WatchedAt_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                WatchedAt = WATCHED_AT
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be($"{{\"id\":0,\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Only_Action_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Action = TraktHistoryActionType.Checkin
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""action"":""checkin""}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Season
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""type"":""season""}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Only_Season_Property()
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

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""season"":{""number"":1," +
                             @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Season_WriteObject_Object_Complete()
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

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":1982347," +
                             $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""action"":""checkin"",""type"":""season""," +
                             @"""season"":{""number"":1," +
                             @"""ids"":{""trakt"":61430,""tvdb"":279121,""tmdb"":60523,""tvrage"":36939}}}");
        }
    }
}
