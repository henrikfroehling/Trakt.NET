namespace TraktNet.Objects.Post.Syncs.Favorites.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncFavoritesPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncFavoritesPostMovie>
    {
        public IObjectJsonReader<ITraktSyncFavoritesPostMovie> CreateObjectReader() => new SyncFavoritesPostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncFavoritesPostMovie> CreateObjectWriter() => new SyncFavoritesPostMovieObjectJsonWriter();
    }
}
