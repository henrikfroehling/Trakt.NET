namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    internal class SyncRatingsPostObjectJsonReader : ASyncRatingsPostObjectJsonReader<ITraktSyncRatingsPost>
    {
        protected override ITraktSyncRatingsPost CreateInstance() => new TraktSyncRatingsPost();
    }
}
