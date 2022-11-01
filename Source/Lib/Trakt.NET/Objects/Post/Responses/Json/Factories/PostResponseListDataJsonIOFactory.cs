namespace TraktNet.Objects.Post.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using TraktNet.Objects.Post.Responses;
    using Writer;

    internal class PostResponseListDataJsonIOFactory : IJsonIOFactory<ITraktPostResponseListData>
    {
        public IObjectJsonReader<ITraktPostResponseListData> CreateObjectReader() => new PostResponseListDataObjectJsonReader();

        public IObjectJsonWriter<ITraktPostResponseListData> CreateObjectWriter() => new PostResponseListDataObjectJsonWriter();
    }
}
