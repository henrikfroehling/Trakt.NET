namespace TraktApiSharp.Objects.Post.Scrobbles.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class MovieScrobblePostJsonIOFactory : IJsonIOFactory<ITraktMovieScrobblePost>
    {
        public IObjectJsonReader<ITraktMovieScrobblePost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktMovieScrobblePost)} is not supported.");

        public IArrayJsonReader<ITraktMovieScrobblePost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePost)} is not supported.");

        public IObjectJsonWriter<ITraktMovieScrobblePost> CreateObjectWriter() => new MovieScrobblePostObjectJsonWriter();
    }
}
