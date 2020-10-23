namespace TraktNet.Objects.Post.Syncs.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectReader() => new SyncPostResponseNotFoundGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncPostResponseNotFoundGroup> CreateObjectWriter() => new SyncPostResponseNotFoundGroupObjectJsonWriter();
    }
}
