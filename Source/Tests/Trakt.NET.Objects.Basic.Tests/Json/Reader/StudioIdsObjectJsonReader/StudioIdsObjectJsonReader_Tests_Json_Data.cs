namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class StudioIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 20,
                ""slug"": ""20th-century-fox"",
                ""tmdb"": 25
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""20th-century-fox"",
                ""tmdb"": 25
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 20,
                ""tmdb"": 25
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 20,
                ""slug"": ""20th-century-fox""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 20,
                ""slug"": ""20th-century-fox"",
                ""tmdb"": 25
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 20,
                ""sl"": ""20th-century-fox"",
                ""tmdb"": 25
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 20,
                ""slug"": ""20th-century-fox"",
                ""tm"": 25
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""tr"": 20,
                ""sl"": ""20th-century-fox"",
                ""tm"": 25
              }";
    }
}
