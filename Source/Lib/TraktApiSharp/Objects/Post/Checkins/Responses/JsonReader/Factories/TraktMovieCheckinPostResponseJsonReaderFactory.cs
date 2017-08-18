namespace TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieCheckinPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktMovieCheckinPostResponse>
    {
        public ITraktObjectJsonReader<ITraktMovieCheckinPostResponse> CreateObjectReader() => new TraktMovieCheckinPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieCheckinPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieCheckinPostResponse)} is not supported.");
        }
    }
}
