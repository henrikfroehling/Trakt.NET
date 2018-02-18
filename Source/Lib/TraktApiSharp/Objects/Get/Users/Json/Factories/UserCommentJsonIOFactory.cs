namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserCommentJsonIOFactory : IJsonIOFactory<ITraktUserComment>
    {
        public IObjectJsonReader<ITraktUserComment> CreateObjectReader() => new UserCommentObjectJsonReader();

        public IArrayJsonReader<ITraktUserComment> CreateArrayReader() => new UserCommentArrayJsonReader();

        public IObjectJsonWriter<ITraktUserComment> CreateObjectWriter() => new UserCommentObjectJsonWriter();

        public IArrayJsonWriter<ITraktUserComment> CreateArrayWriter() => new UserCommentArrayJsonWriter();
    }
}
