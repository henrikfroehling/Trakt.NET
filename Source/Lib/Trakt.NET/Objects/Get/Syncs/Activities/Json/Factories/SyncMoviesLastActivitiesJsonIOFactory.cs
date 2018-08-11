namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncMoviesLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncMoviesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncMoviesLastActivities> CreateObjectReader() => new SyncMoviesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncMoviesLastActivities> CreateArrayReader() => new SyncMoviesLastActivitiesArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncMoviesLastActivities> CreateObjectWriter() => new SyncMoviesLastActivitiesObjectJsonWriter();
    }
}
