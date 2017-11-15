namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncHistoryRemovePostResponseGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncHistoryRemovePostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateObjectReader() => new SyncHistoryRemovePostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseGroup)} is not supported.");
        }
    }
}
