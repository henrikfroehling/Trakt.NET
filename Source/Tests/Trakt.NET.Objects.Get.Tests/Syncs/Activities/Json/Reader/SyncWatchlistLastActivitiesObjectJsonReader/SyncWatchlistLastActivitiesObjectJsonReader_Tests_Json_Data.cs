namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncWatchlistLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2023-06-22T16:39:23.000Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""updated"": ""2023-06-22T16:39:23.000Z""
              }";
    }
}
