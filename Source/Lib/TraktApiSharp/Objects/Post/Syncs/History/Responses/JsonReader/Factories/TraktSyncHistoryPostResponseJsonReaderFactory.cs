namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncHistoryPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncHistoryPostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectReader() => new TraktSyncHistoryPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostResponse)} is not supported.");
        }
    }
}
