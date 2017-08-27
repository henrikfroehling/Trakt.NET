namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;

    internal sealed class TraktSyncCollectionRemoveRequest : ASyncPostRequest<ITraktSyncCollectionRemovePostResponse, TraktSyncCollectionPost>
    {
        public override string UriTemplate => "sync/collection/remove";
    }
}
