namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserLikeItemJsonReaderFactory : IJsonIOFactory<ITraktUserLikeItem>
    {
        public IObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new UserLikeItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new UserLikeItemArrayJsonReader();

        public IObjectJsonReader<ITraktUserLikeItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
