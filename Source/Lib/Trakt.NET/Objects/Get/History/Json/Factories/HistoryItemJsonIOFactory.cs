namespace TraktNet.Objects.Get.History.Json.Factories
{
    using Get.History.Json.Reader;
    using Get.History.Json.Writer;
    using Objects.Json;

    internal class HistoryItemJsonIOFactory : IJsonIOFactory<ITraktHistoryItem>
    {
        public IObjectJsonReader<ITraktHistoryItem> CreateObjectReader() => new HistoryItemObjectJsonReader();

        public IObjectJsonWriter<ITraktHistoryItem> CreateObjectWriter() => new HistoryItemObjectJsonWriter();
    }
}
