namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncMoviesLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncMoviesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncMoviesLastActivities> CreateObjectReader() => new TraktSyncMoviesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncMoviesLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncMoviesLastActivities)} is not supported.");
        }
    }
}
