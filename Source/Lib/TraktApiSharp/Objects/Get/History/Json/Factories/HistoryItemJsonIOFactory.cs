namespace TraktApiSharp.Objects.Get.History.Json.Factories
{
    using Get.History.Json.Reader;
    using Objects.Json;

    internal class HistoryItemJsonIOFactory : IJsonIOFactory<ITraktHistoryItem>
    {
        public IObjectJsonReader<ITraktHistoryItem> CreateObjectReader() => new HistoryItemObjectJsonReader();

        public IArrayJsonReader<ITraktHistoryItem> CreateArrayReader() => new HistoryItemArrayJsonReader();

        public IObjectJsonWriter<ITraktHistoryItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktHistoryItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
