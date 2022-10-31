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
    using TraktNet.Objects.Get.Movies;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktHistoryItem);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Only_ID_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Only_WatchedAt_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Only_Action_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Movie
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":0,""type"":""movie""}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Only_Movie_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024U,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607U
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new HistoryItemObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktHistoryItem);
                stringWriter.ToString().Should().Be(@"{""id"":0,""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}");
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_JsonWriter_Complete()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Id = 1982347UL,
                WatchedAt = WATCHED_AT,
                Action = TraktHistoryActionType.Checkin,
                Type = TraktSyncItemType.Movie,
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024U,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607U
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
                                                    @"""action"":""checkin"",""type"":""movie""," +
                                                    @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}");
            }
        }
    }
}
