namespace TraktApiSharp.Tests.Objects.Get.Watchlist.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watchlist.Json;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktWatchlistItem.Movie.Should().NotBeNull();
                traktWatchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchlistItem.Movie.Year.Should().Be(2015);
                traktWatchlistItem.Movie.Ids.Should().NotBeNull();
                traktWatchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktWatchlistItem.Movie.Should().NotBeNull();
                traktWatchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchlistItem.Movie.Year.Should().Be(2015);
                traktWatchlistItem.Movie.Ids.Should().NotBeNull();
                traktWatchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Movie.Should().NotBeNull();
                traktWatchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchlistItem.Movie.Year.Should().Be(2015);
                traktWatchlistItem.Movie.Ids.Should().NotBeNull();
                traktWatchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktWatchlistItem.Movie.Should().BeNull();

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Movie.Should().BeNull();

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktWatchlistItem.Movie.Should().BeNull();

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Movie.Should().NotBeNull();
                traktWatchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchlistItem.Movie.Year.Should().Be(2015);
                traktWatchlistItem.Movie.Ids.Should().NotBeNull();
                traktWatchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktWatchlistItem.Movie.Should().NotBeNull();
                traktWatchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchlistItem.Movie.Year.Should().Be(2015);
                traktWatchlistItem.Movie.Ids.Should().NotBeNull();
                traktWatchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Movie.Should().NotBeNull();
                traktWatchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktWatchlistItem.Movie.Year.Should().Be(2015);
                traktWatchlistItem.Movie.Ids.Should().NotBeNull();
                traktWatchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktWatchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktWatchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktWatchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
                traktWatchlistItem.Movie.Should().BeNull();

                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }
    }
}
