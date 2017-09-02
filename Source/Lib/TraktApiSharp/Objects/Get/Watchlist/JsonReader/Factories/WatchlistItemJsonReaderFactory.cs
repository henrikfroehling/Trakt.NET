namespace TraktApiSharp.Objects.Get.Watchlist.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class WatchlistItemJsonReaderFactory : IJsonReaderFactory<ITraktWatchlistItem>
    {
        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new TraktWatchlistItemObjectJsonReader();

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new WatchlistItemArrayJsonReader();
    }
}
