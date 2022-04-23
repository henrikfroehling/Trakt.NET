namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Recommendations;
    using Objects.Post.Syncs.Recommendations.Responses;

    internal class SyncRecommendationsRemoveRequest : ASyncPostRequest<ITraktSyncRecommendationsRemovePostResponse, ITraktSyncRecommendationsPost>
    {
        public override string UriTemplate => "sync/recommendations/remove";
    }
}
