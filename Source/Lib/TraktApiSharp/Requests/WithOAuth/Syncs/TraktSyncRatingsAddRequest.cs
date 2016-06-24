namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;

    internal class TraktSyncRatingsAddRequest : TraktPostRequest<TraktSyncRatingsPostResponse, TraktSyncRatingsPostResponse, TraktSyncRatingsPost>
    {
        internal TraktSyncRatingsAddRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/ratings";
    }
}
