namespace TraktApiSharp.Objects.Get.Users.Json.Factories.Reader
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserCommentJsonReaderFactory : IJsonReaderFactory<ITraktUserComment>
    {
        public IObjectJsonReader<ITraktUserComment> CreateObjectReader() => new UserCommentObjectJsonReader();

        public IArrayJsonReader<ITraktUserComment> CreateArrayReader() => new UserCommentArrayJsonReader();
    }
}
