namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserHiddenItemJsonReaderFactory : IJsonReaderFactory<ITraktUserHiddenItem>
    {
        public ITraktObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new TraktUserHiddenItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader() => new TraktUserHiddenItemArrayJsonReader();
    }
}
