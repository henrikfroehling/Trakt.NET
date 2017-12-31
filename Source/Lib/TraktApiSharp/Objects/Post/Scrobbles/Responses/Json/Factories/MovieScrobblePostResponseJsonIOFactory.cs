namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Scrobbles.Responses.Json.Reader;
    using System;

    internal class MovieScrobblePostResponseJsonIOFactory : IJsonIOFactory<ITraktMovieScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new MovieScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktMovieScrobblePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMovieScrobblePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
