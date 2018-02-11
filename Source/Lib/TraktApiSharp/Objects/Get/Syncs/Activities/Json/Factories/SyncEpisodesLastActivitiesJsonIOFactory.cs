namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Get.Syncs.Activities.Json.Writer;
    using Objects.Json;
    using System;

    internal class SyncEpisodesLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncEpisodesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncEpisodesLastActivities> CreateObjectReader() => new SyncEpisodesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncEpisodesLastActivities> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncEpisodesLastActivities)} is not supported.");

        public IObjectJsonWriter<ITraktSyncEpisodesLastActivities> CreateObjectWriter() => new SyncEpisodesLastActivitiesObjectJsonWriter();

        public IArrayJsonWriter<ITraktSyncEpisodesLastActivities> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktSyncEpisodesLastActivities)} is not supported.");
    }
}
