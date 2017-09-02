namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncLastActivities>
    {
        public IObjectJsonReader<ITraktSyncLastActivities> CreateObjectReader() => new TraktSyncLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncLastActivities)} is not supported.");
        }
    }
}
