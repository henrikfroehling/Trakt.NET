namespace TraktNet.Objects.Post.Basic.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ListItemUpdatePostJsonIOFactory : IJsonIOFactory<ITraktListItemUpdatePost>
    {
        public IObjectJsonReader<ITraktListItemUpdatePost> CreateObjectReader() => new ListItemUpdatePostObjectJsonReader();

        public IObjectJsonWriter<ITraktListItemUpdatePost> CreateObjectWriter() => new ListItemUpdatePostObjectJsonWriter();
    }
}
