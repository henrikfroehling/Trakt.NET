namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Checkins.Responses.Json.Reader;
    using System;

    internal class MovieCheckinPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktMovieCheckinPostResponse>
    {
        public IObjectJsonReader<ITraktMovieCheckinPostResponse> CreateObjectReader() => new MovieCheckinPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieCheckinPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieCheckinPostResponse)} is not supported.");
        }
    }
}
