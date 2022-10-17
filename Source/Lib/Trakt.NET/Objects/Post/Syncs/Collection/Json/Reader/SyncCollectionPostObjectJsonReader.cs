namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    internal class SyncCollectionPostObjectJsonReader : ASyncCollectionPostObjectJsonReader<ITraktSyncCollectionPost>
    {
        protected override ITraktSyncCollectionPost CreateInstance() => new TraktSyncCollectionPost();
    }
}
