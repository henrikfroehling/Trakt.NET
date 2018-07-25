namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShow>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShow> CreateObjectReader() => new SyncCollectionPostShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostShow> CreateObjectWriter() => new SyncCollectionPostShowObjectJsonWriter();
    }
}
