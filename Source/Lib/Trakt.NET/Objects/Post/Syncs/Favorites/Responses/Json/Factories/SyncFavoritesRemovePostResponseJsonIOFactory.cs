namespace TraktNet.Objects.Post.Syncs.Favorites.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncFavoritesRemovePostResponse> CreateObjectReader() => new SyncFavoritesRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesRemovePostResponse> CreateObjectWriter() => new SyncFavoritesRemovePostResponseObjectJsonWriter();
    }
}
