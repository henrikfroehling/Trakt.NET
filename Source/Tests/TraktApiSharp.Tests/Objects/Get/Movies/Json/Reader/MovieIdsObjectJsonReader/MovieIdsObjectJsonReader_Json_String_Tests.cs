namespace TraktNet.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(default(string));
            traktMovieIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktMovieIds.Should().BeNull();
        }
    }
}
