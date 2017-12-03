namespace TraktApiSharp.Objects.Get.Watchlist.Json.Factories.Reader
{
    using Get.Watchlist.Json.Reader;
    using Objects.Json;

    internal class WatchlistItemJsonReaderFactory : IJsonReaderFactory<ITraktWatchlistItem>
    {
        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new WatchlistItemObjectJsonReader();

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new WatchlistItemArrayJsonReader();
    }
}
