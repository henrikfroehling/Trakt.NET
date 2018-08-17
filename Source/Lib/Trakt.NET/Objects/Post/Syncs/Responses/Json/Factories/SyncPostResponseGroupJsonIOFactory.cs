namespace TraktNet.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktSyncPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseGroup> CreateObjectReader() => new SyncPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPostResponseGroup> CreateArrayReader() => new SyncPostResponseGroupArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncPostResponseGroup> CreateObjectWriter() => new SyncPostResponseGroupObjectJsonWriter();
    }
}
