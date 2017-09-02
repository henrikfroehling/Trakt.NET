namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncHistoryRemovePostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateObjectReader() => new TraktSyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseNotFoundGroup)} is not supported.");
        }
    }
}
