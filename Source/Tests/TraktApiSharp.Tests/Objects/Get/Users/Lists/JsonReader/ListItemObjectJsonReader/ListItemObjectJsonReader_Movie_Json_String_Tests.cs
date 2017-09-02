namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_COMPLETE);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_1);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_2);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_3);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_4);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_5);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_6);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_7);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_8);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_1);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_2);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_3);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_4);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_5);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }
    }
}
