namespace TraktNet.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;
    using System;

    internal class SyncSeasonsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncSeasonsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectReader() => new SyncSeasonsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncSeasonsLastActivities> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncSeasonsLastActivities)} is not supported.");

        public IObjectJsonWriter<ITraktSyncSeasonsLastActivities> CreateObjectWriter() => new SyncSeasonsLastActivitiesObjectJsonWriter();
    }
}
