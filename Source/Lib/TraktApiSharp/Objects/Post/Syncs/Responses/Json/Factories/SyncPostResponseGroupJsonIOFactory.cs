namespace TraktApiSharp.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktSyncPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseGroup> CreateObjectReader() => new SyncPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseGroup)} is not supported.");

        public IObjectJsonWriter<ITraktSyncPostResponseGroup> CreateObjectWriter() => new SyncPostResponseGroupObjectJsonWriter();
    }
}
