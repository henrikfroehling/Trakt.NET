namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncCommentsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncCommentsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncCommentsLastActivities> CreateObjectReader() => new SyncCommentsLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCommentsLastActivities> CreateObjectWriter() => new SyncCommentsLastActivitiesObjectJsonWriter();
    }
}
