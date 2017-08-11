namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncHistoryRemovePostResponseJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncHistoryRemovePostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectReader() => new TraktSyncHistoryRemovePostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncHistoryRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponse)} is not supported.");
        }
    }
}
