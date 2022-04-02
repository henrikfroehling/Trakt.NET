namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncRecommendationsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsLastActivities> CreateObjectReader() => new SyncRecommendationsLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsLastActivities> CreateObjectWriter() => new SyncRecommendationsLastActivitiesObjectJsonWriter();
    }
}
