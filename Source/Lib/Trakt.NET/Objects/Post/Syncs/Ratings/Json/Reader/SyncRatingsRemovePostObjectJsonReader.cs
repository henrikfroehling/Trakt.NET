namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    internal class SyncRatingsRemovePostObjectJsonReader : ASyncRatingsPostObjectJsonReader<ITraktSyncRatingsRemovePost>
    {
        protected override ITraktSyncRatingsRemovePost CreateInstance() => new TraktSyncRatingsRemovePost();
    }
}
