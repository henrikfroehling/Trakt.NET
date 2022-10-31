namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    internal class SyncCollectionRemovePostObjectJsonReader : ASyncCollectionPostObjectJsonReader<ITraktSyncCollectionRemovePost>
    {
        protected override ITraktSyncCollectionRemovePost CreateInstance() => new TraktSyncCollectionRemovePost();
    }
}
