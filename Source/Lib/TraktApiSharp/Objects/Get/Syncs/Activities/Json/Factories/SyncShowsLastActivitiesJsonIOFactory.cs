namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncShowsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncShowsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncShowsLastActivities> CreateObjectReader() => new SyncShowsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncShowsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncShowsLastActivities)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncShowsLastActivities> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncShowsLastActivities> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
