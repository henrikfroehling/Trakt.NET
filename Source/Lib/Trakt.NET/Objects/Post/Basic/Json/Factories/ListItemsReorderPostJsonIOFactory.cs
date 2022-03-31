namespace TraktNet.Objects.Post.Basic.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ListItemsReorderPostJsonIOFactory : IJsonIOFactory<ITraktListItemsReorderPost>
    {
        public IObjectJsonReader<ITraktListItemsReorderPost> CreateObjectReader() => new ListItemsReorderPostObjectJsonReader();

        public IObjectJsonWriter<ITraktListItemsReorderPost> CreateObjectWriter() => new ListItemsReorderPostObjectJsonWriter();
    }
}
