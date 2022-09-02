namespace TraktNet.Objects.Get.Lists.Json.Factories
{
    using Get.Lists.Json.Reader;
    using Get.Lists.Json.Writer;
    using Objects.Json;

    internal class ListIdsJsonIOFactory : IJsonIOFactory<ITraktListIds>
    {
        public IObjectJsonReader<ITraktListIds> CreateObjectReader() => new ListIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktListIds> CreateObjectWriter() => new ListIdsObjectJsonWriter();
    }
}
