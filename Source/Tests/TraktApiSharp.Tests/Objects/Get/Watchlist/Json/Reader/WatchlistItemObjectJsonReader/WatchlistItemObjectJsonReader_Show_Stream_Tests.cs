namespace TraktNet.Tests.Objects.Get.Watchlist.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_COMPLETE.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Show);
                traktWatchlistItem.Show.Should().NotBeNull();
                traktWatchlistItem.Show.Title.Should().Be("Game of Thrones");
                traktWatchlistItem.Show.Year.Should().Be(2011);
                traktWatchlistItem.Show.Ids.Should().NotBeNull();
                traktWatchlistItem.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchlistItem.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_1.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Show);
                traktWatchlistItem.Show.Should().NotBeNull();
                traktWatchlistItem.Show.Title.Should().Be("Game of Thrones");
                traktWatchlistItem.Show.Year.Should().Be(2011);
                traktWatchlistItem.Show.Ids.Should().NotBeNull();
                traktWatchlistItem.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchlistItem.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_2.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Show.Should().NotBeNull();
                traktWatchlistItem.Show.Title.Should().Be("Game of Thrones");
                traktWatchlistItem.Show.Year.Should().Be(2011);
                traktWatchlistItem.Show.Ids.Should().NotBeNull();
                traktWatchlistItem.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchlistItem.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_3.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Show);
                traktWatchlistItem.Show.Should().BeNull();

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_4.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Show.Should().BeNull();

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_5.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Show);
                traktWatchlistItem.Show.Should().BeNull();

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_6.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Show.Should().NotBeNull();
                traktWatchlistItem.Show.Title.Should().Be("Game of Thrones");
                traktWatchlistItem.Show.Year.Should().Be(2011);
                traktWatchlistItem.Show.Ids.Should().NotBeNull();
                traktWatchlistItem.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchlistItem.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_1.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Show);
                traktWatchlistItem.Show.Should().NotBeNull();
                traktWatchlistItem.Show.Title.Should().Be("Game of Thrones");
                traktWatchlistItem.Show.Year.Should().Be(2011);
                traktWatchlistItem.Show.Ids.Should().NotBeNull();
                traktWatchlistItem.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchlistItem.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_2.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Show.Should().NotBeNull();
                traktWatchlistItem.Show.Title.Should().Be("Game of Thrones");
                traktWatchlistItem.Show.Year.Should().Be(2011);
                traktWatchlistItem.Show.Ids.Should().NotBeNull();
                traktWatchlistItem.Show.Ids.Trakt.Should().Be(1390U);
                traktWatchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktWatchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktWatchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktWatchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktWatchlistItem.Show.Ids.TvRage.Should().Be(24493U);

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_3.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Show);
                traktWatchlistItem.Show.Should().BeNull();

                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_4.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);

                traktWatchlistItem.Should().NotBeNull();
                traktWatchlistItem.ListedAt.Should().BeNull();
                traktWatchlistItem.Type.Should().BeNull();
                traktWatchlistItem.Show.Should().BeNull();
                traktWatchlistItem.Movie.Should().BeNull();
                traktWatchlistItem.Season.Should().BeNull();
                traktWatchlistItem.Episode.Should().BeNull();
            }
        }
    }
}
