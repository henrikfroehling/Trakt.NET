namespace TraktApiSharp.Objects.Post.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundShowJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectReader() => new PostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundShow> CreateArrayReader() => new PostResponseNotFoundShowArrayJsonReader();
    }
}
