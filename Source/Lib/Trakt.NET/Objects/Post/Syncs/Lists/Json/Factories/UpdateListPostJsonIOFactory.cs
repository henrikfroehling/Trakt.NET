namespace TraktNet.Objects.Post.Syncs.Lists.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UpdateListPostJsonIOFactory : IJsonIOFactory<ITraktUpdateListPost>
    {
        public IObjectJsonReader<ITraktUpdateListPost> CreateObjectReader() => new UpdateListPostObjectJsonReader();

        public IObjectJsonWriter<ITraktUpdateListPost> CreateObjectWriter() => new UpdateListPostObjectJsonWriter();
    }
}
