namespace TraktApiSharp.Objects.Get.Watchlist.Json.Factories
{
    using Objects.Json;

    internal class WatchlistItemJsonReaderFactory : IJsonReaderFactory<ITraktWatchlistItem>
    {
        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new WatchlistItemObjectJsonReader();

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new WatchlistItemArrayJsonReader();
    }
}
