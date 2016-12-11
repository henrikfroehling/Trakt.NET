namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;

    internal sealed class TraktSyncRatingsAddRequest : ATraktSyncSingleItemPostRequest<TraktSyncRatingsPostResponse, TraktSyncRatingsPost>
    {
        internal TraktSyncRatingsAddRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "sync/ratings";
    }
}
