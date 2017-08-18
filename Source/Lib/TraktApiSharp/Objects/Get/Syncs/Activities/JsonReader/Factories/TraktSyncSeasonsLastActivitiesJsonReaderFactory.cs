namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncSeasonsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncSeasonsLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncSeasonsLastActivities> CreateObjectReader() => new TraktSyncSeasonsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncSeasonsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncSeasonsLastActivities)} is not supported.");
        }
    }
}
