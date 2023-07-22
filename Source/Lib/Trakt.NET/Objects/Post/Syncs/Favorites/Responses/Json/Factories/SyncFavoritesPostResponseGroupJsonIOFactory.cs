namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncFavoritesPostResponseGroup> CreateObjectReader() => new SyncFavoritesPostResponseGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesPostResponseGroup> CreateObjectWriter() => new SyncFavoritesPostResponseGroupObjectJsonWriter();
    }
}
