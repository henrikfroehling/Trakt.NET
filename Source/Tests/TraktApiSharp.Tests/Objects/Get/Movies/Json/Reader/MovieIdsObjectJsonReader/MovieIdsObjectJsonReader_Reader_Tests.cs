namespace TraktApiSharp.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMovieIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMovieIds.Should().BeNull();
            }
        }
    }
}
