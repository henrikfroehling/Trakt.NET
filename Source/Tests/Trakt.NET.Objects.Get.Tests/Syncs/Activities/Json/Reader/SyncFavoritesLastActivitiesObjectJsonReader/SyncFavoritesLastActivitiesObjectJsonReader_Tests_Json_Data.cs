namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncFavoritesLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2022-05-14T19:04:12.000Z""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""updated"": ""2022-05-14T19:04:12.000Z""
              }";
    }
}
