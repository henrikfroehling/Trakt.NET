﻿namespace TraktNet.Objects.Get.Tests.Watchlist.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Season_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().BeNull();
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().BeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().BeNull();
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().BeNull();
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().BeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().BeNull();
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
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
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().Be(101U);
            traktWatchlistItem.Rank.Should().Be(1);
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Notes.Should().Be("list item notes");
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            ITraktWatchlistItem traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.Id.Should().BeNull();
            traktWatchlistItem.Rank.Should().BeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Notes.Should().BeNull();
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
        }
    }
}
