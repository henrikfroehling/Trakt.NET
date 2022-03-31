namespace TraktNet.Objects.Post.Basic.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ListItemsReorderPostResponseJsonIOFactory : IJsonIOFactory<ITraktListItemsReorderPostResponse>
    {
        public IObjectJsonReader<ITraktListItemsReorderPostResponse> CreateObjectReader() => new ListItemsReorderPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktListItemsReorderPostResponse> CreateObjectWriter() => new ListItemsReorderPostResponseObjectJsonWriter();
    }
}
