namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;

    internal sealed class TraktSyncRatingsRemoveRequest : ATraktSyncPostRequest<ITraktSyncRatingsRemovePostResponse, TraktSyncRatingsPost>
    {
        public override string UriTemplate => "sync/ratings/remove";
    }
}
