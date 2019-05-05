namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_COMPLETE.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().BeNull();
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_7.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_8.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_9.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_10.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_11.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_12.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_1.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_2.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_3.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_4.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_5.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().BeNull();
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
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_6.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(1982347UL);
                traktHistoryItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
                traktHistoryItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktHistoryItem.Type.Should().Be(TraktSyncItemType.Episode);
                traktHistoryItem.Episode.Should().NotBeNull();
                traktHistoryItem.Episode.SeasonNumber.Should().Be(1);
                traktHistoryItem.Episode.Number.Should().Be(1);
                traktHistoryItem.Episode.Title.Should().Be("Winter Is Coming");
                traktHistoryItem.Episode.Ids.Should().NotBeNull();
                traktHistoryItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktHistoryItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktHistoryItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktHistoryItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktHistoryItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktHistoryItem.Show.Should().BeNull();

                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_7.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);

                traktHistoryItem.Should().NotBeNull();
                traktHistoryItem.Id.Should().Be(0UL);
                traktHistoryItem.WatchedAt.Should().BeNull();
                traktHistoryItem.Action.Should().BeNull();
                traktHistoryItem.Type.Should().BeNull();
                traktHistoryItem.Episode.Should().BeNull();
                traktHistoryItem.Show.Should().BeNull();
                traktHistoryItem.Movie.Should().BeNull();
                traktHistoryItem.Season.Should().BeNull();
            }
        }
    }
}
