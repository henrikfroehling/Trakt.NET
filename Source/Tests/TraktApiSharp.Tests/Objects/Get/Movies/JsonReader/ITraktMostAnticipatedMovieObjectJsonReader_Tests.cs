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

    [Category("Objects.Get.Movies.JsonReader")]
    public class ITraktMostAnticipatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMostAnticipatedMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMostAnticipatedMovie>));
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(JSON_COMPLETE);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().Be(12805);
            traktMostAnticipatedMovie.Movie.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
            traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().Be(12805);
            traktMostAnticipatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().BeNull();
            traktMostAnticipatedMovie.Movie.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
            traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().BeNull();
            traktMostAnticipatedMovie.Movie.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
            traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
            traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().Be(12805);
            traktMostAnticipatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMostAnticipatedMovie.Should().NotBeNull();
            traktMostAnticipatedMovie.ListCount.Should().BeNull();
            traktMostAnticipatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(default(string));
            traktMostAnticipatedMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(string.Empty);
            traktMostAnticipatedMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
                traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
                traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
                traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = jsonReader.ReadObject(default(JsonTextReader));
            traktMostAnticipatedMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = traktJsonReader.ReadObject(jsonReader);
                traktMostAnticipatedMovie.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""list_count"": 12805,
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
                ""list_count"": 12805
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
                ""lc"": 12805,
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
                ""list_count"": 12805,
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
                ""lc"": 12805,
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
