namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserIdsJsonIOFactory : IJsonIOFactory<ITraktUserIds>
    {
        public IObjectJsonReader<ITraktUserIds> CreateObjectReader() => new UserIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserIds> CreateObjectWriter() => new UserIdsObjectJsonWriter();
    }
}
