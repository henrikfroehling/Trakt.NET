namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserLikeItemJsonReaderFactory : IJsonReaderFactory<ITraktUserLikeItem>
    {
        public ITraktObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new TraktUserLikeItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new TraktUserLikeItemArrayJsonReader();
    }
}
