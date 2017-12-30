namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncLastActivitiesJsonReaderFactory : IJsonIOFactory<ITraktSyncLastActivities>
    {
        public IObjectJsonReader<ITraktSyncLastActivities> CreateObjectReader() => new SyncLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncLastActivities)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncLastActivities> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncLastActivities> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
