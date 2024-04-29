namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncCollaborationsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncCollaborationsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncCollaborationsLastActivities> CreateObjectReader() => new SyncCollaborationsLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollaborationsLastActivities> CreateObjectWriter() => new SyncCollaborationsLastActivitiesObjectJsonWriter();
    }
}
