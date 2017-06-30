namespace TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncCommentsLastActivitiesJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncCommentsLastActivities>
    {
        public ITraktObjectJsonReader<ITraktSyncCommentsLastActivities> CreateObjectReader() => new TraktSyncCommentsLastActivitiesObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncCommentsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCommentsLastActivities)} is not supported.");
        }
    }
}
