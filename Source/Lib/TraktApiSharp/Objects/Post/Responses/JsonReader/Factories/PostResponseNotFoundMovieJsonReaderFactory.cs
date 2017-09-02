namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new PostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayReader() => new PostResponseNotFoundMovieArrayJsonReader();
    }
}
