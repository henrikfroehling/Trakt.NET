namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserJsonIOFactory : IJsonIOFactory<ITraktUser>
    {
        public IObjectJsonReader<ITraktUser> CreateObjectReader() => new UserObjectJsonReader();

        public IArrayJsonReader<ITraktUser> CreateArrayReader() => new UserArrayJsonReader();

        public IObjectJsonWriter<ITraktUser> CreateObjectWriter() => new UserObjectJsonWriter();

        public IArrayJsonWriter<ITraktUser> CreateArrayWriter() => new UserArrayJsonWriter();
    }
}
