namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class StudioObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""20th Century Fox"",
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""20th Century Fox"",
                ""ids"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""name"": ""20th Century Fox"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nm"": ""20th Century Fox"",
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""20th Century Fox"",
                ""co"": ""us"",
                ""ids"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""name"": ""20th Century Fox"",
                ""country"": ""us"",
                ""id"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""nm"": ""20th Century Fox"",
                ""co"": ""us"",
                ""id"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";
    }
}
