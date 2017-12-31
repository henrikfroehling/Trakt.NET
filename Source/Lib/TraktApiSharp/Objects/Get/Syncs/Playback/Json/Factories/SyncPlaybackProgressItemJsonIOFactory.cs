namespace TraktApiSharp.Objects.Get.Syncs.Playback.Json.Factories
{
    using Get.Syncs.Playback.Json.Reader;
    using Objects.Json;

    internal class SyncPlaybackProgressItemJsonIOFactory : IJsonIOFactory<ITraktSyncPlaybackProgressItem>
    {
        public IObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new SyncPlaybackProgressItemObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader() => new SyncPlaybackProgressItemArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncPlaybackProgressItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncPlaybackProgressItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
