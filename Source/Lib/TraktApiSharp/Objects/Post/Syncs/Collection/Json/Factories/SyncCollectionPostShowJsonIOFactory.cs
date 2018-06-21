namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncCollectionPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShow>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShow> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncCollectionPostShow)} is not supported.");

        public IArrayJsonReader<ITraktSyncCollectionPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostShow> CreateObjectWriter() => new SyncCollectionPostShowObjectJsonWriter();
    }
}
