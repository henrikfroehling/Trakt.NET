namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncListsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncListsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncListsLastActivities> CreateObjectReader() => new SyncListsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncListsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncListsLastActivities)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncListsLastActivities> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncListsLastActivities> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
