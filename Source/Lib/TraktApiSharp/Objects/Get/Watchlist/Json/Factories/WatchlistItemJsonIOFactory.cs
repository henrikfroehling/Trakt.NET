namespace TraktApiSharp.Objects.Get.Watchlist.Json.Factories
{
    using Get.Watchlist.Json.Reader;
    using Objects.Json;

    internal class WatchlistItemJsonIOFactory : IJsonIOFactory<ITraktWatchlistItem>
    {
        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new WatchlistItemObjectJsonReader();

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new WatchlistItemArrayJsonReader();

        public IObjectJsonWriter<ITraktWatchlistItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktWatchlistItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
