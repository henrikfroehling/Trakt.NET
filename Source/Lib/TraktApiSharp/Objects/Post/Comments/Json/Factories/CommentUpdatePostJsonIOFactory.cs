namespace TraktApiSharp.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class CommentUpdatePostJsonIOFactory : IJsonIOFactory<ITraktCommentUpdatePost>
    {
        public IObjectJsonReader<ITraktCommentUpdatePost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktCommentUpdatePost)} is not supported.");

        public IArrayJsonReader<ITraktCommentUpdatePost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktCommentUpdatePost)} is not supported.");

        public IObjectJsonWriter<ITraktCommentUpdatePost> CreateObjectWriter() => new CommentUpdatePostObjectJsonWriter();
    }
}
