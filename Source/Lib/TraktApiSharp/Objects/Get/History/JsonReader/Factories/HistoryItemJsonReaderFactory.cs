namespace TraktApiSharp.Objects.Get.History.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class HistoryItemJsonReaderFactory : IJsonReaderFactory<ITraktHistoryItem>
    {
        public IObjectJsonReader<ITraktHistoryItem> CreateObjectReader() => new TraktHistoryItemObjectJsonReader();

        public IArrayJsonReader<ITraktHistoryItem> CreateArrayReader() => new HistoryItemArrayJsonReader();
    }
}
