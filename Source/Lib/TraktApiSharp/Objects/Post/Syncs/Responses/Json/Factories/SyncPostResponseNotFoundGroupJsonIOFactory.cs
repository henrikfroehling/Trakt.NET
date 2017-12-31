namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Responses.Json.Reader;
    using System;

    internal class SyncPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectReader() => new SyncPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseNotFoundGroup)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncPostResponseNotFoundGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncPostResponseNotFoundGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
