namespace TraktApiSharp.Objects.Post.Comments.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class CommentPostResponseJsonIOFactory : IJsonIOFactory<ITraktCommentPostResponse>
    {
        public IObjectJsonReader<ITraktCommentPostResponse> CreateObjectReader() => new CommentPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCommentPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktCommentPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktCommentPostResponse> CreateObjectWriter() => new CommentPostResponseObjectJsonWriter();
    }
}
