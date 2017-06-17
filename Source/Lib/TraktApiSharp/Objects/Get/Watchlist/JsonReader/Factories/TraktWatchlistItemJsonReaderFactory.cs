namespace TraktApiSharp.Objects.Get.Watchlist.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktWatchlistItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchlistItem>
    {
        public ITraktObjectJsonReader<ITraktWatchlistItem> CreateObjectReader() => new TraktWatchlistItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchlistItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktWatchlistItem)} is not supported.");
        }
    }
}
