namespace TraktApiSharp.Objects.Get.Users.Json.Factories.Reader
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserJsonReaderFactory : IJsonReaderFactory<ITraktUser>
    {
        public IObjectJsonReader<ITraktUser> CreateObjectReader() => new UserObjectJsonReader();

        public IArrayJsonReader<ITraktUser> CreateArrayReader() => new UserArrayJsonReader();
    }
}
