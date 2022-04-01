namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncShowsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rated_at"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted_at"": ""2014-11-19T22:02:41.308Z"",
                ""recommendations_at"": ""2014-11-20T06:51:30.325Z"",
                ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                ""hidden_at"": ""2014-11-20T06:51:30.325Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""rated"": ""2014-11-20T06:51:30.305Z"",
                ""watchlisted"": ""2014-11-19T22:02:41.308Z"",
                ""recommendations"": ""2014-11-20T06:51:30.325Z"",
                ""commented"": ""2014-11-20T06:51:30.325Z"",
                ""hidden"": ""2014-11-20T06:51:30.325Z""
              }";
    }
}
