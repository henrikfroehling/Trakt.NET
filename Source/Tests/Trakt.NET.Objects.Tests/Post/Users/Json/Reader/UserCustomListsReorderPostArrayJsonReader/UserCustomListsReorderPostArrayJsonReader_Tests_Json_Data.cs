namespace TraktNet.Objects.Tests.Post.Users.Json.Reader
{
    public partial class UserCustomListsReorderPostArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""rank"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                },
                {
                  ""rank"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""rank"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                },
                {
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                },
                {
                  ""rank"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""rank"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                },
                {
                  ""ra"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""ra"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                },
                {
                  ""rank"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""ra"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                },
                {
                  ""ra"": [
                    823,
                    224,
                    88768,
                    356456,
                    245,
                    2,
                    890
                  ]
                }
              ]";
    }
}
