namespace TraktApiSharp.Objects.Get.Watchlist.Json.Factories
{
    using Get.Watchlist.Json.Reader;
    using Objects.Json;

    internal class WatchlistItemJsonReaderFactory : IJsonIOFactory<ITraktWatchlistItem>
    {
        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new WatchlistItemObjectJsonReader();

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new WatchlistItemArrayJsonReader();

        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
