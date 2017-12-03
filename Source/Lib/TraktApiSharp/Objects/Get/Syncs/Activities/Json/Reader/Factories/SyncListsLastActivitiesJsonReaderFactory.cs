namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories.Reader
{
    using Get.Syncs.Activities.Json.Reader;
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
