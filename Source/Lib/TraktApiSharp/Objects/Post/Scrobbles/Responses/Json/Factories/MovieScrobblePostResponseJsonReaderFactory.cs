namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Scrobbles.Responses.Json.Reader;
    using System;

    internal class MovieScrobblePostResponseJsonReaderFactory : IJsonIOFactory<ITraktMovieScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new MovieScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
