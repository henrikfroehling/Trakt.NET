namespace TraktApiSharp.Objects.Get.History.Json.Factories
{
    using Get.History.Json.Reader;
    using Objects.Json;

    internal class HistoryItemJsonReaderFactory : IJsonIOFactory<ITraktHistoryItem>
    {
        public IObjectJsonReader<ITraktHistoryItem> CreateObjectReader() => new HistoryItemObjectJsonReader();

        public IArrayJsonReader<ITraktHistoryItem> CreateArrayReader() => new HistoryItemArrayJsonReader();

        public IObjectJsonReader<ITraktHistoryItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktHistoryItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
