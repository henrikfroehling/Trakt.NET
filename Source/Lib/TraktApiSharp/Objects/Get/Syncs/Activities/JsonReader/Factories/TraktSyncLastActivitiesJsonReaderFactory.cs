namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncLastActivitiesJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncLastActivities> CreateObjectReader() => new TraktSyncLastActivitiesObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncLastActivities)} is not supported.");
        }
    }
}
