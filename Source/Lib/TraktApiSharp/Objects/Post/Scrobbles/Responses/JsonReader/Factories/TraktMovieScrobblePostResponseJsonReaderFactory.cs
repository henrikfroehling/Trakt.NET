namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieScrobblePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktMovieScrobblePostResponse>
    {
        public ITraktObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new TraktMovieScrobblePostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieScrobblePostResponse)} is not supported.");
        }
    }
}
