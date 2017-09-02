namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserJsonReaderFactory : IJsonReaderFactory<ITraktUser>
    {
        public IObjectJsonReader<ITraktUser> CreateObjectReader() => new UserObjectJsonReader();

        public IArrayJsonReader<ITraktUser> CreateArrayReader() => new UserArrayJsonReader();
    }
}
