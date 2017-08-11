namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncHistoryRemovePostResponseGroupJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncHistoryRemovePostResponseGroup>
    {
        public ITraktObjectJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateObjectReader() => new TraktSyncHistoryRemovePostResponseGroupObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseGroup)} is not supported.");
        }
    }
}
