namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionRemovePostJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionRemovePost>
    {
        public IObjectJsonReader<ITraktSyncCollectionRemovePost> CreateObjectReader() => new SyncCollectionRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionRemovePost> CreateObjectWriter() => new SyncCollectionRemovePostObjectJsonWriter();
    }
}
