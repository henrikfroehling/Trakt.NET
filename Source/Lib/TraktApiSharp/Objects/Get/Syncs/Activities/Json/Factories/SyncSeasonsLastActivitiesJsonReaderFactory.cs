namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncSeasonsLastActivitiesJsonReaderFactory : IJsonIOFactory<ITraktSyncSeasonsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectReader() => new SyncSeasonsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncSeasonsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncSeasonsLastActivities)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncSeasonsLastActivities> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
