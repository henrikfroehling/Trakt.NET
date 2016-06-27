namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;

    internal class TraktSyncCollectionAddRequest : TraktPostRequest<TraktSyncCollectionPostResponse, TraktSyncCollectionPostResponse, TraktSyncCollectionPost>
    {
        internal TraktSyncCollectionAddRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/collection";
    }
}
