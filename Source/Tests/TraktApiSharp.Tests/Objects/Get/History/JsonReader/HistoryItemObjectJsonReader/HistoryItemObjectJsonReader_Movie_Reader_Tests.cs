namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().BeNull();

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().BeNull();

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().NotBeNull();
                traktHistoryItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktHistoryItem.Movie.Year.Should().Be(2015);
                traktHistoryItem.Movie.Ids.Should().NotBeNull();
                traktHistoryItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktHistoryItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktHistoryItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktHistoryItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982346UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktHistoryItem.Movie.Should().BeNull();

                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }
    }
}
