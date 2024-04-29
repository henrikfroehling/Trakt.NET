namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncListsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                ""updated_at"": ""2022-10-14T21:47:15.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""liked"": ""2022-06-28T21:32:53.000Z"",
                ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                ""updated"": ""2022-10-14T21:47:15.000Z"",
                ""commented_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""liked"": ""2022-06-28T21:32:53.000Z"",
                ""updated"": ""2022-10-14T21:47:15.000Z"",
                ""commented"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
