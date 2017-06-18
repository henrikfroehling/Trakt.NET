namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncEpisodesLastActivitiesJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncEpisodesLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncEpisodesLastActivities> CreateObjectReader() => new TraktSyncEpisodesLastActivitiesObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncEpisodesLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncEpisodesLastActivities)} is not supported.");
        }
    }
}
