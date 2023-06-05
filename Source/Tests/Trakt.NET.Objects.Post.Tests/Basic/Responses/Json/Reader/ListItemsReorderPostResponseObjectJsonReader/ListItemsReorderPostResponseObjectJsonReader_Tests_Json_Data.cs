namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Reader
{
    public partial class ListItemsReorderPostResponseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ],
                ""list"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""skipped_ids"": [
                  2
                ],
                ""list"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""updated"": 6,
                ""list"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ]
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""upd"": 6,
                ""skipped_ids"": [
                  2
                ],
                ""list"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""updated"": 6,
                ""skipped"": [
                  2
                ],
                ""list"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ],
                ""l"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""upd"": 6,
                ""skipped"": [
                  2
                ],
                ""l"": {
                  ""updated_at"": ""2022-04-27T21:40:41.000Z"",
                  ""item_count"": 5
                }
              }";
    }
}
