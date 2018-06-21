namespace TraktNet.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_COMPLETE);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            traktUserHiddenItem.Movie.Should().NotBeNull();
            traktUserHiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktUserHiddenItem.Movie.Year.Should().Be(2015);
            traktUserHiddenItem.Movie.Ids.Should().NotBeNull();
            traktUserHiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktUserHiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktUserHiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktUserHiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_1);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            traktUserHiddenItem.Movie.Should().NotBeNull();
            traktUserHiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktUserHiddenItem.Movie.Year.Should().Be(2015);
            traktUserHiddenItem.Movie.Ids.Should().NotBeNull();
            traktUserHiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktUserHiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktUserHiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktUserHiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_2);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Movie.Should().NotBeNull();
            traktUserHiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktUserHiddenItem.Movie.Year.Should().Be(2015);
            traktUserHiddenItem.Movie.Ids.Should().NotBeNull();
            traktUserHiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktUserHiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktUserHiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktUserHiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_3);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_4);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_5);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_6);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Movie.Should().NotBeNull();
            traktUserHiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktUserHiddenItem.Movie.Year.Should().Be(2015);
            traktUserHiddenItem.Movie.Ids.Should().NotBeNull();
            traktUserHiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktUserHiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktUserHiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktUserHiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_1);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            traktUserHiddenItem.Movie.Should().NotBeNull();
            traktUserHiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktUserHiddenItem.Movie.Year.Should().Be(2015);
            traktUserHiddenItem.Movie.Ids.Should().NotBeNull();
            traktUserHiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktUserHiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktUserHiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktUserHiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_2);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Movie.Should().NotBeNull();
            traktUserHiddenItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktUserHiddenItem.Movie.Year.Should().Be(2015);
            traktUserHiddenItem.Movie.Ids.Should().NotBeNull();
            traktUserHiddenItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktUserHiddenItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktUserHiddenItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktUserHiddenItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_3);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Movie);
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_4);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
        }
    }
}
