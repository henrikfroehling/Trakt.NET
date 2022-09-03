namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    public partial class ListLikeObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                ""user"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""liked_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""user"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""user"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                ""usr"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""usr"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";
    }
}
