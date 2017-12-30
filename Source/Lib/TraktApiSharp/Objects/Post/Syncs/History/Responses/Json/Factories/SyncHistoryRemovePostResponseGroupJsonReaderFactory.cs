namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryRemovePostResponseGroupJsonReaderFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateObjectReader() => new SyncHistoryRemovePostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseGroup)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
