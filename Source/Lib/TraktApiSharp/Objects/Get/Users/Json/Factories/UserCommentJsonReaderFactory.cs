namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserCommentJsonReaderFactory : IJsonReaderFactory<ITraktUserComment>
    {
        public IObjectJsonReader<ITraktUserComment> CreateObjectReader() => new UserCommentObjectJsonReader();

        public IArrayJsonReader<ITraktUserComment> CreateArrayReader() => new UserCommentArrayJsonReader();
    }
}
