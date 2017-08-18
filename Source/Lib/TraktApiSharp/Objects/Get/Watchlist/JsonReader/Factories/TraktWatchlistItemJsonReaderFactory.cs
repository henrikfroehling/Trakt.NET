namespace TraktApiSharp.Objects.Get.Watchlist.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchlistItemJsonReaderFactory : IJsonReaderFactory<ITraktWatchlistItem>
    {
        public ITraktObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new TraktWatchlistItemObjectJsonReader();

        public IArrayJsonReader<ITraktWatchlistItem> CreateArrayReader() => new TraktWatchlistItemArrayJsonReader();
    }
}
