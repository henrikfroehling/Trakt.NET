namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;

    internal class SyncFavoritesLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncFavoritesLastActivities> CreateObjectReader() => new SyncFavoritesLastActivitiesObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesLastActivities> CreateObjectWriter() => new SyncFavoritesLastActivitiesObjectJsonWriter();
    }
}
