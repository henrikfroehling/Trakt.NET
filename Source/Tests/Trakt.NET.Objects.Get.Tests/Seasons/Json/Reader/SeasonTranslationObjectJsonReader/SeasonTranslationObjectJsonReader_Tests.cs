namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().BeNull();
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().BeNull();
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().BeNull();
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().BeNull();
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().BeNull();
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().BeNull();
            traktSeasonTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().Be("Sesong 1");
            traktSeasonTranslation.Overview.Should().Be("Sesong 1 av Game of Thrones hadde premiere 17 Mai, 2011.");
            traktSeasonTranslation.LanguageCode.Should().Be("no");
            traktSeasonTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSeasonTranslation.Should().NotBeNull();
            traktSeasonTranslation.Title.Should().BeNull();
            traktSeasonTranslation.Overview.Should().BeNull();
            traktSeasonTranslation.LanguageCode.Should().BeNull();
            traktSeasonTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();
            Func<Task<ITraktSeasonTranslation>> traktSeasonTranslation = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSeasonTranslation.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SeasonTranslationObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var traktSeasonTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSeasonTranslation.Should().BeNull();
        }
    }
}
