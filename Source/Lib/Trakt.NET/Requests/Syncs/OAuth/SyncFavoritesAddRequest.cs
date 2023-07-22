namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Favorites;
    using Objects.Post.Syncs.Favorites.Responses;

    internal sealed class SyncFavoritesAddRequest : ASyncPostRequest<ITraktSyncFavoritesPostResponse, ITraktSyncFavoritesPost>
    {
        public override string UriTemplate => "sync/favorites";
    }
}
