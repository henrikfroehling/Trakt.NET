namespace TraktApiSharp.Objects.Get.History.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktHistoryItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktHistoryItem>
    {
        public ITraktObjectJsonReader<ITraktHistoryItem> CreateObjectReader() => new TraktHistoryItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktHistoryItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktHistoryItem)} is not supported.");
        }
    }
}
