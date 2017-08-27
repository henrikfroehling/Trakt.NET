namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;

    internal sealed class SyncCollectionAddRequest : ASyncPostRequest<ITraktSyncCollectionPostResponse, TraktSyncCollectionPost>
    {
        public override string UriTemplate => "sync/collection";
    }
}
