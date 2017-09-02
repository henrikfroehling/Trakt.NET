namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().NotBeNull();
                traktUserWatchingItem.Show.Title.Should().Be("Game of Thrones");
                traktUserWatchingItem.Show.Year.Should().Be(2011);
                traktUserWatchingItem.Show.Ids.Should().NotBeNull();
                traktUserWatchingItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserWatchingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserWatchingItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserWatchingItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserWatchingItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserWatchingItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Episode);
                traktUserWatchingItem.Episode.Should().NotBeNull();
                traktUserWatchingItem.Episode.SeasonNumber.Should().Be(1);
                traktUserWatchingItem.Episode.Number.Should().Be(1);
                traktUserWatchingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktUserWatchingItem.Episode.Ids.Should().NotBeNull();
                traktUserWatchingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktUserWatchingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktUserWatchingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktUserWatchingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktUserWatchingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_EPISODE_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
            }
        }
    }
}
