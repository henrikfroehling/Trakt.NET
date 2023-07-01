namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncEpisodesLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""watched"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""watched"": ""2023-06-30T13:38:37.000Z"",
                ""collected"": ""2016-11-09T23:16:22.000Z"",
                ""rated"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted"": ""2015-02-18T12:54:39.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""paused"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
