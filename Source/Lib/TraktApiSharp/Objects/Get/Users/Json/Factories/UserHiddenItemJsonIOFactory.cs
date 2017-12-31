namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserHiddenItemJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItem>
    {
        public IObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new UserHiddenItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader() => new UserHiddenItemArrayJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserHiddenItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
