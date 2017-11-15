namespace TraktApiSharp.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;

    internal class PostResponseNotFoundPersonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundPerson>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectReader() => new PostResponseNotFoundPersonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundPerson> CreateArrayReader() => new PostResponseNotFoundPersonArrayJsonReader();
    }
}
