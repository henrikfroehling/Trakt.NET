namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncSeasonsLastActivitiesJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncSeasonsLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectReader() => new TraktSyncSeasonsLastActivitiesObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncSeasonsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncSeasonsLastActivities)} is not supported.");
        }
    }
}
