namespace TraktNet.Tests.Objects.Get.Syncs.Activities.Json.Reader
{
    public partial class SyncSeasonsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""rated"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""rated"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted"": ""2014-11-19T22:02:41.308Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z"",
                ""hidden"": ""2014-11-20T06:51:30.325Z""
              }";
    }
}
