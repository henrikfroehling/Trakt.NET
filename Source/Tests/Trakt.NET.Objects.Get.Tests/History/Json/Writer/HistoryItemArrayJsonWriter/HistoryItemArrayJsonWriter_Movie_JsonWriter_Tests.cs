﻿namespace TraktNet.Objects.Get.Tests.History.Json.Writer
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
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Movie_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktHistoryItems);
                stringWriter.ToString().Should().Be(@"[{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""movie""," +
                                                    @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}]");
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_Movie_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<ITraktHistoryItem>
            {
                new TraktHistoryItem
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
                },
                new TraktHistoryItem
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktHistoryItems);
                stringWriter.ToString().Should().Be(@"[{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""movie""," +
                                                    @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}," +
                                                    @"{""id"":1982347," +
                                                    $"\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""action"":""checkin"",""type"":""movie""," +
                                                    @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015"",""imdb"":""tt2488496"",""tmdb"":140607}}}]");
            }
        }
    }
}
