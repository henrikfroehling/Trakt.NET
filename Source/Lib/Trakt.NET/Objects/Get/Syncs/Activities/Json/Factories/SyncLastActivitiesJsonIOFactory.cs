namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncLastActivities>
    {
        public IObjectJsonReader<ITraktSyncLastActivities> CreateObjectReader() => new SyncLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncLastActivities> CreateObjectWriter() => new SyncLastActivitiesObjectJsonWriter();
    }
}
