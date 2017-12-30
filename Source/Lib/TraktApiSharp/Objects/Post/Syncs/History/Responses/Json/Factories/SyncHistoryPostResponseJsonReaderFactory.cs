namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryPostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncHistoryPostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectReader() => new SyncHistoryPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
