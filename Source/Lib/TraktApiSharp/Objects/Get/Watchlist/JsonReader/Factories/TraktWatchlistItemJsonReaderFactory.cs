namespace TraktApiSharp.Objects.Get.Watchlist.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchlistItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchlistItem>
    {
        public ITraktObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new TraktWatchlistItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new TraktWatchlistItemArrayJsonReader();
    }
}
