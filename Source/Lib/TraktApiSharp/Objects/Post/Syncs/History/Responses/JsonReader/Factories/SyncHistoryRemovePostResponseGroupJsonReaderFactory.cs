namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
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
