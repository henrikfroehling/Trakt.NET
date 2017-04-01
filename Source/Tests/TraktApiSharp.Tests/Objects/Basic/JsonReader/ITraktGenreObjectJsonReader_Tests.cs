namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Basic")]
    public class ITraktGenreObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktGenreObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktGenreObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktGenre>));
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(JSON_COMPLETE);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(default(string));
            traktGenre.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(string.Empty);
            traktGenre.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = jsonReader.ReadObject(default(JsonTextReader));
            traktGenre.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = traktJsonReader.ReadObject(jsonReader);
                traktGenre.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""name"": ""Action"",
                ""slug"": ""action""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""name"": ""Action""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""slug"": ""action""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""name"": ""Action"",
                ""sl"": ""action""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""nm"": ""Action"",
                ""slug"": ""action""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""nm"": ""Action"",
                ""sl"": ""action""
              }";
    }
}
