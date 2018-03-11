namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class MovieScrobblePostResponseJsonIOFactory : IJsonIOFactory<ITraktMovieScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new MovieScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktMovieScrobblePostResponse> CreateObjectWriter() => new MovieScrobblePostResponseObjectJsonWriter();
    }
}
