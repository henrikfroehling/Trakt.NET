namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncHistoryRemovePostJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePost>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryRemovePost)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryRemovePost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePost)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryRemovePost> CreateObjectWriter() => new SyncHistoryRemovePostObjectJsonWriter();
    }
}
