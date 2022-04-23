namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncAccountLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""settings_at"": ""2014-09-01T09:10:11.000Z"",
                ""followed_at"": ""2014-09-01T09:10:11.000Z"",
                ""following_at"": ""2014-09-01T09:10:11.000Z"",
                ""pending_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""settings"": ""2014-09-01T09:10:11.000Z"",
                ""followed"": ""2014-09-01T09:10:11.000Z"",
                ""following"": ""2014-09-01T09:10:11.000Z"",
                ""pending"": ""2014-09-01T09:10:11.000Z""
              }";
    }
}
