namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundPersonJsonReaderFactory : IJsonIOFactory<ITraktPostResponseNotFoundPerson>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectReader() => new PostResponseNotFoundPersonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundPerson> CreateArrayReader() => new PostResponseNotFoundPersonArrayJsonReader();

        public IObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktPostResponseNotFoundPerson> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
