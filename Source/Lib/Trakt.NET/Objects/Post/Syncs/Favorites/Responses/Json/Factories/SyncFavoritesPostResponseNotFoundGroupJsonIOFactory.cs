namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncFavoritesPostResponseNotFoundGroup> CreateObjectReader() => new SyncFavoritesPostResponseNotFoundGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesPostResponseNotFoundGroup> CreateObjectWriter() => new SyncFavoritesPostResponseNotFoundGroupObjectJsonWriter();
    }
}
