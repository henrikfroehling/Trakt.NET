namespace TraktApiSharp.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class MovieCommentPostJsonIOFactory : IJsonIOFactory<ITraktMovieCommentPost>
    {
        public IObjectJsonReader<ITraktMovieCommentPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktMovieCommentPost)} is not supported.");

        public IArrayJsonReader<ITraktMovieCommentPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieCommentPost)} is not supported.");

        public IObjectJsonWriter<ITraktMovieCommentPost> CreateObjectWriter() => new MovieCommentPostObjectJsonWriter();
    }
}
