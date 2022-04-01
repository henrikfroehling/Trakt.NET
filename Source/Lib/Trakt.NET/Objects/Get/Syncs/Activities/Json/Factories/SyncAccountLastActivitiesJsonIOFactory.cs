namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncAccountLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncAccountLastActivities>
    {
        public IObjectJsonReader<ITraktSyncAccountLastActivities> CreateObjectReader() => new SyncAccountLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncAccountLastActivities> CreateObjectWriter() => new SyncAccountLastActivitiesObjectJsonWriter();
    }
}
