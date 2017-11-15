namespace TraktApiSharp.Tests.Objects.Get.Watchlist.Json
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watchlist.Json;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_COMPLETE);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().NotBeNull();
            traktWatchlistItem.Season.Number.Should().Be(1);
            traktWatchlistItem.Season.Ids.Should().NotBeNull();
            traktWatchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            traktWatchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktWatchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktWatchlistItem.Season.Ids.TvRage.Should().Be(36939U);

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_1);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().NotBeNull();
            traktWatchlistItem.Season.Number.Should().Be(1);
            traktWatchlistItem.Season.Ids.Should().NotBeNull();
            traktWatchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            traktWatchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktWatchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktWatchlistItem.Season.Ids.TvRage.Should().Be(36939U);

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_2);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Season.Should().NotBeNull();
            traktWatchlistItem.Season.Number.Should().Be(1);
            traktWatchlistItem.Season.Ids.Should().NotBeNull();
            traktWatchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            traktWatchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktWatchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktWatchlistItem.Season.Ids.TvRage.Should().Be(36939U);

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_3);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_4);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_5);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_6);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Season.Should().NotBeNull();
            traktWatchlistItem.Season.Number.Should().Be(1);
            traktWatchlistItem.Season.Ids.Should().NotBeNull();
            traktWatchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            traktWatchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktWatchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktWatchlistItem.Season.Ids.TvRage.Should().Be(36939U);

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_1);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().NotBeNull();
            traktWatchlistItem.Season.Number.Should().Be(1);
            traktWatchlistItem.Season.Ids.Should().NotBeNull();
            traktWatchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            traktWatchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktWatchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktWatchlistItem.Season.Ids.TvRage.Should().Be(36939U);

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_2);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Season.Should().NotBeNull();
            traktWatchlistItem.Season.Number.Should().Be(1);
            traktWatchlistItem.Season.Ids.Should().NotBeNull();
            traktWatchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            traktWatchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktWatchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktWatchlistItem.Season.Ids.TvRage.Should().Be(36939U);

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_3);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_4);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }
    }
}
