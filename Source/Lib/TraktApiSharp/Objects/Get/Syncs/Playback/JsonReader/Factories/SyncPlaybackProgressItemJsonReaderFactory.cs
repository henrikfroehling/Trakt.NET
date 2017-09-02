namespace TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class SyncPlaybackProgressItemJsonReaderFactory : IJsonReaderFactory<ITraktSyncPlaybackProgressItem>
    {
        public IObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new TraktSyncPlaybackProgressItemObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader() => new SyncPlaybackProgressItemArrayJsonReader();
    }
}
