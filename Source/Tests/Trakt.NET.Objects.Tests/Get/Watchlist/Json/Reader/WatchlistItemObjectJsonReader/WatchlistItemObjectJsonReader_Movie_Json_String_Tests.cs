namespace TraktNet.Objects.Tests.Get.Watchlist.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_COMPLETE);

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

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_3);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
            traktWatchlistItem.Movie.Should().BeNull();

            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_4);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Movie.Should().BeNull();

            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_5);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
            traktWatchlistItem.Movie.Should().BeNull();

            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_6);

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

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_3);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
            traktWatchlistItem.Movie.Should().BeNull();

            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_4);

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
