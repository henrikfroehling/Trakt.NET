namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserLikeItemJsonIOFactory : IJsonIOFactory<ITraktUserLikeItem>
    {
        public IObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new UserLikeItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new UserLikeItemArrayJsonReader();

        public IObjectJsonWriter<ITraktUserLikeItem> CreateObjectWriter() => new UserLikeItemObjectJsonWriter();
    }
}
