namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    public partial class EpisodeTranslationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""ov"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""la"": ""en"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Winter Is Coming"",
                ""overview"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""language"": ""en"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""ti"": ""Winter Is Coming"",
                ""ov"": ""Jon Arryn, the Hand of the King, is dead..."",
                ""la"": ""en"",
                ""co"": ""us""
              }";
    }
}
