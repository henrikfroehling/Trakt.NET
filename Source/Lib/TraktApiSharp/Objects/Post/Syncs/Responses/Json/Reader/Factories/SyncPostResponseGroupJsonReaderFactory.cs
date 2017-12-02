namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Syncs.Responses.Json.Reader;
    using System;

    internal class SyncPostResponseGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseGroup> CreateObjectReader() => new SyncPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseGroup)} is not supported.");
        }
    }
}
