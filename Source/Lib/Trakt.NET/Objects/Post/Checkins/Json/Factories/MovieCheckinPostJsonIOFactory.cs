namespace TraktNet.Objects.Post.Checkins.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class MovieCheckinPostJsonIOFactory : IJsonIOFactory<ITraktMovieCheckinPost>
    {
        public IObjectJsonReader<ITraktMovieCheckinPost> CreateObjectReader() => new MovieCheckinPostObjectJsonReader();

        public IArrayJsonReader<ITraktMovieCheckinPost> CreateArrayReader() => new MovieCheckinPostArrayJsonReader();

        public IObjectJsonWriter<ITraktMovieCheckinPost> CreateObjectWriter() => new MovieCheckinPostObjectJsonWriter();
    }
}
