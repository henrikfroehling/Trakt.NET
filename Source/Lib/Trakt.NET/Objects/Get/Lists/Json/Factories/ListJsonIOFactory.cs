namespace TraktNet.Objects.Get.Lists.Json.Factories
{
    using Get.Lists.Json.Reader;
    using Get.Lists.Json.Writer;
    using Objects.Json;

    internal class ListJsonIOFactory : IJsonIOFactory<ITraktList>
    {
        public IObjectJsonReader<ITraktList> CreateObjectReader() => new ListObjectJsonReader();

        public IObjectJsonWriter<ITraktList> CreateObjectWriter() => new ListObjectJsonWriter();
    }
}
