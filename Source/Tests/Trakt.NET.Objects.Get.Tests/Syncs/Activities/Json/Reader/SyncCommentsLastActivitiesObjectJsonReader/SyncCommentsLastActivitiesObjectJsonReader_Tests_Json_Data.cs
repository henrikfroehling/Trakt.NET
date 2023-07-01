namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                ""blocked_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""blocked_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""liked_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""liked"": ""2015-02-18T12:54:39.000Z"",
                ""blocked_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                ""blocked"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""liked"": ""2015-02-18T12:54:39.000Z"",
                ""blocked"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
