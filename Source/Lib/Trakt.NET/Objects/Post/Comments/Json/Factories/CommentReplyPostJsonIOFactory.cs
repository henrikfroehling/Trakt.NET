namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class CommentReplyPostJsonIOFactory : IJsonIOFactory<ITraktCommentReplyPost>
    {
        public IObjectJsonReader<ITraktCommentReplyPost> CreateObjectReader() => new CommentReplyPostObjectJsonReader();

        public IArrayJsonReader<ITraktCommentReplyPost> CreateArrayReader() => new CommentReplyPostArrayJsonReader();

        public IObjectJsonWriter<ITraktCommentReplyPost> CreateObjectWriter() => new CommentReplyPostObjectJsonWriter();
    }
}
