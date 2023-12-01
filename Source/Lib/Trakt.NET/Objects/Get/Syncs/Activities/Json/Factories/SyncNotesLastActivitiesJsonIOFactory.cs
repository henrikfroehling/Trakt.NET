namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncNotesLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncNotesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncNotesLastActivities> CreateObjectReader() => new SyncNotesLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncNotesLastActivities> CreateObjectWriter() => new SyncNotesLastActivitiesObjectJsonWriter();
    }
}
