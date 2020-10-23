namespace TraktNet.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class PostResponseNotFoundMovieJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new PostResponseNotFoundMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundMovie> CreateObjectWriter() => new PostResponseNotFoundMovieObjectJsonWriter();
    }
}
