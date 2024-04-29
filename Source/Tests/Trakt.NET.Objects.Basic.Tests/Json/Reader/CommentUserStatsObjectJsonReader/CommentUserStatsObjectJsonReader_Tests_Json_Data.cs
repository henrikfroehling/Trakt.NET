namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CommentUserStatsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rating"": 8,
                ""play_count"": 1,
                ""completed_count"": 1
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""play_count"": 1,
                ""completed_count"": 1
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rating"": 8,
                ""completed_count"": 1
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rating"": 8,
                ""play_count"": 1
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""rt"": 8,
                ""play_count"": 1,
                ""completed_count"": 1
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rating"": 8,
                ""pc"": 1,
                ""completed_count"": 1
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rating"": 8,
                ""play_count"": 1,
                ""cc"": 1
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""rt"": 8,
                ""pc"": 1,
                ""cc"": 1
              }";
    }
}
