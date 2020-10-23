namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionPostJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPost>
    {
        public IObjectJsonReader<ITraktSyncCollectionPost> CreateObjectReader() => new SyncCollectionPostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionPost> CreateObjectWriter() => new SyncCollectionPostObjectJsonWriter();
    }
}
