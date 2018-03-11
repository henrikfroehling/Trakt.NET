namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserHiddenItemJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItem>
    {
        public IObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new UserHiddenItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader() => new UserHiddenItemArrayJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItem> CreateObjectWriter() => new UserHiddenItemObjectJsonWriter();
    }
}
