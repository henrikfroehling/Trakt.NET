namespace TraktNet.Objects.Post.Scrobbles.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class MovieScrobblePostJsonIOFactory : IJsonIOFactory<ITraktMovieScrobblePost>
    {
        public IObjectJsonReader<ITraktMovieScrobblePost> CreateObjectReader() => new MovieScrobblePostObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieScrobblePost> CreateObjectWriter() => new MovieScrobblePostObjectJsonWriter();
    }
}
