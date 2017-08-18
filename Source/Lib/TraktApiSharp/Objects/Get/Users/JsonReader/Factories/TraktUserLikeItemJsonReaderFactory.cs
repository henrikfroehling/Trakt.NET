namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserLikeItemJsonReaderFactory : IJsonReaderFactory<ITraktUserLikeItem>
    {
        public ITraktObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new TraktUserLikeItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new TraktUserLikeItemArrayJsonReader();
    }
}
