namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;

    internal sealed class SyncCollectionRemoveRequest : ASyncPostRequest<ITraktSyncCollectionRemovePostResponse, ITraktSyncCollectionRemovePost>
    {
        public override string UriTemplate => "sync/collection/remove";
    }
}
