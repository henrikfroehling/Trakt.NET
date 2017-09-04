namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_COMPLETE.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_1.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_2.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_3.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_4.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_5.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_6.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_7.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_8.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_9.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_10.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_11.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_12.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_1.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_2.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_3.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_4.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_5.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_6.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserWatchingItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_7.ToStream())
            {
                var traktUserWatchingItem = await jsonReader.ReadObjectAsync(stream);

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
