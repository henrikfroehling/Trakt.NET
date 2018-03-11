namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncCollectionPostJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPost>
    {
        public IObjectJsonReader<ITraktSyncCollectionPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncCollectionPost)} is not supported.");

        public IArrayJsonReader<ITraktSyncCollectionPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPost)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPost> CreateObjectWriter() => new SyncCollectionPostObjectJsonWriter();
    }
}
