namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktEpisodeTranslations.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().BeNull();
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().BeNull();
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().BeNull();
            translations[0].LanguageCode.Should().BeNull();

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().BeNull();
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().BeNull();

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().BeNull();
            translations[2].Overview.Should().BeNull();
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().BeNull();
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().BeNull();
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().Be("Translation Language 3");
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().Be("Translation 1");
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().Be("Translation Overview 2");
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);
            traktEpisodeTranslations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var translations = traktEpisodeTranslations.ToArray();

            translations[0].Title.Should().BeNull();
            translations[0].Overview.Should().Be("Translation Overview 1");
            translations[0].LanguageCode.Should().Be("Translation Language 1");

            translations[1].Title.Should().Be("Translation 2");
            translations[1].Overview.Should().BeNull();
            translations[1].LanguageCode.Should().Be("Translation Language 2");

            translations[2].Title.Should().Be("Translation 3");
            translations[2].Overview.Should().Be("Translation Overview 3");
            translations[2].LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(default(string));
            traktEpisodeTranslations.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new EpisodeTranslationArrayJsonReader();

            var traktEpisodeTranslations = await jsonReader.ReadArrayAsync(string.Empty);
            traktEpisodeTranslations.Should().BeNull();
        }
    }
}
