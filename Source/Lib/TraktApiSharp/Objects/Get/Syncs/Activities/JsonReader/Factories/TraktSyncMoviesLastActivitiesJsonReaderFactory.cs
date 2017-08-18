namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncMoviesLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncMoviesLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncMoviesLastActivities> CreateObjectReader() => new TraktSyncMoviesLastActivitiesObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncMoviesLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncMoviesLastActivities)} is not supported.");
        }
    }
}
