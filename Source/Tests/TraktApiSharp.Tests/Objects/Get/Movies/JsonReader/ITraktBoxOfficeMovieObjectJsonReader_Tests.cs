namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Movies")]
    public class ITraktBoxOfficeMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktBoxOfficeMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktBoxOfficeMovie>));
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(JSON_COMPLETE);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().Be(166007347);
            traktBoxOfficeMovie.Movie.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
            traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().Be(166007347);
            traktBoxOfficeMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().BeNull();
            traktBoxOfficeMovie.Movie.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
            traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().BeNull();
            traktBoxOfficeMovie.Movie.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
            traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().Be(166007347);
            traktBoxOfficeMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().BeNull();
            traktBoxOfficeMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(default(string));
            traktBoxOfficeMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(string.Empty);
            traktBoxOfficeMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);

                traktBoxOfficeMovie.Should().NotBeNull();
                traktBoxOfficeMovie.Revenue.Should().Be(166007347);
                traktBoxOfficeMovie.Movie.Should().NotBeNull();
                traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
                traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
                traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);

                traktBoxOfficeMovie.Should().NotBeNull();
                traktBoxOfficeMovie.Revenue.Should().Be(166007347);
                traktBoxOfficeMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);

                traktBoxOfficeMovie.Should().NotBeNull();
                traktBoxOfficeMovie.Revenue.Should().BeNull();
                traktBoxOfficeMovie.Movie.Should().NotBeNull();
                traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
                traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
                traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);

                traktBoxOfficeMovie.Should().NotBeNull();
                traktBoxOfficeMovie.Revenue.Should().BeNull();
                traktBoxOfficeMovie.Movie.Should().NotBeNull();
                traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
                traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
                traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);

                traktBoxOfficeMovie.Should().NotBeNull();
                traktBoxOfficeMovie.Revenue.Should().Be(166007347);
                traktBoxOfficeMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);

                traktBoxOfficeMovie.Should().NotBeNull();
                traktBoxOfficeMovie.Revenue.Should().BeNull();
                traktBoxOfficeMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = jsonReader.ReadObject(default(JsonTextReader));
            traktBoxOfficeMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktBoxOfficeMovie = traktJsonReader.ReadObject(jsonReader);
                traktBoxOfficeMovie.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""revenue"": 166007347,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""revenue"": 166007347
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""rev"": 166007347,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""revenue"": 166007347,
                ""mo"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rev"": 166007347,
                ""mo"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";
    }
}
