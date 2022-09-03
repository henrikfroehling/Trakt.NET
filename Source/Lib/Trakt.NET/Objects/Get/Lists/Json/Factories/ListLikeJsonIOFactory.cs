namespace TraktNet.Objects.Get.Lists.Json.Factories
{
    using Get.Lists.Json.Reader;
    using Get.Lists.Json.Writer;
    using Objects.Json;

    internal class ListLikeJsonIOFactory : IJsonIOFactory<ITraktListLike>
    {
        public IObjectJsonReader<ITraktListLike> CreateObjectReader() => new ListLikeObjectJsonReader();

        public IObjectJsonWriter<ITraktListLike> CreateObjectWriter() => new ListLikeObjectJsonWriter();
    }
}
