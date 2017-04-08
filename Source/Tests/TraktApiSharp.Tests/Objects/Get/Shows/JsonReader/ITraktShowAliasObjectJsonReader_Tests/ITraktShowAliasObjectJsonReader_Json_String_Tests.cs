namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ITraktShowAliasObjectJsonReader_Tests
    {
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
    }
}
