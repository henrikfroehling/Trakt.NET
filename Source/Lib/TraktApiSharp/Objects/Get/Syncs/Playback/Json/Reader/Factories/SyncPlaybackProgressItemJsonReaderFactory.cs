namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json.Factories.Reader
{
    using Get.Syncs.Playback.Json.Reader;
    using Objects.Json;

    internal class SyncPlaybackProgressItemJsonReaderFactory : IJsonReaderFactory<ITraktSyncPlaybackProgressItem>
    {
        public IObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new SyncPlaybackProgressItemObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader() => new SyncPlaybackProgressItemArrayJsonReader();
    }
}
