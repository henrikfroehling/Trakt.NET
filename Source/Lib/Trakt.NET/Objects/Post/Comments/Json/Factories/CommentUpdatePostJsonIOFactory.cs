namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class CommentUpdatePostJsonIOFactory : IJsonIOFactory<ITraktCommentUpdatePost>
    {
        public IObjectJsonReader<ITraktCommentUpdatePost> CreateObjectReader() => new CommentUpdatePostObjectJsonReader();

        public IObjectJsonWriter<ITraktCommentUpdatePost> CreateObjectWriter() => new CommentUpdatePostObjectJsonWriter();
    }
}
