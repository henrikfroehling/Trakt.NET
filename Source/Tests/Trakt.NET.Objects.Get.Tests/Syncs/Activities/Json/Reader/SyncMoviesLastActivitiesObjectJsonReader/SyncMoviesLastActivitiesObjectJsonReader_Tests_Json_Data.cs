namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                ""recommendations_at"": ""2014-11-20T06:51:30.325Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.250Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""watched"": ""2014-11-20T06:51:30.305Z"",
                ""collected"": ""2014-11-19T22:02:41.308Z"",
                ""rated"": ""2014-11-20T06:51:30.310Z"",
                ""watchlisted"": ""2014-11-20T06:51:30.321Z"",
                ""recommendations"": ""2014-11-20T06:51:30.325Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z"",
                ""paused"": ""2014-11-20T06:51:30.250Z"",
                ""hidden"": ""2014-11-20T06:51:30.250Z""
              }";
    }
}
