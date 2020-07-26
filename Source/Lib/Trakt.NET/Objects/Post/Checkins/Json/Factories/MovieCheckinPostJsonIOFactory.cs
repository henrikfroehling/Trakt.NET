namespace TraktNet.Objects.Post.Checkins.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class MovieCheckinPostJsonIOFactory : IJsonIOFactory<ITraktMovieCheckinPost>
    {
        public IObjectJsonReader<ITraktMovieCheckinPost> CreateObjectReader() => new MovieCheckinPostObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieCheckinPost> CreateObjectWriter() => new MovieCheckinPostObjectJsonWriter();
    }
}
