namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesPostJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesPost>
    {
        public IObjectJsonReader<ITraktSyncFavoritesPost> CreateObjectReader() => new SyncFavoritesPostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesPost> CreateObjectWriter() => new SyncFavoritesPostObjectJsonWriter();
    }
}
