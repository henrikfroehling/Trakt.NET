namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Recommendations;
    using Objects.Post.Syncs.Recommendations.Responses;

    internal sealed class SyncRecommendationsAddRequest : ASyncPostRequest<ITraktSyncRecommendationsPostResponse, ITraktSyncRecommendationsPost>
    {
        public override string UriTemplate => "sync/recommendations";
    }
}
