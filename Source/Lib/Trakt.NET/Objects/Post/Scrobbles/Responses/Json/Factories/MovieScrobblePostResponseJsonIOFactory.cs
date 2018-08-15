namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class MovieScrobblePostResponseJsonIOFactory : IJsonIOFactory<ITraktMovieScrobblePostResponse>
    {
        public IObjectJsonReader<ITraktMovieScrobblePostResponse> CreateObjectReader() => new MovieScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieScrobblePostResponse> CreateArrayReader() => new MovieScrobblePostResponseArrayJsonReader();

        public IObjectJsonWriter<ITraktMovieScrobblePostResponse> CreateObjectWriter() => new MovieScrobblePostResponseObjectJsonWriter();
    }
}
