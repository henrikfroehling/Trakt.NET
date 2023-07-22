namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Favorites;
    using Objects.Post.Syncs.Favorites.Responses;

    internal class SyncFavoritesRemoveRequest : ASyncPostRequest<ITraktSyncFavoritesRemovePostResponse, ITraktSyncFavoritesRemovePost>
    {
        public override string UriTemplate => "sync/favorites/remove";
    }
}
