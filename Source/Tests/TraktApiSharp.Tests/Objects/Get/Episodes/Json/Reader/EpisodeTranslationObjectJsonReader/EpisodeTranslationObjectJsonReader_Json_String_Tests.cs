namespace TraktNet.Tests.Objects.Get.Episodes.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(default(string));
            traktEpisodeTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(string.Empty);
            traktEpisodeTranslation.Should().BeNull();
        }
    }
}
