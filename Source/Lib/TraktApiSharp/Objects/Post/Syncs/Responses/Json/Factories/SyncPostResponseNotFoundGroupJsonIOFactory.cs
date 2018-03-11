namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectReader() => new SyncPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseNotFoundGroup)} is not supported.");

        public IObjectJsonWriter<ITraktSyncPostResponseNotFoundGroup> CreateObjectWriter() => new SyncPostResponseNotFoundGroupObjectJsonWriter();
    }
}
