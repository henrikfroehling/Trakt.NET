namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class PostResponseNotFoundPersonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundPerson>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectReader() => new PostResponseNotFoundPersonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundPerson> CreateArrayReader() => new PostResponseNotFoundPersonArrayJsonReader();
    }
}
