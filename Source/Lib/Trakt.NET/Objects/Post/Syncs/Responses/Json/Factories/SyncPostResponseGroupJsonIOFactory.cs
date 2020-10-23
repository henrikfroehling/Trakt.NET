namespace TraktNet.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktSyncPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseGroup> CreateObjectReader() => new SyncPostResponseGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncPostResponseGroup> CreateObjectWriter() => new SyncPostResponseGroupObjectJsonWriter();
    }
}
