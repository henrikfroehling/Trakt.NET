namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryRemovePostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectReader() => new SyncHistoryRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
