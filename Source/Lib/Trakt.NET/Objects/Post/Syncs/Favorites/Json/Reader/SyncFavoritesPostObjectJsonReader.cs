namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Reader
{
    internal class SyncFavoritesPostObjectJsonReader : ASyncFavoritesPostObjectJsonReader<ITraktSyncFavoritesPost>
    {
        protected override ITraktSyncFavoritesPost CreateInstance() => new TraktSyncFavoritesPost();
    }
}
