namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""watched"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
                ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
                ""watched"": ""2023-06-11T20:00:28.000Z"",
                ""collected"": ""2015-02-18T12:54:39.000Z"",
                ""rated"": ""2016-11-07T03:11:00.000Z"",
                ""watchlisted"": ""2023-06-04T13:48:29.000Z"",
                ""favorited"": ""2021-04-07T22:07:11.000Z"",
                ""recommendations"": ""2021-04-07T22:07:11.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""paused"": ""2015-02-18T12:54:39.000Z"",
                ""hidden"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
