namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;
    using System;

    internal class SyncCommentsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncCommentsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncCommentsLastActivities> CreateObjectReader() => new SyncCommentsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCommentsLastActivities> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCommentsLastActivities)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCommentsLastActivities> CreateObjectWriter() => new SyncCommentsLastActivitiesObjectJsonWriter();

        public IArrayJsonWriter<ITraktSyncCommentsLastActivities> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktSyncCommentsLastActivities)} is not supported.");
    }
}
