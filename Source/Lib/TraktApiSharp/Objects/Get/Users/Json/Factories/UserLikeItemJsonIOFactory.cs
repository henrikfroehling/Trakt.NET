namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserLikeItemJsonIOFactory : IJsonIOFactory<ITraktUserLikeItem>
    {
        public IObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new UserLikeItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new UserLikeItemArrayJsonReader();

        public IObjectJsonWriter<ITraktUserLikeItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserLikeItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
