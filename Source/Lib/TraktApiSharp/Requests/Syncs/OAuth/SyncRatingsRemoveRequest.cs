namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;

    internal sealed class SyncRatingsRemoveRequest : ASyncPostRequest<ITraktSyncRatingsRemovePostResponse, TraktSyncRatingsPost>
    {
        public override string UriTemplate => "sync/ratings/remove";
    }
}
