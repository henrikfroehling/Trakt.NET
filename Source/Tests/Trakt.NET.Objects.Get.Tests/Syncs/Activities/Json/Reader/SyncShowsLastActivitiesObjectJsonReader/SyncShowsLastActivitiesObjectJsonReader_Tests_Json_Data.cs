namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncShowsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""rated"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden"": ""2022-12-20T19:34:50.000Z""
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""rated"": ""2022-06-25T23:46:52.000Z"",
                ""watchlisted"": ""2023-06-22T16:39:23.000Z"",
                ""favorited"": ""2021-06-28T00:13:46.000Z"",
                ""recommendations"": ""2021-06-28T00:13:46.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""hidden"": ""2022-12-20T19:34:50.000Z""
              }";
    }
}
