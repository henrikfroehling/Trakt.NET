namespace TraktNet.Tests.Objects.Get.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_COMPLETE.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_7.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_8.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_9.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_10.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().NotBeNull();
                traktHistoryItem.Season.Number.Should().Be(1);
                traktHistoryItem.Season.Ids.Should().NotBeNull();
                traktHistoryItem.Season.Ids.Trakt.Should().Be(61430U);
                traktHistoryItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktHistoryItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktHistoryItem.Season.Ids.TvRage.Should().Be(36939U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982344UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Watch);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Season);
                traktHistoryItem.Season.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }
    }
}
