namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Reader
{
    public partial class ListItemsReorderPostResponseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ]
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""skipped_ids"": [
                  2
                ]
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""updated"": 6
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""upd"": 6,
                ""skipped_ids"": [
                  2
                ]
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""updated"": 6,
                ""skip"": [
                  2
                ]
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""upd"": 6,
                ""skip"": [
                  2
                ]
              }";
    }
}
