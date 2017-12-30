namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundShowJsonReaderFactory : IJsonIOFactory<ITraktPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectReader() => new PostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundShow> CreateArrayReader() => new PostResponseNotFoundShowArrayJsonReader();

        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPostResponseNotFoundShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
