namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Responses.Json.Reader;
    using System;

    internal class SyncPostResponseNotFoundGroupJsonReaderFactory : IJsonIOFactory<ITraktSyncPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectReader() => new SyncPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseNotFoundGroup)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
