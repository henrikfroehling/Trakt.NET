namespace TraktNet.Objects.Get.Lists.Json.Factories
{
    using Get.Lists.Json.Reader;
    using Get.Lists.Json.Writer;
    using Objects.Json;

    internal class PopularListJsonIOFactory : IJsonIOFactory<ITraktPopularList>
    {
        public IObjectJsonReader<ITraktPopularList> CreateObjectReader() => new PopularListObjectJsonReader();

        public IObjectJsonWriter<ITraktPopularList> CreateObjectWriter() => new PopularListObjectJsonWriter();
    }
}
