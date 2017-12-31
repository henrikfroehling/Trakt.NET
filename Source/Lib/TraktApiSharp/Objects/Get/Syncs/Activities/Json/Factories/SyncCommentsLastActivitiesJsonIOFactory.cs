namespace TraktApiSharp.Objects.Get.Syncs.Activities.Json.Factories
{
    using Get.Syncs.Activities.Json.Reader;
    using Objects.Json;
    using System;

    internal class SyncCommentsLastActivitiesJsonIOFactory : IJsonIOFactory<ITraktSyncCommentsLastActivities>
    {
        public IObjectJsonReader<ITraktSyncCommentsLastActivities> CreateObjectReader() => new SyncCommentsLastActivitiesObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCommentsLastActivities> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCommentsLastActivities)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncCommentsLastActivities> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncCommentsLastActivities> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
