namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;
    using System;

    internal class SyncListsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncListsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncListsLastActivities> CreateObjectReader() => new SyncListsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncListsLastActivities> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncListsLastActivities)} is not supported.");

        public IObjectJsonWriter<ITraktSyncListsLastActivities> CreateObjectWriter() => new SyncListsLastActivitiesObjectJsonWriter();

        public IArrayJsonWriter<ITraktSyncListsLastActivities> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktSyncListsLastActivities)} is not supported.");
    }
}
