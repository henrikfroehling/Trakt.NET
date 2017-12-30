namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryRemovePostResponseNotFoundGroupJsonReaderFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateObjectReader() => new SyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseNotFoundGroup)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
