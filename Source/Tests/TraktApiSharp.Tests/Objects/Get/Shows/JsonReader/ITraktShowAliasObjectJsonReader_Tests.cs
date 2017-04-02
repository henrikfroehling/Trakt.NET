namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public class ITraktShowAliasObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktShowAliasObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktShowAliasObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktShowAlias>));
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowAlias.Should().NotBeNull();
            traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
            traktShowAlias.CountryCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktShowAlias.Should().NotBeNull();
            traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
            traktShowAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktShowAlias.Should().NotBeNull();
            traktShowAlias.Title.Should().BeNull();
            traktShowAlias.CountryCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktShowAlias.Should().NotBeNull();
            traktShowAlias.Title.Should().BeNull();
            traktShowAlias.CountryCode.Should().Be("de");
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktShowAlias.Should().NotBeNull();
            traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
            traktShowAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktShowAlias.Should().NotBeNull();
            traktShowAlias.Title.Should().BeNull();
            traktShowAlias.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(default(string));
            traktShowAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(string.Empty);
            traktShowAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
                traktShowAlias.CountryCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
                traktShowAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().BeNull();
                traktShowAlias.CountryCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().BeNull();
                traktShowAlias.CountryCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
                traktShowAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().BeNull();
                traktShowAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktShowAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowAliasObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktShowAlias.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""country"": ""de""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""de""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""country"": ""de""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""co"": ""de""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ti"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""co"": ""de""
              }";
    }
}
