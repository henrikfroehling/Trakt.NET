namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class LanguageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);
                traktLanguages.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();
            Func<Task<IEnumerable<ITraktLanguage>>> traktLanguages = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktLanguages.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_LanguageArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktLanguage>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktLanguage> traktLanguages = await jsonReader.ReadArrayAsync(stream);
                traktLanguages.Should().BeNull();
            }
        }
    }
}
