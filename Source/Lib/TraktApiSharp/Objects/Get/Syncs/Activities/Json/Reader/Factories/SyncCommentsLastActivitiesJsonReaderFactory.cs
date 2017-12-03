namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories.Reader
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncCommentsLastActivitiesJsonReaderFactory : IJsonReaderFactory<ITraktSyncCommentsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncCommentsLastActivities> CreateObjectReader() => new SyncCommentsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCommentsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCommentsLastActivities)} is not supported.");
        }
    }
}
