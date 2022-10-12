namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistPostSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostSeason>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostSeason> CreateObjectReader() => new SyncWatchlistPostSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistPostSeason> CreateObjectWriter() => new SyncWatchlistPostSeasonObjectJsonWriter();
    }
}
