namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncAccountLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""settings"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending"": ""2015-02-18T12:54:39.000Z"",
                ""requested_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                ""following_at"": ""2015-02-18T12:54:39.000Z"",
                ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                ""requested"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""settings"": ""2023-06-26T18:08:03.000Z"",
                ""followed"": ""2020-12-14T14:12:28.000Z"",
                ""following"": ""2015-02-18T12:54:39.000Z"",
                ""pending"": ""2015-02-18T12:54:39.000Z"",
                ""requested"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
