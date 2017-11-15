namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;

    internal class PostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new PostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayReader() => new PostResponseNotFoundMovieArrayJsonReader();
    }
}
