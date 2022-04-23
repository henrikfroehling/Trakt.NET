namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncWatchlistLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""updated"": ""2014-09-01T09:10:11.000Z""
              }";
    }
}
