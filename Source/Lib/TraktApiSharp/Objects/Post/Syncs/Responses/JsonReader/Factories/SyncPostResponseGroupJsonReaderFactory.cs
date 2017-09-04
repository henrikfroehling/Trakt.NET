namespace TraktApiSharp.Objects.Post.Syncs.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncPostResponseGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseGroup> CreateObjectReader() => new TraktSyncPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseGroup)} is not supported.");
        }
    }
}
