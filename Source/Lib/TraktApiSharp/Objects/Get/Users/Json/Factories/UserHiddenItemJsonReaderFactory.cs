namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserHiddenItemJsonReaderFactory : IJsonIOFactory<ITraktUserHiddenItem>
    {
        public IObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new UserHiddenItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader() => new UserHiddenItemArrayJsonReader();

        public IObjectJsonReader<ITraktUserHiddenItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserHiddenItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
