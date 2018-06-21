namespace TraktNet.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class MovieCheckinPostResponseJsonIOFactory : IJsonIOFactory<ITraktMovieCheckinPostResponse>
    {
        public IObjectJsonReader<ITraktMovieCheckinPostResponse> CreateObjectReader() => new MovieCheckinPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieCheckinPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieCheckinPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktMovieCheckinPostResponse> CreateObjectWriter() => new MovieCheckinPostResponseObjectJsonWriter();
    }
}
