namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;

    internal class TraktSyncRatingsRemoveRequest : TraktPostRequest<TraktSyncRatingsRemovePostResponse, TraktSyncRatingsRemovePostResponse, TraktSyncRatingsRemovePost>
    {
        internal TraktSyncRatingsRemoveRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/ratings/remove";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
