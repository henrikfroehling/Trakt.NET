namespace TraktNet.Objects.Get.Lists.Json.Factories
{
    using Get.Lists.Json.Reader;
    using Get.Lists.Json.Writer;
    using Objects.Json;

    internal class ListItemJsonIOFactory : IJsonIOFactory<ITraktListItem>
    {
        public IObjectJsonReader<ITraktListItem> CreateObjectReader() => new ListItemObjectJsonReader();

        public IObjectJsonWriter<ITraktListItem> CreateObjectWriter() => new ListItemObjectJsonWriter();
    }
}
