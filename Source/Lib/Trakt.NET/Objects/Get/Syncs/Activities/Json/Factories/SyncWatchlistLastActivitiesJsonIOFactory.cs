namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncWatchlistLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistLastActivities>
    {
        public IObjectJsonReader<ITraktSyncWatchlistLastActivities> CreateObjectReader() => new SyncWatchlistLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistLastActivities> CreateObjectWriter() => new SyncWatchlistLastActivitiesObjectJsonWriter();
    }
}
