namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Reader
{
    internal class SyncFavoritesRemovePostObjectJsonReader : ASyncFavoritesPostObjectJsonReader<ITraktSyncFavoritesRemovePost>
    {
        protected override ITraktSyncFavoritesRemovePost CreateInstance() => new TraktSyncFavoritesRemovePost();
    }
}
