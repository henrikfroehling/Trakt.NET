namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class CommentReplyPostJsonIOFactory : IJsonIOFactory<ITraktCommentReplyPost>
    {
        public IObjectJsonReader<ITraktCommentReplyPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktCommentReplyPost)} is not supported.");

        public IArrayJsonReader<ITraktCommentReplyPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktCommentReplyPost)} is not supported.");

        public IObjectJsonWriter<ITraktCommentReplyPost> CreateObjectWriter() => new CommentReplyPostObjectJsonWriter();
    }
}
