namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesPostResponse>
    {
        public IObjectJsonReader<ITraktSyncFavoritesPostResponse> CreateObjectReader() => new SyncFavoritesPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesPostResponse> CreateObjectWriter() => new SyncFavoritesPostResponseObjectJsonWriter();
    }
}
