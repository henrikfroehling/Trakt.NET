namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserImagesJsonIOFactory : IJsonIOFactory<ITraktUserImages>
    {
        public IObjectJsonReader<ITraktUserImages> CreateObjectReader() => new UserImagesObjectJsonReader();

        public IObjectJsonWriter<ITraktUserImages> CreateObjectWriter() => new UserImagesObjectJsonWriter();
    }
}
