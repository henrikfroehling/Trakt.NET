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
    public class ITraktTrendingMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktTrendingMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktTrendingMovie>));
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(JSON_COMPLETE);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().Be(35);
            traktTrendingMovie.Movie.Should().NotBeNull();
            traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktTrendingMovie.Movie.Year.Should().Be(2015);
            traktTrendingMovie.Movie.Ids.Should().NotBeNull();
            traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().Be(35);
            traktTrendingMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().BeNull();
            traktTrendingMovie.Movie.Should().NotBeNull();
            traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktTrendingMovie.Movie.Year.Should().Be(2015);
            traktTrendingMovie.Movie.Ids.Should().NotBeNull();
            traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().BeNull();
            traktTrendingMovie.Movie.Should().NotBeNull();
            traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktTrendingMovie.Movie.Year.Should().Be(2015);
            traktTrendingMovie.Movie.Ids.Should().NotBeNull();
            traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().Be(35);
            traktTrendingMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktTrendingMovie.Should().NotBeNull();
            traktTrendingMovie.Watchers.Should().BeNull();
            traktTrendingMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(default(string));
            traktTrendingMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(string.Empty);
            traktTrendingMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().NotBeNull();
                traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktTrendingMovie.Movie.Year.Should().Be(2015);
                traktTrendingMovie.Movie.Ids.Should().NotBeNull();
                traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().NotBeNull();
                traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktTrendingMovie.Movie.Year.Should().Be(2015);
                traktTrendingMovie.Movie.Ids.Should().NotBeNull();
                traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().NotBeNull();
                traktTrendingMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktTrendingMovie.Movie.Year.Should().Be(2015);
                traktTrendingMovie.Movie.Ids.Should().NotBeNull();
                traktTrendingMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktTrendingMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktTrendingMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktTrendingMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().Be(35);
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);

                traktTrendingMovie.Should().NotBeNull();
                traktTrendingMovie.Watchers.Should().BeNull();
                traktTrendingMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktTrendingMovieObjectJsonReader();

            var traktTrendingMovie = jsonReader.ReadObject(default(JsonTextReader));
            traktTrendingMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktTrendingMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktTrendingMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingMovie = traktJsonReader.ReadObject(jsonReader);
                traktTrendingMovie.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""watchers"": 35,
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
                ""watchers"": 35
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
                ""wa"": 35,
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
                ""watchers"": 35,
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
                ""wa"": 35,
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
