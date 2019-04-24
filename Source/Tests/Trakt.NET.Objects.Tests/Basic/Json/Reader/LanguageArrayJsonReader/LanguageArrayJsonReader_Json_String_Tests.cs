namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class LanguageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktlanguages.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktlanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktlanguages.ToArray();

            languages[0].Should().NotBeNull();
            languages[0].Name.Should().Be("English");
            languages[0].Code.Should().Be("en");

            languages[1].Should().NotBeNull();
            languages[1].Name.Should().Be("English");
            languages[1].Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktlanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktlanguages.ToArray();

            languages[0].Should().NotBeNull();
            languages[0].Name.Should().Be("English");
            languages[0].Code.Should().Be("en");

            languages[1].Should().NotBeNull();
            languages[1].Name.Should().BeNull();
            languages[1].Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktlanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktlanguages.ToArray();

            languages[0].Should().NotBeNull();
            languages[0].Name.Should().BeNull();
            languages[0].Code.Should().Be("en");

            languages[1].Should().NotBeNull();
            languages[1].Name.Should().Be("English");
            languages[1].Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktlanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktlanguages.ToArray();

            languages[0].Should().NotBeNull();
            languages[0].Name.Should().Be("English");
            languages[0].Code.Should().Be("en");

            languages[1].Should().NotBeNull();
            languages[1].Name.Should().BeNull();
            languages[1].Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktlanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktlanguages.ToArray();

            languages[0].Should().NotBeNull();
            languages[0].Name.Should().Be("English");
            languages[0].Code.Should().BeNull();

            languages[1].Should().NotBeNull();
            languages[1].Name.Should().Be("English");
            languages[1].Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktlanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktlanguages.ToArray();

            languages[0].Should().NotBeNull();
            languages[0].Name.Should().BeNull();
            languages[0].Code.Should().Be("en");

            languages[1].Should().NotBeNull();
            languages[1].Name.Should().Be("English");
            languages[1].Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(default(string));
            traktlanguages.Should().BeNull();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new LanguageArrayJsonReader();
            IEnumerable<ITraktLanguage> traktlanguages = await jsonReader.ReadArrayAsync(string.Empty);
            traktlanguages.Should().BeNull();
        }
    }
}
