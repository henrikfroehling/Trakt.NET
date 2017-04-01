namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Seasons")]
    public class ITraktSeasonIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktSeasonIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSeasonIds>));
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_COMPLETE);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().Be(36939U);
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(61430);
            traktSeasonIds.Tvdb.Should().Be(279121U);
            traktSeasonIds.Tmdb.Should().Be(60523U);
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktSeasonIds.Should().NotBeNull();
            traktSeasonIds.Trakt.Should().Be(0);
            traktSeasonIds.Tvdb.Should().BeNull();
            traktSeasonIds.Tmdb.Should().BeNull();
            traktSeasonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(default(string));
            traktSeasonIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(string.Empty);
            traktSeasonIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktSeasonIdsObjectJsonReader();

            var traktSeasonIds = jsonReader.ReadObject(default(JsonTextReader));
            traktSeasonIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktSeasonIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonIds = traktJsonReader.ReadObject(jsonReader);
                traktSeasonIds.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 61430,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 61430
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""tvdb"": 279121
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""tmdb"": 60523
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 61430,
                ""tv"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tm"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvr"": 36939
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""tr"": 61430,
                ""tv"": 279121,
                ""tm"": 60523,
                ""tvr"": 36939
              }";
    }
}
