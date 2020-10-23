namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncShowsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncShowsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncShowsLastActivities> CreateObjectReader() => new SyncShowsLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncShowsLastActivities> CreateObjectWriter() => new SyncShowsLastActivitiesObjectJsonWriter();
    }
}
