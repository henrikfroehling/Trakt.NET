namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserCommentJsonReaderFactory : IJsonReaderFactory<ITraktUserComment>
    {
        public IObjectJsonReader<ITraktUserComment> CreateObjectReader() => new TraktUserCommentObjectJsonReader();

        public IArrayJsonReader<ITraktUserComment> CreateArrayReader() => new TraktUserCommentArrayJsonReader();
    }
}
