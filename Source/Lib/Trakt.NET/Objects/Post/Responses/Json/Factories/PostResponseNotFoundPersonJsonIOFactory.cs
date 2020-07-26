namespace TraktNet.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class PostResponseNotFoundPersonJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundPerson>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectReader() => new PostResponseNotFoundPersonObjectJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundPerson> CreateObjectWriter() => new PostResponseNotFoundPersonObjectJsonWriter();
    }
}
