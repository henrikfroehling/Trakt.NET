namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories.Reader
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;

    internal class ListItemJsonReaderFactory : IJsonReaderFactory<ITraktListItem>
    {
        public IObjectJsonReader<ITraktListItem> CreateObjectReader() => new ListItemObjectJsonReader();

        public IArrayJsonReader<ITraktListItem> CreateArrayReader() => new ListItemArrayJsonReader();
    }
}
