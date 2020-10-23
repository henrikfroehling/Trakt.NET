namespace TraktNet.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Get.Users.Lists.Json.Writer;
    using Objects.Json;

    internal class ListItemJsonIOFactory : IJsonIOFactory<ITraktListItem>
    {
        public IObjectJsonReader<ITraktListItem> CreateObjectReader() => new ListItemObjectJsonReader();

        public IObjectJsonWriter<ITraktListItem> CreateObjectWriter() => new ListItemObjectJsonWriter();
    }
}
