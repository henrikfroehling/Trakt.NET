namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ITraktShowAliasObjectJsonReader_Tests
    {
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
            var traktJsonReader = new ITraktShowAliasObjectJsonReader();

            var traktShowAlias = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
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
    }
}
