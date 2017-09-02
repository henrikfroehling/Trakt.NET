namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class MovieScrobblePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktMovieScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new TraktMovieScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePostResponse)} is not supported.");
        }
    }
}
