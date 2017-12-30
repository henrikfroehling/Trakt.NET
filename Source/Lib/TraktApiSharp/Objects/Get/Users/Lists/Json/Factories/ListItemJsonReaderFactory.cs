namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;

    internal class ListItemJsonReaderFactory : IJsonIOFactory<ITraktListItem>
    {
        public IObjectJsonReader<ITraktListItem> CreateObjectReader() => new ListItemObjectJsonReader();

        public IArrayJsonReader<ITraktListItem> CreateArrayReader() => new ListItemArrayJsonReader();

        public IObjectJsonReader<ITraktListItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktListItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
