namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader
{
    internal class SyncRecommendationsRemovePostObjectJsonReader : ASyncRecommendationsPostObjectJsonReader<ITraktSyncRecommendationsRemovePost>
    {
        protected override ITraktSyncRecommendationsRemovePost CreateInstance() => new TraktSyncRecommendationsRemovePost();
    }
}
