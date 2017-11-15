namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncListsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncListsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncListsLastActivities> CreateObjectReader() => new SyncListsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncListsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncListsLastActivities)} is not supported.");
        }
    }
}
