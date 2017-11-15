namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncLastActivities>
    {
        public IObjectJsonReader<ITraktSyncLastActivities> CreateObjectReader() => new SyncLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncLastActivities)} is not supported.");
        }
    }
}
