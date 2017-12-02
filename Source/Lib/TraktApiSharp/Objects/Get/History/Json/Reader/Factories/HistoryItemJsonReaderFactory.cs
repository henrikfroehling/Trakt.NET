namespace TraktApiSharp.Objects.Get.History.Json.Factories.Reader
{
    using Get.History.Json.Reader;
    using Objects.Json;

    internal class HistoryItemJsonReaderFactory : IJsonReaderFactory<ITraktHistoryItem>
    {
        public IObjectJsonReader<ITraktHistoryItem> CreateObjectReader() => new HistoryItemObjectJsonReader();

        public IArrayJsonReader<ITraktHistoryItem> CreateArrayReader() => new HistoryItemArrayJsonReader();
    }
}
