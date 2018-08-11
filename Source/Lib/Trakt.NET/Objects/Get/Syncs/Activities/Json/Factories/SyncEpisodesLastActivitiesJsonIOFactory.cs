namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncEpisodesLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncEpisodesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncEpisodesLastActivities> CreateObjectReader() => new SyncEpisodesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncEpisodesLastActivities> CreateArrayReader() => new SyncEpisodesLastActivitiesArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncEpisodesLastActivities> CreateObjectWriter() => new SyncEpisodesLastActivitiesObjectJsonWriter();
    }
}
