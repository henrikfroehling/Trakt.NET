namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json.Factories
{
    using Objects.Json;

    internal class SyncPlaybackProgressItemJsonReaderFactory : IJsonReaderFactory<ITraktSyncPlaybackProgressItem>
    {
        public IObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new SyncPlaybackProgressItemObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader() => new SyncPlaybackProgressItemArrayJsonReader();
    }
}
