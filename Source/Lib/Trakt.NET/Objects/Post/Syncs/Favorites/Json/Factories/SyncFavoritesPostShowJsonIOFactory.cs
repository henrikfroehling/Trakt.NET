namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesPostShow>
    {
        public IObjectJsonReader<ITraktSyncFavoritesPostShow> CreateObjectReader() => new SyncFavoritesPostShowObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesPostShow> CreateObjectWriter() => new SyncFavoritesPostShowObjectJsonWriter();
    }
}
