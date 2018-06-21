namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;
    using System;

    internal class SyncMoviesLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncMoviesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncMoviesLastActivities> CreateObjectReader() => new SyncMoviesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncMoviesLastActivities> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncMoviesLastActivities)} is not supported.");

        public IObjectJsonWriter<ITraktSyncMoviesLastActivities> CreateObjectWriter() => new SyncMoviesLastActivitiesObjectJsonWriter();
    }
}
