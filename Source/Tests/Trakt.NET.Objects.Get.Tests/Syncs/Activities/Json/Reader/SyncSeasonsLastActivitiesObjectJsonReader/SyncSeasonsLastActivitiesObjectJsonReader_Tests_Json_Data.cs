namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncSeasonsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""rated"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""hidden_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                ""hidden"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""rated"": ""2022-06-25T23:46:39.000Z"",
                ""watchlisted"": ""2022-10-06T17:42:50.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z"",
                ""hidden"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
