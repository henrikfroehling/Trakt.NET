namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;

    internal sealed class SyncRatingsAddRequest : ASyncPostRequest<ITraktSyncRatingsPostResponse, ITraktSyncRatingsPost>
    {
        public override string UriTemplate => "sync/ratings";
    }
}
