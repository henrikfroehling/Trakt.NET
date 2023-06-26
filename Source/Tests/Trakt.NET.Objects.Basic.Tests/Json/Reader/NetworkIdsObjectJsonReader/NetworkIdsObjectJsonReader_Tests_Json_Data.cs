namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class NetworkIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 16,
                ""tmdb"": 2
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""tmdb"": 2
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 16
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 16,
                ""tmdb"": 2
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 16,
                ""tm"": 2
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""tr"": 16,
                ""tm"": 2
              }";
    }
}
