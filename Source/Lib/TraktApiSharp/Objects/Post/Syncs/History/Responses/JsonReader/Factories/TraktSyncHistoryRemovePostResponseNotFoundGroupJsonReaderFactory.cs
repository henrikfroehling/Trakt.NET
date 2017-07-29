namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncHistoryRemovePostResponseNotFoundGroupJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        public ITraktObjectJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateObjectReader() => new TraktSyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseNotFoundGroup)} is not supported.");
        }
    }
}
