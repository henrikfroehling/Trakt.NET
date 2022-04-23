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
    using TraktNet.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Only_ID_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Only_WatchedAt_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Only_Action_Property()
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
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Only_Type_Property()
        {
            ITraktHistoryItem traktHistoryItem = new TraktHistoryItem
            {
                Type = TraktSyncItemType.Movie
            };

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""type"":""movie""}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Only_Movie_Property()
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

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":0,""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_Movie_WriteObject_Object_Complete()
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

            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktHistoryItem);
            json.Should().Be(@"{""id"":1982347," +
                             $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""action"":""checkin"",""type"":""movie""," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }
    }
}
