namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class LanguageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktLanguages.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktLanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktLanguages.ToArray();

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
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktLanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktLanguages.ToArray();

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
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktLanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktLanguages.ToArray();

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
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktLanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktLanguages.ToArray();

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
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktLanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktLanguages.ToArray();

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
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktLanguages.Should().NotBeNull();
            ITraktLanguage[] languages = traktLanguages.ToArray();

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
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            Func<Task<IList<ITraktLanguage>>> traktLanguages = () => jsonReader.ReadArrayAsync(default(string));
            await traktLanguages.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            IList<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(string.Empty);
            traktLanguages.Should().BeNull();
        }
    }
}
