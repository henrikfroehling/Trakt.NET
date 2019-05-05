namespace TraktNet.Objects.Post.Tests.Users.Responses.Json.Reader
{
    public partial class UserCustomListsReorderPostResponseArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""updated"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                },
                {
                  ""updated"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""updated"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                },
                {
                  ""skipped_ids"": [
                    2
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""skipped_ids"": [
                    2
                  ]
                },
                {
                  ""updated"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""updated"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                },
                {
                  ""upd"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""upd"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                },
                {
                  ""updated"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""upd"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                },
                {
                  ""upd"": 6,
                  ""skipped_ids"": [
                    2
                  ]
                }
              ]";
    }
}
