namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Scrobbles.Responses.Json.Reader;
    using System;

    internal class MovieScrobblePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktMovieScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new MovieScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePostResponse)} is not supported.");
        }
    }
}
