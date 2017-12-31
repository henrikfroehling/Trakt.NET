namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectReader() => new SyncHistoryRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncHistoryRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
