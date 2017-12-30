namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json.Factories
{
    using Get.Syncs.Playback.Json.Reader;
    using Objects.Json;

    internal class SyncPlaybackProgressItemJsonReaderFactory : IJsonIOFactory<ITraktSyncPlaybackProgressItem>
    {
        public IObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new SyncPlaybackProgressItemObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader() => new SyncPlaybackProgressItemArrayJsonReader();

        public IObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
