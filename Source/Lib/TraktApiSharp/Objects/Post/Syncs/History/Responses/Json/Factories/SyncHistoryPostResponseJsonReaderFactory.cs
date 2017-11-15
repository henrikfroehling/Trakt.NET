namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncHistoryPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncHistoryPostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectReader() => new SyncHistoryPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostResponse)} is not supported.");
        }
    }
}
