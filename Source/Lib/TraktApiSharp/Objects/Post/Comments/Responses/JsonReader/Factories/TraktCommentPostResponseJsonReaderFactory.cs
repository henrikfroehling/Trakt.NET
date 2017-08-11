namespace TraktApiSharp.Objects.Post.Comments.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCommentPostResponseJsonReaderFactory : ITraktJsonReaderFactory<ITraktCommentPostResponse>
    {
        public ITraktObjectJsonReader<ITraktCommentPostResponse> CreateObjectReader() => new TraktCommentPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCommentPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCommentPostResponse)} is not supported.");
        }
    }
}
