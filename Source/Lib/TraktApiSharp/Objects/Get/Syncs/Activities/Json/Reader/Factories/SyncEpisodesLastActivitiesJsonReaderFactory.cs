namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories.Reader
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncEpisodesLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncEpisodesLastActivities>
    {
        public IObjectJsonReader<ITraktSyncEpisodesLastActivities> CreateObjectReader() => new SyncEpisodesLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncEpisodesLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncEpisodesLastActivities)} is not supported.");
        }
    }
}
