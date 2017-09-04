namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserWatchingItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_COMPLETE);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_3);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_4);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_5);

            traktUserWatchingItem.Should().NotBeNull();
            traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
            traktUserWatchingItem.Movie.Should().BeNull();
            traktUserWatchingItem.Show.Should().BeNull();
            traktUserWatchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_6);

            traktUserWatchingItem.Should().NotBeNull();
            traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            traktUserWatchingItem.ExpiresAt.Should().BeNull();
            traktUserWatchingItem.Action.Should().BeNull();
            traktUserWatchingItem.Type.Should().BeNull();
            traktUserWatchingItem.Movie.Should().BeNull();
            traktUserWatchingItem.Show.Should().BeNull();
            traktUserWatchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_7);

            traktUserWatchingItem.Should().NotBeNull();
            traktUserWatchingItem.StartedAt.Should().BeNull();
            traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            traktUserWatchingItem.Action.Should().BeNull();
            traktUserWatchingItem.Type.Should().BeNull();
            traktUserWatchingItem.Movie.Should().BeNull();
            traktUserWatchingItem.Show.Should().BeNull();
            traktUserWatchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_8);

            traktUserWatchingItem.Should().NotBeNull();
            traktUserWatchingItem.StartedAt.Should().BeNull();
            traktUserWatchingItem.ExpiresAt.Should().BeNull();
            traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            traktUserWatchingItem.Type.Should().BeNull();
            traktUserWatchingItem.Movie.Should().BeNull();
            traktUserWatchingItem.Show.Should().BeNull();
            traktUserWatchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_9);

            traktUserWatchingItem.Should().NotBeNull();
            traktUserWatchingItem.StartedAt.Should().BeNull();
            traktUserWatchingItem.ExpiresAt.Should().BeNull();
            traktUserWatchingItem.Action.Should().BeNull();
            traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
            traktUserWatchingItem.Movie.Should().BeNull();
            traktUserWatchingItem.Show.Should().BeNull();
            traktUserWatchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_10);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_4);

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

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_5);

            traktUserWatchingItem.Should().NotBeNull();
            traktUserWatchingItem.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            traktUserWatchingItem.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            traktUserWatchingItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            traktUserWatchingItem.Type.Should().Be(TraktSyncType.Movie);
            traktUserWatchingItem.Movie.Should().BeNull();
            traktUserWatchingItem.Show.Should().BeNull();
            traktUserWatchingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserWatchingItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new UserWatchingItemObjectJsonReader();

            var traktUserWatchingItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_6);

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
