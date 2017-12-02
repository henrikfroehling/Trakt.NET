namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories.Reader
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncMoviesLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncMoviesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncMoviesLastActivities> CreateObjectReader() => new SyncMoviesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncMoviesLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncMoviesLastActivities)} is not supported.");
        }
    }
}
