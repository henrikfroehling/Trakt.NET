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

    [Category("Objects.Basic.JsonReader")]
    public class ITraktErrorObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktErrorObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktErrorObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktError>));
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(JSON_COMPLETE);

            traktError.Should().NotBeNull();
            traktError.Error.Should().Be("trakt error");
            traktError.Description.Should().Be("trakt error description");
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktError.Should().NotBeNull();
            traktError.Error.Should().Be("trakt error");
            traktError.Description.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktError.Should().NotBeNull();
            traktError.Error.Should().BeNull();
            traktError.Description.Should().Be("trakt error description");
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktError.Should().NotBeNull();
            traktError.Error.Should().Be("trakt error");
            traktError.Description.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktError.Should().NotBeNull();
            traktError.Error.Should().BeNull();
            traktError.Description.Should().Be("trakt error description");
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktError.Should().NotBeNull();
            traktError.Error.Should().BeNull();
            traktError.Description.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(default(string));
            traktError.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(string.Empty);
            traktError.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktErrorObjectJsonReader();

            var traktError = jsonReader.ReadObject(default(JsonTextReader));
            traktError.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktErrorObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktError = traktJsonReader.ReadObject(jsonReader);
                traktError.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""error"": ""trakt error"",
                ""error_description"": ""trakt error description""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""error"": ""trakt error""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""error_description"": ""trakt error description""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""error"": ""trakt error"",
                ""err_description"": ""trakt error description""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""err"": ""trakt error"",
                ""error_description"": ""trakt error description""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""err"": ""trakt error"",
                ""err_description"": ""trakt error description""
              }";
    }
}
