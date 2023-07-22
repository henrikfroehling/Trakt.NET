namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesRemovePostJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesRemovePost>
    {
        public IObjectJsonReader<ITraktSyncFavoritesRemovePost> CreateObjectReader() => new SyncFavoritesRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesRemovePost> CreateObjectWriter() => new SyncFavoritesRemovePostObjectJsonWriter();
    }
}
