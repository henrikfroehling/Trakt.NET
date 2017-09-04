namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserLikeItemJsonReaderFactory : IJsonReaderFactory<ITraktUserLikeItem>
    {
        public IObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new UserLikeItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserLikeItem> CreateArrayReader() => new UserLikeItemArrayJsonReader();
    }
}
