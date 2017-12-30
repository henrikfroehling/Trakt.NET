namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncListsLastActivitiesJsonReaderFactory : IJsonIOFactory<ITraktSyncListsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncListsLastActivities> CreateObjectReader() => new SyncListsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncListsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncListsLastActivities)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncListsLastActivities> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncListsLastActivities> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
