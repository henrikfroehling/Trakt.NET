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
    public partial class ITraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_COMPLETE.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_7.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_8.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_9.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_10.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().NotBeNull();
                traktHistoryItem.Show.Title.Should().Be("Game of Thrones");
                traktHistoryItem.Show.Year.Should().Be(2011);
                traktHistoryItem.Show.Ids.Should().NotBeNull();
                traktHistoryItem.Show.Ids.Trakt.Should().Be(1390U);
                traktHistoryItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktHistoryItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktHistoryItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktHistoryItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktHistoryItem.Show.Ids.TvRage.Should().Be(24493U);

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982348UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Show);
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
            }
        }
    }
}
