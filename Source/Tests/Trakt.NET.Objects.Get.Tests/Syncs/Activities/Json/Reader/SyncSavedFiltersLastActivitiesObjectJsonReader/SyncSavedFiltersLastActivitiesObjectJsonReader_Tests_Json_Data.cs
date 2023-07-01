namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncSavedFiltersLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2015-02-18T12:54:39.000Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""updated"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
