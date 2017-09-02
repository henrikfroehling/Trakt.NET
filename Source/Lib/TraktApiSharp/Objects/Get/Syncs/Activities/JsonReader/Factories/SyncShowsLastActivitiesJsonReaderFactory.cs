namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncShowsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncShowsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncShowsLastActivities> CreateObjectReader() => new TraktSyncShowsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncShowsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncShowsLastActivities)} is not supported.");
        }
    }
}
