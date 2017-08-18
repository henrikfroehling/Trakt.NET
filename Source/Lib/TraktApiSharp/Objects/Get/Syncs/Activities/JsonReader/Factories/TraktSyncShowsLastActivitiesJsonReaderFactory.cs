namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncShowsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncShowsLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncShowsLastActivities> CreateObjectReader() => new TraktSyncShowsLastActivitiesObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncShowsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncShowsLastActivities)} is not supported.");
        }
    }
}
