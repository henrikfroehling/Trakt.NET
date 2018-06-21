namespace TraktNet.Tests.Objects.Get.Syncs.Activities.Json.Reader
{
    public partial class SyncListsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z"",
                ""updated_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""updated_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z"",
                ""updated_at"": ""2014-11-19T22:02:41.308Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""updated_at"": ""2014-11-19T22:02:41.308Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""liked"": ""2014-11-20T06:51:30.305Z"",
                ""updated_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z"",
                ""updated"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""liked_at"": ""2014-11-20T06:51:30.305Z"",
                ""updated_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""liked"": ""2014-11-20T06:51:30.305Z"",
                ""updated"": ""2014-11-19T22:02:41.308Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z""
              }";
    }
}
