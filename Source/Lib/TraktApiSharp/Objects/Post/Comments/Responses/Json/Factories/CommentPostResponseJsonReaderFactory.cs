namespace TraktApiSharp.Objects.Post.Comments.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class CommentPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktCommentPostResponse>
    {
        public IObjectJsonReader<ITraktCommentPostResponse> CreateObjectReader() => new CommentPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktCommentPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCommentPostResponse)} is not supported.");
        }
    }
}
