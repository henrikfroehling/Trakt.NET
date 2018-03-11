namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncHistoryRemovePostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateObjectReader()
            => new SyncHistoryRemovePostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseNotFoundGroup)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostResponseNotFoundGroup> CreateObjectWriter()
            => new SyncHistoryRemovePostResponseNotFoundGroupObjectJsonWriter();
    }
}
