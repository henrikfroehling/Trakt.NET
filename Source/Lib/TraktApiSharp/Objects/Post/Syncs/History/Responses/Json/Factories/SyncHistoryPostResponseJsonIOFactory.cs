namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectReader() => new SyncHistoryPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncHistoryPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncHistoryPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
