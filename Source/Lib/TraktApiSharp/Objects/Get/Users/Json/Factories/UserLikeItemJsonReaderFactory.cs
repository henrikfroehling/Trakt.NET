namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserLikeItemJsonReaderFactory : IJsonReaderFactory<ITraktUserLikeItem>
    {
        public IObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new UserLikeItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new UserLikeItemArrayJsonReader();
    }
}
