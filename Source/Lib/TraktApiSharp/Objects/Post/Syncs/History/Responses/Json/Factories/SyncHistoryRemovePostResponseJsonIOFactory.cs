namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncHistoryRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectReader()
            => new SyncHistoryRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostResponse> CreateObjectWriter()
            => new SyncHistoryRemovePostResponseObjectJsonWriter();
    }
}
