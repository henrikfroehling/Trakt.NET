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
    using TraktNet.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktHistoryItem);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Only_ID_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Only_WatchedAt_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Only_Action_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Show
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":0,""type"":""show""}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Only_Show_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":0,""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                 @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                 @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Show_WriteObject_StringWriter_Complete()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktHistoryItem);
                json.Should().Be(@"{""id"":1982347," +
                                 $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""action"":""checkin"",""type"":""show""," +
                                 @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                 @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                 @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}");
            }
        }
    }
}
