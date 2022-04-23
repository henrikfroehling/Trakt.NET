namespace TraktNet.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Get.Users.Lists.Json.Writer;
    using Objects.Json;

    internal class ListLikeJsonIOFactory : IJsonIOFactory<ITraktListLike>
    {
        public IObjectJsonReader<ITraktListLike> CreateObjectReader() => new ListLikeObjectJsonReader();

        public IObjectJsonWriter<ITraktListLike> CreateObjectWriter() => new ListLikeObjectJsonWriter();
    }
}
