namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class LanguageObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktLanguage.Should().NotBeNull();
                traktLanguage.Name.Should().Be("English");
                traktLanguage.Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktLanguage.Should().NotBeNull();
                traktLanguage.Name.Should().BeNull();
                traktLanguage.Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktLanguage.Should().NotBeNull();
                traktLanguage.Name.Should().Be("English");
                traktLanguage.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktLanguage.Should().NotBeNull();
                traktLanguage.Name.Should().BeNull();
                traktLanguage.Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktLanguage.Should().NotBeNull();
                traktLanguage.Name.Should().Be("English");
                traktLanguage.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktLanguage.Should().NotBeNull();
                traktLanguage.Name.Should().BeNull();
                traktLanguage.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new LanguageObjectJsonReader();
            Func<Task<ITraktLanguage>> traktLanguage = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktLanguage.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new LanguageObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktLanguage traktLanguage = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktLanguage.Should().BeNull();
            }
        }
    }
}
