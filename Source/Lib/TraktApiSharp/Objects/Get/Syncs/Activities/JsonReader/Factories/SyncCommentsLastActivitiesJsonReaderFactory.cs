namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncCommentsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncCommentsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncCommentsLastActivities> CreateObjectReader() => new TraktSyncCommentsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCommentsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCommentsLastActivities)} is not supported.");
        }
    }
}
