namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncPostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectReader() => new SyncPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
