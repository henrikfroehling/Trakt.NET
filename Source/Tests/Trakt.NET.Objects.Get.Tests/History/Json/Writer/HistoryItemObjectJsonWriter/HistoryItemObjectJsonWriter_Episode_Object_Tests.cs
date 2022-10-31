namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.History.Json.Writer;
    using TraktNet.Objects.Get.Shows;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Only_ID_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Only_WatchedAt_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Only_Action_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Episode
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""type"":""episode""}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Only_Episode_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
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
                }
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                             @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055"",""tmdb"":63056,""tvrage"":1065008299}}}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Only_Show_Property()
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

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                             @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Episode_WriteObject_Object_Complete()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
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
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":1982347," +
                             $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""action"":""checkin"",""type"":""episode""," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                             @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}}," +
                             @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                             @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055"",""tmdb"":63056,""tvrage"":1065008299}}}");
        }
    }
}
