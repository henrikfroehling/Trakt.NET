namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncHistoryRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncHistoryRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectReader() => new SyncHistoryRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponse)} is not supported.");
        }
    }
}
