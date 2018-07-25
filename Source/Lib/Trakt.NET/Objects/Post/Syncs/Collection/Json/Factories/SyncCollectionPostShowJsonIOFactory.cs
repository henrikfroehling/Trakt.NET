namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShow>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShow> CreateObjectReader() => new SyncCollectionPostShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostShow> CreateArrayReader() => new SyncCollectionPostShowArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionPostShow> CreateObjectWriter() => new SyncCollectionPostShowObjectJsonWriter();
    }
}
