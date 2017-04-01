namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Movies")]
    public class ITraktMovieIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMovieIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktMovieIds>));
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_COMPLETE);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(94024);
            traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMovieIds.Imdb.Should().Be("tt2488496");
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktMovieIds.Should().NotBeNull();
            traktMovieIds.Trakt.Should().Be(0);
            traktMovieIds.Slug.Should().BeNull();
            traktMovieIds.Imdb.Should().BeNull();
            traktMovieIds.Tmdb.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(default(string));
            traktMovieIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(string.Empty);
            traktMovieIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMovieIdsObjectJsonReader();

            var traktMovieIds = jsonReader.ReadObject(default(JsonTextReader));
            traktMovieIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMovieIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieIds = traktJsonReader.ReadObject(jsonReader);
                traktMovieIds.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 94024,
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""tmdb"": 140607
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 94024
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""slug"": ""star-wars-the-force-awakens-2015""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""imdb"": ""tt2488496""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 94024,
                ""sl"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""im"": ""tt2488496"",
                ""tmdb"": 140607
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 94024,
                ""slug"": ""star-wars-the-force-awakens-2015"",
                ""imdb"": ""tt2488496"",
                ""tm"": 140607
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""tr"": 94024,
                ""sl"": ""star-wars-the-force-awakens-2015"",
                ""im"": ""tt2488496"",
                ""tm"": 140607
              }";
    }
}
