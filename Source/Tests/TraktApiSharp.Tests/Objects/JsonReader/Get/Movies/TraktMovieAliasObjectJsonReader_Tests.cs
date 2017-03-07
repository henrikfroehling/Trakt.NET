namespace TraktApiSharp.Tests.Objects.JsonReader.Get.Movies
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Get.Movies;
    using Xunit;

    [Category("Objects.JsonReader.Get.Movies")]
    public class TraktMovieAliasObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMovieAliasObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktMovieAlias>));
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(JSON_COMPLETE);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().Be("us");
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMovieAlias.Should().NotBeNull();
            traktMovieAlias.Title.Should().BeNull();
            traktMovieAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(default(string));
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(string.Empty);
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktMovieAliasObjectJsonReader();

            var traktMovieAlias = jsonReader.ReadObject(default(JsonTextReader));
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = traktJsonReader.ReadObject(jsonReader);
                traktMovieAlias.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""co"": ""us""
              }";
    }
}
