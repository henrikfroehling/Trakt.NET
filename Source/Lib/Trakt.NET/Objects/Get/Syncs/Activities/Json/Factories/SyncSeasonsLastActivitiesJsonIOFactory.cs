namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncSeasonsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncSeasonsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectReader() => new SyncSeasonsLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncSeasonsLastActivities> CreateObjectWriter() => new SyncSeasonsLastActivitiesObjectJsonWriter();
    }
}
