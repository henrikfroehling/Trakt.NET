namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonReader")]
    public partial class ShowTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().BeNull();
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().BeNull();
            traktShowTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().Be("Game of Thrones");
            traktShowTranslation.Overview.Should().Be("Die Handlung ist in einer fiktiven Welt angesiedelt...");
            traktShowTranslation.LanguageCode.Should().Be("de");
            traktShowTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowTranslation.Should().NotBeNull();
            traktShowTranslation.Title.Should().BeNull();
            traktShowTranslation.Overview.Should().BeNull();
            traktShowTranslation.LanguageCode.Should().BeNull();
            traktShowTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();
            Func<Task<ITraktShowTranslation>> traktShowTranslation = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktShowTranslation.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ShowTranslationObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var traktShowTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktShowTranslation.Should().BeNull();
        }
    }
}
