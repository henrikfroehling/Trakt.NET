namespace TraktApiSharp.Objects.Post.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Responses.Json.Reader;

    internal class PostResponseNotFoundPersonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundPerson>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectReader() => new PostResponseNotFoundPersonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundPerson> CreateArrayReader() => new PostResponseNotFoundPersonArrayJsonReader();
    }
}
