namespace TraktApiSharp.Objects.Post.Comments.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Comments.Responses.Json.Reader;
    using System;

    internal class CommentPostResponseJsonReaderFactory : IJsonIOFactory<ITraktCommentPostResponse>
    {
        public IObjectJsonReader<ITraktCommentPostResponse> CreateObjectReader() => new CommentPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCommentPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCommentPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktCommentPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktCommentPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
