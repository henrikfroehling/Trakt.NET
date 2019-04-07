namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    public partial class CommentLikeObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""liked_at"": ""2014-10-11T17:00:54.000Z"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""liked_at"": ""2014-10-11T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""la"": ""2014-10-11T17:00:54.000Z"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2014-10-11T17:00:54.000Z"",
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""la"": ""2014-10-11T17:00:54.000Z"",
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";
    }
}
