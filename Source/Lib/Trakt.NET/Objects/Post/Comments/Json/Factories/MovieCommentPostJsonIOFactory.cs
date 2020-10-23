namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class MovieCommentPostJsonIOFactory : IJsonIOFactory<ITraktMovieCommentPost>
    {
        public IObjectJsonReader<ITraktMovieCommentPost> CreateObjectReader() => new MovieCommentPostObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieCommentPost> CreateObjectWriter() => new MovieCommentPostObjectJsonWriter();
    }
}
