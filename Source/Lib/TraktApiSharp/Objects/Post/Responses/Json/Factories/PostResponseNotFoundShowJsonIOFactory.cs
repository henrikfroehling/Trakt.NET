namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundShowJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectReader() => new PostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundShow> CreateArrayReader() => new PostResponseNotFoundShowArrayJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPostResponseNotFoundShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
