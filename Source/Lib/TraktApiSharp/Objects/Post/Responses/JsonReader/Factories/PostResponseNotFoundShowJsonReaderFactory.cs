namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PostResponseNotFoundShowJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectReader() => new PostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundShow> CreateArrayReader() => new PostResponseNotFoundShowArrayJsonReader();
    }
}
