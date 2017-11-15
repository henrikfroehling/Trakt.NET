namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncSeasonsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncSeasonsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectReader() => new SyncSeasonsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncSeasonsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncSeasonsLastActivities)} is not supported.");
        }
    }
}
