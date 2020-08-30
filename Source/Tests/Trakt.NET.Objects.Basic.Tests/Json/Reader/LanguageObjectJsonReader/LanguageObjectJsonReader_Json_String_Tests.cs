namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class LanguageObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().Be("English");
            traktLanguage.Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().BeNull();
            traktLanguage.Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().Be("English");
            traktLanguage.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().BeNull();
            traktLanguage.Code.Should().Be("en");
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().Be("English");
            traktLanguage.Code.Should().BeNull();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktLanguage.Should().NotBeNull();
            traktLanguage.Name.Should().BeNull();
            traktLanguage.Code.Should().BeNull();
        }

        [Fact]
        public void Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new LanguageObjectJsonReader();
            Func<Task<ITraktLanguage>> traktLanguage = () => jsonReader.ReadObjectAsync(default(string));
            traktLanguage.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new LanguageObjectJsonReader();
            ITraktLanguage traktLanguage = await jsonReader.ReadObjectAsync(string.Empty);
            traktLanguage.Should().BeNull();
        }   
    }
}
