namespace TraktApiSharp.Tests.Objects.Get.Watchlist.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watchlist.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class TraktWatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_COMPLETE);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_1);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_2);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_3);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_4);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktWatchlistItem.Show.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_5);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_6);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_7);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktWatchlistItem.Show.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_8);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_1);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_2);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_3);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().BeNull();
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
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_4);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktWatchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            traktWatchlistItem.Episode.Should().NotBeNull();
            traktWatchlistItem.Episode.SeasonNumber.Should().Be(1);
            traktWatchlistItem.Episode.Number.Should().Be(1);
            traktWatchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            traktWatchlistItem.Episode.Ids.Should().NotBeNull();
            traktWatchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktWatchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktWatchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktWatchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktWatchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktWatchlistItem.Show.Should().BeNull();

            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_5);

            traktWatchlistItem.Should().NotBeNull();
            traktWatchlistItem.ListedAt.Should().BeNull();
            traktWatchlistItem.Type.Should().BeNull();
            traktWatchlistItem.Episode.Should().BeNull();
            traktWatchlistItem.Show.Should().BeNull();
            traktWatchlistItem.Movie.Should().BeNull();
            traktWatchlistItem.Season.Should().BeNull();
        }
    }
}
