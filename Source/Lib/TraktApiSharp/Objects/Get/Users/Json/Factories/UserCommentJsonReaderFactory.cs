namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserCommentJsonReaderFactory : IJsonIOFactory<ITraktUserComment>
    {
        public IObjectJsonReader<ITraktUserComment> CreateObjectReader() => new UserCommentObjectJsonReader();

        public IArrayJsonReader<ITraktUserComment> CreateArrayReader() => new UserCommentArrayJsonReader();

        public IObjectJsonReader<ITraktUserComment> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserComment> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
