namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_COMPLETE.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_7.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_8.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_9.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_INCOMPLETE_10.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_HistoryItemObjectJsonReader_Movie_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_MOVIE_JSON_NOT_VALID_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

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
