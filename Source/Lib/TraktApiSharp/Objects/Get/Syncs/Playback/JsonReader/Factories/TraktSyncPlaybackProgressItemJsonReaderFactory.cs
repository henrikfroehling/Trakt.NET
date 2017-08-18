namespace TraktApiSharp.Objects.Get.Syncs.Playback.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncPlaybackProgressItemJsonReaderFactory : IJsonReaderFactory<ITraktSyncPlaybackProgressItem>
    {
        public ITraktObjectJsonReader<ITraktSyncPlaybackProgressItem> CreateObjectReader() => new TraktSyncPlaybackProgressItemObjectJsonReader();

        public IArrayJsonReader<ITraktSyncPlaybackProgressItem> CreateArrayReader() => new TraktSyncPlaybackProgressItemArrayJsonReader();
    }
}
