namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Syncs.Playback.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.JsonReader")]
    public partial class SyncPlaybackProgressItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_COMPLETE);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_1);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_2);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_3);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_4);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_5);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().BeNull();

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_6);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_7);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().BeNull();
            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_8);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().BeNull();
            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_9);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().BeNull();
            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_10);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().BeNull();
            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_11);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_12);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().BeNull();

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_1);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_2);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_3);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_4);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_5);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().BeNull();

            traktPlaybackProgressItem.Show.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Title.Should().Be("Game of Thrones");
            traktPlaybackProgressItem.Show.Year.Should().Be(2011);
            traktPlaybackProgressItem.Show.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Show.Ids.Trakt.Should().Be(1390U);
            traktPlaybackProgressItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktPlaybackProgressItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktPlaybackProgressItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktPlaybackProgressItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktPlaybackProgressItem.Show.Ids.TvRage.Should().Be(24493U);

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_6);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(37U);
            traktPlaybackProgressItem.Progress.Should().Be(65.5f);
            traktPlaybackProgressItem.PausedAt.Should().Be(DateTime.Parse("2015-01-25T22:01:32.000Z").ToUniversalTime());
            traktPlaybackProgressItem.Type.Should().Be(TraktSyncType.Episode);
            traktPlaybackProgressItem.Episode.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.SeasonNumber.Should().Be(1);
            traktPlaybackProgressItem.Episode.Number.Should().Be(1);
            traktPlaybackProgressItem.Episode.Title.Should().Be("Winter Is Coming");
            traktPlaybackProgressItem.Episode.Ids.Should().NotBeNull();
            traktPlaybackProgressItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktPlaybackProgressItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktPlaybackProgressItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktPlaybackProgressItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktPlaybackProgressItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktPlaybackProgressItem.Show.Should().BeNull();

            traktPlaybackProgressItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncPlaybackProgressItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new SyncPlaybackProgressItemObjectJsonReader();

            var traktPlaybackProgressItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_7);

            traktPlaybackProgressItem.Should().NotBeNull();
            traktPlaybackProgressItem.Id.Should().Be(0U);
            traktPlaybackProgressItem.Progress.Should().BeNull();
            traktPlaybackProgressItem.PausedAt.Should().BeNull();
            traktPlaybackProgressItem.Type.Should().BeNull();
            traktPlaybackProgressItem.Episode.Should().BeNull();
            traktPlaybackProgressItem.Show.Should().BeNull();
            traktPlaybackProgressItem.Movie.Should().BeNull();
        }
    }
}
