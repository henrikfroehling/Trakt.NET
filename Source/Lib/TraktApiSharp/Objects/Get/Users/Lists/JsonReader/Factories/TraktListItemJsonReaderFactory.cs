namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktListItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktListItem>
    {
        public ITraktObjectJsonReader<ITraktListItem> CreateObjectReader() => new TraktListItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktListItem> CreateArrayReader() => new TraktListItemArrayJsonReader();
    }
}
