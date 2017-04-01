namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public class ITraktPersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktPersonIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktPersonIds>));
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_COMPLETE);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_INCOMPLETE_10);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(default(string));
            traktPersonIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(string.Empty);
            traktPersonIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(297737);
                traktPersonIds.Slug.Should().Be("bryan-cranston");
                traktPersonIds.Imdb.Should().Be("nm0186505");
                traktPersonIds.Tmdb.Should().Be(17419U);
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);

                traktPersonIds.Should().NotBeNull();
                traktPersonIds.Trakt.Should().Be(0);
                traktPersonIds.Slug.Should().BeNull();
                traktPersonIds.Imdb.Should().BeNull();
                traktPersonIds.Tmdb.Should().BeNull();
                traktPersonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktPersonIdsObjectJsonReader();

            var traktPersonIds = jsonReader.ReadObject(default(JsonTextReader));
            traktPersonIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktPersonIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktPersonIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPersonIds = traktJsonReader.ReadObject(jsonReader);
                traktPersonIds.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 297737,
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""trakt"": 297737
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""slug"": ""bryan-cranston""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""imdb"": ""nm0186505""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""tmdb"": 17419
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 297737,
                ""sl"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""im"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tm"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvr"": 1797
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""tr"": 297737,
                ""sl"": ""bryan-cranston"",
                ""im"": ""nm0186505"",
                ""tm"": 17419,
                ""tvr"": 1797
              }";
    }
}
