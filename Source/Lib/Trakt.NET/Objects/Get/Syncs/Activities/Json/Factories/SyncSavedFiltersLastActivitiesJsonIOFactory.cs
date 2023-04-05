namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncSavedFiltersLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncSavedFiltersLastActivities>
    {
        public IObjectJsonReader<ITraktSyncSavedFiltersLastActivities> CreateObjectReader() => new SyncSavedFiltersLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncSavedFiltersLastActivities> CreateObjectWriter() => new SyncSavedFiltersLastActivitiesObjectJsonWriter();
    }
}
