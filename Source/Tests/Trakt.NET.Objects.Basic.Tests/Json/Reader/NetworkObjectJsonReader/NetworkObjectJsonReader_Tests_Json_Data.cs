namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class NetworkObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""ABC"",
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""ABC"",
                ""ids"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""name"": ""ABC"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""na"": ""ABC"",
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""ABC"",
                ""co"": ""us"",
                ""ids"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""name"": ""ABC"",
                ""country"": ""us"",
                ""id"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""na"": ""ABC"",
                ""co"": ""us"",
                ""id"": {
                  ""trakt"": 16,
                  ""tmdb"": 2
                }
              }";
    }
}
