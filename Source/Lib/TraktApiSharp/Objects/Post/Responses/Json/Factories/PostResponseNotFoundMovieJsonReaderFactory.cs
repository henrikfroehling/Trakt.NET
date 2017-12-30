namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundMovieJsonReaderFactory : IJsonIOFactory<ITraktPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new PostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayReader() => new PostResponseNotFoundMovieArrayJsonReader();

        public IObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
