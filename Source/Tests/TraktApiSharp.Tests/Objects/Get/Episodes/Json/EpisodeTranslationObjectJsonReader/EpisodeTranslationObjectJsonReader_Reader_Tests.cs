namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
                traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeTranslation.Should().NotBeNull();
                traktEpisodeTranslation.Title.Should().BeNull();
                traktEpisodeTranslation.Overview.Should().BeNull();
                traktEpisodeTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktEpisodeTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new EpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktEpisodeTranslation.Should().BeNull();
            }
        }
    }
}
