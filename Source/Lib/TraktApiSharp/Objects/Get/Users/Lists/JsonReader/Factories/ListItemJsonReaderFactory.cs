namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class ListItemJsonReaderFactory : IJsonReaderFactory<ITraktListItem>
    {
        public IObjectJsonReader<ITraktListItem> CreateObjectReader() => new TraktListItemObjectJsonReader();

        public IArrayJsonReader<ITraktListItem> CreateArrayReader() => new ListItemArrayJsonReader();
    }
}
