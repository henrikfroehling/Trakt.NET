namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;

    internal sealed class TraktSyncCollectionAddRequest : ATraktSyncPostRequest<TraktSyncCollectionPostResponse, TraktSyncCollectionPost>
    {
        public override string UriTemplate => "sync/collection";
    }
}
