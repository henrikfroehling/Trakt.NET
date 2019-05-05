namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SearchResultObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_COMPLETE);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_1);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().BeNull();
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_2);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().BeNull();
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_3);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().BeNull();

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_4);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().BeNull();
            traktSearchResultItem.Movie.Should().BeNull();

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_5);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().BeNull();
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().BeNull();

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_INCOMPLETE_6);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().BeNull();
            traktSearchResultItem.Score.Should().BeNull();
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_1);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().BeNull();
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_2);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().BeNull();
            traktSearchResultItem.Movie.Should().NotBeNull();
            traktSearchResultItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktSearchResultItem.Movie.Year.Should().Be(2015);
            traktSearchResultItem.Movie.Ids.Should().NotBeNull();
            traktSearchResultItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktSearchResultItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktSearchResultItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktSearchResultItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_3);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().Be(TraktSearchResultType.Movie);
            traktSearchResultItem.Score.Should().Be(46.29501f);
            traktSearchResultItem.Movie.Should().BeNull();

            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_SearchResultObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new SearchResultObjectJsonReader();

            var traktSearchResultItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_JSON_NOT_VALID_4);

            traktSearchResultItem.Should().NotBeNull();
            traktSearchResultItem.Type.Should().BeNull();
            traktSearchResultItem.Score.Should().BeNull();
            traktSearchResultItem.Movie.Should().BeNull();
            traktSearchResultItem.Show.Should().BeNull();
            traktSearchResultItem.Episode.Should().BeNull();
            traktSearchResultItem.List.Should().BeNull();
            traktSearchResultItem.Person.Should().BeNull();
        }
    }
}
