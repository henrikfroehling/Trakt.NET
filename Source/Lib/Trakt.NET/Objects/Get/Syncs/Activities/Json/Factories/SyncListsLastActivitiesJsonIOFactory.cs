namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncListsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncListsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncListsLastActivities> CreateObjectReader() => new SyncListsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncListsLastActivities> CreateArrayReader() => new SyncListsLastActivitiesArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncListsLastActivities> CreateObjectWriter() => new SyncListsLastActivitiesObjectJsonWriter();
    }
}
