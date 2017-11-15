namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserJsonReaderFactory : IJsonReaderFactory<ITraktUser>
    {
        public IObjectJsonReader<ITraktUser> CreateObjectReader() => new UserObjectJsonReader();

        public IArrayJsonReader<ITraktUser> CreateArrayReader() => new UserArrayJsonReader();
    }
}
