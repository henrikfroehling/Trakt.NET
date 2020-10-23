namespace TraktNet.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class MovieCheckinPostResponseJsonIOFactory : IJsonIOFactory<ITraktMovieCheckinPostResponse>
    {
        public IObjectJsonReader<ITraktMovieCheckinPostResponse> CreateObjectReader() => new MovieCheckinPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieCheckinPostResponse> CreateObjectWriter() => new MovieCheckinPostResponseObjectJsonWriter();
    }
}
