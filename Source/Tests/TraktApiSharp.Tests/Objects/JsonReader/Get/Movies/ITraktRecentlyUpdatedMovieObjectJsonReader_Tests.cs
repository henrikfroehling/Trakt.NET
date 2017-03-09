namespace TraktApiSharp.Tests.Objects.JsonReader.Get.Movies
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Get.Movies;
    using Xunit;

    [Category("Objects.JsonReader.Get.Movies")]
    public class ITraktRecentlyUpdatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktRecentlyUpdatedMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktRecentlyUpdatedMovie>));
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(JSON_COMPLETE);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(default(string));
            traktRecentlyUpdatedMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(string.Empty);
            traktRecentlyUpdatedMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
                traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
                traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
                traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
                traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
                traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
                traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
                traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
                traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
                traktRecentlyUpdatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = jsonReader.ReadObject(default(JsonTextReader));
            traktRecentlyUpdatedMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedMovie = traktJsonReader.ReadObject(jsonReader);
                traktRecentlyUpdatedMovie.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                ""updated_at"": ""2016-03-31T01:29:13Z""
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
                ""ua"": ""2016-03-31T01:29:13Z"",
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
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                ""ua"": ""2016-03-31T01:29:13Z"",
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
