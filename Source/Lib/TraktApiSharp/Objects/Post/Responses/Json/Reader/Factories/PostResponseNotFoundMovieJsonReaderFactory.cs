namespace TraktApiSharp.Objects.Post.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new PostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayReader() => new PostResponseNotFoundMovieArrayJsonReader();
    }
}
