namespace TraktApiSharp.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().NotBeNull();
                traktUserWatchingItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktUserWatchingItem.Movie.Year.Should().Be(2015);
                traktUserWatchingItem.Movie.Ids.Should().NotBeNull();
                traktUserWatchingItem.Movie.Ids.Trakt.Should().Be(94024U);
                traktUserWatchingItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktUserWatchingItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktUserWatchingItem.Movie.Ids.Tmdb.Should().Be(140607U);

                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
                traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
                traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
                traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserWatchingItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserWatchingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserWatchingItem.Should().NotBeNull();
                traktUserWatchingItem.StartedAt.Should().BeNull();
                traktUserWatchingItem.ExpiresAt.Should().BeNull();
                traktUserWatchingItem.Action.Should().BeNull();
                traktUserWatchingItem.Type.Should().BeNull();
                traktUserWatchingItem.Movie.Should().BeNull();
                traktUserWatchingItem.Show.Should().BeNull();
                traktUserWatchingItem.Episode.Should().BeNull();
            }
        }
    }
}
