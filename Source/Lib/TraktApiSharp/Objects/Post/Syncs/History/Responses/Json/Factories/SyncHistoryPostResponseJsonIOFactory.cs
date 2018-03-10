namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncHistoryPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectReader() => new SyncHistoryPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPostResponse> CreateObjectWriter() => new SyncHistoryPostResponseObjectJsonWriter();
    }
}
