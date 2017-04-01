namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Episodes")]
    public class ITraktEpisodeIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktEpisodeIds>));
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_COMPLETE);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_INCOMPLETE_10);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(default(string));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(string.Empty);
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeIdsObjectJsonReader();

            var traktEpisodeIds = jsonReader.ReadObject(default(JsonTextReader));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = traktJsonReader.ReadObject(jsonReader);
                traktEpisodeIds.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 73640,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""trakt"": 73640
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""tvdb"": 3254641
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""imdb"": ""tt1480055""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""tmdb"": 63056
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 73640,
                ""tv"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""im"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tm"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvr"": 1065008299
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""tr"": 73640,
                ""tv"": 3254641,
                ""im"": ""tt1480055"",
                ""tm"": 63056,
                ""tvr"": 1065008299
              }";
    }
}
