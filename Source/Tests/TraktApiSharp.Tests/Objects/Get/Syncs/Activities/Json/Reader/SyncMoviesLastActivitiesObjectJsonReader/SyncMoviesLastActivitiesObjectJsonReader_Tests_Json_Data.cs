namespace TraktNet.Tests.Objects.Get.Syncs.Activities.Json.Reader
{
    public partial class SyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""collected_at"": ""2014-11-19T22:02:41.308Z""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.310Z""
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z""
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""commented_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""paused_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""watched"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""watched"": ""2014-11-20T06:51:30.305Z"",
                ""collected"": ""2014-11-19T22:02:41.308Z"",
                ""rated"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted"": ""2014-11-20T06:51:30.321Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z"",
                ""paused"": ""2014-11-20T06:51:30.250Z"",
                ""hidden"": ""2014-11-20T06:51:30.250Z""
              }";
    }
}
