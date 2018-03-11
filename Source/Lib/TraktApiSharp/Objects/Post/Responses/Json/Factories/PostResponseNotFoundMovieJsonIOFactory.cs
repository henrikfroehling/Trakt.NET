namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class PostResponseNotFoundMovieJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new PostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayReader() => new PostResponseNotFoundMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundMovie> CreateObjectWriter() => new PostResponseNotFoundMovieObjectJsonWriter();
    }
}
