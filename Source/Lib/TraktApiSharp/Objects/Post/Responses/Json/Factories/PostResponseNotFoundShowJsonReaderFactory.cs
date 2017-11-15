namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;

    internal class PostResponseNotFoundShowJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectReader() => new PostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundShow> CreateArrayReader() => new PostResponseNotFoundShowArrayJsonReader();
    }
}
