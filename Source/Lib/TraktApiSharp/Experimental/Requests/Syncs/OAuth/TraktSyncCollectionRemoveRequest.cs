namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;

    internal sealed class TraktSyncCollectionRemoveRequest : ATraktSyncSingleItemPostRequest<TraktSyncCollectionRemovePostResponse, TraktSyncCollectionPost>
    {
        internal TraktSyncCollectionRemoveRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "sync/collection/remove";
    }
}
