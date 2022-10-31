namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader
{
    internal class SyncRecommendationsPostObjectJsonReader : ASyncRecommendationsPostObjectJsonReader<ITraktSyncRecommendationsPost>
    {
        protected override ITraktSyncRecommendationsPost CreateInstance() => new TraktSyncRecommendationsPost();
    }
}
