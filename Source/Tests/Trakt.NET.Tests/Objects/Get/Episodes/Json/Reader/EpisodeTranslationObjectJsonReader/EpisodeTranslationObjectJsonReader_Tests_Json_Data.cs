namespace TraktNet.Tests.Objects.Get.Episodes.Json.Reader
{
    public partial class EpisodeTranslationObjectJsonReader_Tests
    {
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
