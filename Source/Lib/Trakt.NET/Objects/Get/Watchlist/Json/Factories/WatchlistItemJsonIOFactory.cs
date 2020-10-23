namespace TraktNet.Objects.Get.Watchlist.Json.Factories
{
    using Get.Watchlist.Json.Reader;
    using Get.Watchlist.Json.Writer;
    using Objects.Json;

    internal class WatchlistItemJsonIOFactory : IJsonIOFactory<ITraktWatchlistItem>
    {
        public IObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new WatchlistItemObjectJsonReader();

        public IObjectJsonWriter<ITraktWatchlistItem> CreateObjectWriter() => new WatchlistItemObjectJsonWriter();
    }
}
