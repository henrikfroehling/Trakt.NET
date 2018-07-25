namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPost>
    {
        public IObjectJsonReader<ITraktSyncCollectionPost> CreateObjectReader() => new SyncCollectionPostObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPost)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPost> CreateObjectWriter() => new SyncCollectionPostObjectJsonWriter();
    }
}
