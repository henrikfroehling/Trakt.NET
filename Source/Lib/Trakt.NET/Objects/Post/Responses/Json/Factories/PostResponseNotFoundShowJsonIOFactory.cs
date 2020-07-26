namespace TraktNet.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class PostResponseNotFoundShowJsonIOFactory : IJsonIOFactory<ITraktPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundShow> CreateObjectReader() => new PostResponseNotFoundShowObjectJsonReader();

        public IObjectJsonWriter<ITraktPostResponseNotFoundShow> CreateObjectWriter() => new PostResponseNotFoundShowObjectJsonWriter();
    }
}
