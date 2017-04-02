namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public class ITraktEpisodeTranslationObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeTranslationObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeTranslationObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeTranslation>));
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().Be("en");
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().Be("Winter Is Coming");
            traktEpisodeTranslation.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktEpisodeTranslation.Should().NotBeNull();
            traktEpisodeTranslation.Title.Should().BeNull();
            traktEpisodeTranslation.Overview.Should().BeNull();
            traktEpisodeTranslation.LanguageCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(default(string));
            traktEpisodeTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(string.Empty);
            traktEpisodeTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

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
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            var traktEpisodeTranslation = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktEpisodeTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeTranslationObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktEpisodeTranslation.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""language"": ""en""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Winter Is Coming""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""ov"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""la"": ""en""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""ti"": ""Winter Is Coming"",
                ""ov"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                ""la"": ""en""
              }";
    }
}
