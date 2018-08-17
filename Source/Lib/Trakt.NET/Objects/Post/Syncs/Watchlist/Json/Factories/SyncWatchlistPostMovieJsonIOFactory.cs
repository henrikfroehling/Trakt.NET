namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostMovie>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostMovie> CreateObjectReader() => new SyncWatchlistPostMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPostMovie> CreateArrayReader() => new SyncWatchlistPostMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistPostMovie> CreateObjectWriter() => new SyncWatchlistPostMovieObjectJsonWriter();
    }
}
