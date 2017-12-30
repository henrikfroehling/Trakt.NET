namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Checkins.Responses.Json.Reader;
    using System;

    internal class MovieCheckinPostResponseJsonReaderFactory : IJsonIOFactory<ITraktMovieCheckinPostResponse>
    {
        public IObjectJsonReader<ITraktMovieCheckinPostResponse> CreateObjectReader() => new MovieCheckinPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieCheckinPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieCheckinPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktMovieCheckinPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovieCheckinPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
