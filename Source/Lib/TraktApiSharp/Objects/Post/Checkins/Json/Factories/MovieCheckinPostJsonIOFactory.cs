namespace TraktNet.Objects.Post.Checkins.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class MovieCheckinPostJsonIOFactory : IJsonIOFactory<ITraktMovieCheckinPost>
    {
        public IObjectJsonReader<ITraktMovieCheckinPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktMovieCheckinPost)} is not supported.");

        public IArrayJsonReader<ITraktMovieCheckinPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieCheckinPost)} is not supported.");

        public IObjectJsonWriter<ITraktMovieCheckinPost> CreateObjectWriter() => new MovieCheckinPostObjectJsonWriter();
    }
}
