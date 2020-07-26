namespace TraktNet.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Get.Users.Lists.Json.Writer;
    using Objects.Json;

    internal class ListIdsJsonIOFactory : IJsonIOFactory<ITraktListIds>
    {
        public IObjectJsonReader<ITraktListIds> CreateObjectReader() => new ListIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktListIds> CreateObjectWriter() => new ListIdsObjectJsonWriter();
    }
}
