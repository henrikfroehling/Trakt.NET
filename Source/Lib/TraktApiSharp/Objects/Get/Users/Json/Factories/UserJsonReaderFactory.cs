namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserJsonReaderFactory : IJsonIOFactory<ITraktUser>
    {
        public IObjectJsonReader<ITraktUser> CreateObjectReader() => new UserObjectJsonReader();

        public IArrayJsonReader<ITraktUser> CreateArrayReader() => new UserArrayJsonReader();

        public IObjectJsonReader<ITraktUser> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUser> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
