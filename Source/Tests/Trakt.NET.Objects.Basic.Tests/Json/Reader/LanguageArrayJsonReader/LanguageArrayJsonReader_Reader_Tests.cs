namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class LanguageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktLanguages.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktLanguages.Should().NotBeNull();
                ITraktLanguage[] languages = traktLanguages.ToArray();

                languages[0].Should().NotBeNull();
                languages[0].Name.Should().Be("English");
                languages[0].Code.Should().Be("en");

                languages[1].Should().NotBeNull();
                languages[1].Name.Should().Be("English");
                languages[1].Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktLanguages.Should().NotBeNull();
                ITraktLanguage[] languages = traktLanguages.ToArray();

                languages[0].Should().NotBeNull();
                languages[0].Name.Should().Be("English");
                languages[0].Code.Should().Be("en");

                languages[1].Should().NotBeNull();
                languages[1].Name.Should().BeNull();
                languages[1].Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktLanguages.Should().NotBeNull();
                ITraktLanguage[] languages = traktLanguages.ToArray();

                languages[0].Should().NotBeNull();
                languages[0].Name.Should().BeNull();
                languages[0].Code.Should().Be("en");

                languages[1].Should().NotBeNull();
                languages[1].Name.Should().Be("English");
                languages[1].Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktLanguages.Should().NotBeNull();
                ITraktLanguage[] languages = traktLanguages.ToArray();

                languages[0].Should().NotBeNull();
                languages[0].Name.Should().Be("English");
                languages[0].Code.Should().Be("en");

                languages[1].Should().NotBeNull();
                languages[1].Name.Should().BeNull();
                languages[1].Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktLanguages.Should().NotBeNull();
                ITraktLanguage[] languages = traktLanguages.ToArray();

                languages[0].Should().NotBeNull();
                languages[0].Name.Should().Be("English");
                languages[0].Code.Should().BeNull();

                languages[1].Should().NotBeNull();
                languages[1].Name.Should().Be("English");
                languages[1].Code.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktLanguages.Should().NotBeNull();
                ITraktLanguage[] languages = traktLanguages.ToArray();

                languages[0].Should().NotBeNull();
                languages[0].Name.Should().BeNull();
                languages[0].Code.Should().Be("en");

                languages[1].Should().NotBeNull();
                languages[1].Name.Should().Be("English");
                languages[1].Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();
            IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktLanguages.Should().BeNull();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktLanguage> traktLanguages = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktLanguages.Should().BeNull();
            }
        }
    }
}
