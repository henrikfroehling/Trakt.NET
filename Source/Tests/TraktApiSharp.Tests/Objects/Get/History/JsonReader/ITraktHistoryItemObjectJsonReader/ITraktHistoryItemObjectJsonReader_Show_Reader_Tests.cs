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
    public partial class ITraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_ITraktHistoryItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
